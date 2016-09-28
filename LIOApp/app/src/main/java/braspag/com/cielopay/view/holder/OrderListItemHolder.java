package braspag.com.cielopay.view.holder;

import android.content.Context;
import android.support.v7.widget.RecyclerView;
import android.util.Log;
import android.view.View;
import android.widget.LinearLayout;
import android.widget.TextView;

import com.squareup.picasso.Picasso;

import org.joda.time.LocalDateTime;

import java.text.NumberFormat;
import java.util.Locale;

import braspag.com.cielopay.R;
import braspag.com.cielopay.api.RestGenerator;
import braspag.com.cielopay.model.Order;
import braspag.com.cielopay.model.OrderStatus;

/**
 * Created by lmarq on 25/09/2016.
 */

public class OrderListItemHolder extends RecyclerView.ViewHolder {

    private TextView title;
    private TextView cod;
    private TextView orderUpdated;
    private LinearLayout statusColor;

    public OrderListItemHolder(View itemView) {
        super(itemView);
        try {
            title = (TextView) itemView.findViewById(R.id.card_orderTitle);
            cod = (TextView) itemView.findViewById(R.id.card_orderCod);
            orderUpdated = (TextView) itemView.findViewById(R.id.card_orderUpdated);
            statusColor = (LinearLayout) itemView.findViewById(R.id.order_statusColor);
        } catch (Exception e) {
            e.printStackTrace();
            Log.d(RestGenerator.LogAPP, e.getLocalizedMessage());
        }
    }

    public void setDataOnCard(final Context context, final Order model) {
        title.setText(model.reference);
        String price = NumberFormat.getCurrencyInstance(new Locale("pt", "BR")).format((model.price / 100));
        String text = String.format(context.getString(R.string.card_offer_price), price);
        cod.setText(text);

        if (model.VelocityApproved) {
            statusColor.setBackgroundResource(R.color.colorPago);
        } else {
            statusColor.setBackgroundResource(R.color.colorCancelado);
        }

        orderUpdated.setText(String.format(context.getString(R.string.card_offer_data), model.updatedAt));


    }
}
