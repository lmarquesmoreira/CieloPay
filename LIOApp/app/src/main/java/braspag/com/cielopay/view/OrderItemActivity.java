package braspag.com.cielopay.view;

import java.text.NumberFormat;

import android.app.Activity;
import android.app.ProgressDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.res.ColorStateList;
import android.os.AsyncTask;
import android.os.Handler;
import android.os.Looper;
import android.os.Message;
import android.support.annotation.NonNull;
import android.support.v7.app.AlertDialog;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.support.v7.widget.RecyclerView;
import android.support.v7.widget.StaggeredGridLayoutManager;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

import com.squareup.picasso.Picasso;

import java.io.IOException;
import java.util.ArrayList;
import java.util.Date;
import java.util.HashMap;
import java.util.List;
import java.util.Locale;
import java.util.Map;

import braspag.com.cielopay.MainActivity;
import braspag.com.cielopay.R;
import braspag.com.cielopay.api.RestGenerator;
import braspag.com.cielopay.api.interfaces.IOrder;
import braspag.com.cielopay.model.Order;
import braspag.com.cielopay.model.OrderItem;
import braspag.com.cielopay.view.adapter.ItemListAdapter;
import butterknife.ButterKnife;
import cielo.orders.aidl.ParcelableOrder;
import cielo.sdk.order.Credentials;
import cielo.sdk.order.Environment;
import cielo.sdk.order.OrderManager;
import cielo.sdk.order.UnitOfMeasure;
import cielo.sdk.order.payment.Payment;
import cielo.sdk.order.payment.PaymentError;
import cielo.sdk.order.payment.PaymentListener;
import cielo.sdk.order.payment.PaymentOptions;
import de.hdodenhof.circleimageview.CircleImageView;
import okhttp3.MediaType;
import okhttp3.OkHttpClient;
import okhttp3.Request;
import okhttp3.RequestBody;
import okhttp3.Response;
import retrofit2.Call;

public class OrderItemActivity extends AppCompatActivity {
    private static String TAG = "PAYMENT_LISTENER";
    OrderManager orderManager;
    private ItemListAdapter listAdapter;
    private Order order;
    private String totalCapture;
    private String restanteCapture;
    private TextView orderTitle;
    private TextView clientTitle;
    private TextView priceTitle;
    private Button capturaTotal;
    private Button capturaParcial;
    private RecyclerView itensRecyclerView;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_order_item);

        try {
            order = getIntent().getParcelableExtra("orderItem");
        } catch (Exception e) {
            Log.d(RestGenerator.LogAPP, e.getLocalizedMessage());
        }

        initComponents();
    }


    private void configSDK() {
        ButterKnife.bind(this);
        Map<String, Object> options = new HashMap<>();
        Credentials credentials = new Credentials("GfUSILNTi3yF", "axgsxsAP90TP");
        orderManager = new OrderManager(credentials, Environment.SANDBOX, options);
        orderManager.bind(this);
    }


    private void initComponents() {
        orderTitle = (TextView) findViewById(R.id.order_title);
        clientTitle = (TextView) findViewById(R.id.order_client);
        priceTitle = (TextView) findViewById(R.id.order_total);
        capturaTotal = (Button) findViewById(R.id.order_compra_total);
        capturaParcial = (Button) findViewById(R.id.order_compra_parcial);
        itensRecyclerView = (RecyclerView) findViewById(R.id.order_recyclerView);

        if (!order.VelocityApproved) {
            capturaTotal.setText("Pagar");
            capturaParcial.setVisibility(View.INVISIBLE);
        }

        itensRecyclerView.setLayoutManager(new StaggeredGridLayoutManager(1, StaggeredGridLayoutManager.VERTICAL));
        listAdapter = new ItemListAdapter(order.items);
        itensRecyclerView.setAdapter(listAdapter);

        CircleImageView imageView = (CircleImageView) findViewById(R.id.profile_image);
        try {
            Picasso.with(this).load(order.User.ImagemUrl).into(imageView);
        } catch (Exception e) {
            Log.d(RestGenerator.LogAPP, e.getLocalizedMessage());
        }

        String price = NumberFormat.getCurrencyInstance(new Locale("pt", "BR")).format((order.price / 100));
        String tPrice = String.format(getString(R.string.card_offer_price), price);
        priceTitle.setText(tPrice);

        orderTitle.setText(order.reference);
        clientTitle.setText(order.User.Name);

        capturaTotal.setOnClickListener(capturaTotalClick);
//        capturaParcial.setOnClickListener(capturaParcialClick);
    }

    View.OnClickListener capturaParcialClick = new View.OnClickListener() {
        @Override
        public void onClick(View view) {
            // get prompts.xml view
            LayoutInflater layoutInflater = LayoutInflater.from(OrderItemActivity.this);
            View promptView = layoutInflater.inflate(R.layout.dialog_captura_parcial, null);
            AlertDialog.Builder alertDialogBuilder = new AlertDialog.Builder(OrderItemActivity.this);
            alertDialogBuilder.setView(promptView);

            final EditText editText = (EditText) promptView.findViewById(R.id.edittext);
            // setup a dialog window
            alertDialogBuilder.setCancelable(false)
                    .setPositiveButton("Capturar", new DialogInterface.OnClickListener() {
                        public void onClick(DialogInterface dialog, int id) {
                            String value = editText.getText().toString();

                        }
                    })
                    .setNegativeButton("Cancelar",
                            new DialogInterface.OnClickListener() {
                                public void onClick(DialogInterface dialog, int id) {
                                    dialog.cancel();
                                }
                            });

            // create an alert dialog
            AlertDialog alert = alertDialogBuilder.create();
            alert.show();
        }
    };


    View.OnClickListener capturaTotalClick = new View.OnClickListener() {
        @Override

        public void onClick(final View view) {
            if (order.VelocityApproved)
                makeCieloPayment();
            else
                makePayment();

        }
    };

    public void makeCieloPayment() {
        final ProgressDialog progress = new ProgressDialog(this);
        progress.setTitle("Capturando");
        progress.setMessage("Capturando...");
        progress.show();

        final Activity self = this;

        final Handler handler = new Handler() {
            @Override
            public void handleMessage(Message msg) {
                progress.dismiss();
            }
        };

        new Thread(new Runnable() {

            @Override
            public void run() {
                try {
                    Looper.prepare();

                    new CieloPaymentAsync(self.getBaseContext(), handler).execute();

                    Looper.loop();
                } catch (Exception ex) {
                    Log.d(RestGenerator.LogAPP, ex.getLocalizedMessage());
                    handler.sendEmptyMessage(0);
                }
            }
        }).start();
    }


    private cielo.sdk.order.Order generateOrderLocal() {
        cielo.sdk.order.Order orderX = MainActivity.orderManager.createDraftOrder(order.reference);
        for (OrderItem item : order.items) {
            String a = "" + item.unitPrice;
            long value = Long.parseLong(a);
            orderX.addItem(item.sku, item.name, value, item.quantity, UnitOfMeasure.EACH);
        }
        return orderX;
    }

    public void makePayment() {
        cielo.sdk.order.Order orderX = generateOrderLocal();
        MainActivity.orderManager.placeOrder(orderX);
        MainActivity.orderManager.checkoutOrder(orderX, PaymentOptions.ALLOW_ONLY_CREDIT_PAYMENT.getValue(), new PaymentListener() {

            @Override
            public void onStart() {
                Log.d(TAG, "ON START");
            }

            @Override
            public void onPayment(@NonNull Payment payment) {
                Log.d(TAG, "ON PAYMENT");
            }

            @Override
            public void onCancel() {
                Log.d(TAG, "ON CANCEL");
            }

            @Override
            public void onSuccess() {
                onSuccessCaptured(OrderItemActivity.this);
                Log.d(TAG, "ON SUCCESS");
            }

            @Override
            public void onError(@NonNull PaymentError paymentError) {
                Log.d(TAG, "ON ERROR");
            }

        });

    }

    public void onSuccessCaptured(final Context context) {
        Toast.makeText(context, "Capturada com sucesso", Toast.LENGTH_LONG).show();
        finish();
    }

    class CieloPaymentAsync extends AsyncTask<Void, Void, Boolean> {

        private Context context;
        private Handler handler;

        public CieloPaymentAsync(Context ctx, Handler h) {
            context = ctx;
            handler = h;
        }

        @Override
        protected Boolean doInBackground(Void... voids) {
            String url = "***************" + order.PaymentId + "/capture";
            String jsonBody = "";
            MediaType JSON = MediaType.parse("application/json; charset=utf-8");
            RequestBody body = RequestBody.create(JSON, jsonBody);

            OkHttpClient client = new OkHttpClient();

            Request request = new Request.Builder()
                    .url(url)
                    .put(body)
                    .addHeader("MerchantId", "***************")
                    .addHeader("MerchantKey", "***************")
                    .build();

            Response response = null;
            boolean result = false;
            try {
                response = client.newCall(request).execute();
                result = response.isSuccessful();
            } catch (IOException e) {
                e.printStackTrace();
            }

            return result;
        }

        @Override
        protected void onPostExecute(Boolean response) {
            super.onPostExecute(response);
            handler.sendEmptyMessage(0);
            if (response) {
                onSuccessCaptured(context);
            } else
                Toast.makeText(context, "Ocorreu algum problema ao capturar, tente novamente", Toast.LENGTH_LONG).show();
        }
    }

}
