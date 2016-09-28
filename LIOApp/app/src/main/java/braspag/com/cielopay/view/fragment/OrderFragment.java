package braspag.com.cielopay.view.fragment;

import android.content.Intent;
import android.os.AsyncTask;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v4.widget.SwipeRefreshLayout;
import android.support.v7.widget.RecyclerView;
import android.support.v7.widget.StaggeredGridLayoutManager;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

import braspag.com.cielopay.R;
import braspag.com.cielopay.api.RestGenerator;
import braspag.com.cielopay.api.interfaces.IOrder;
import braspag.com.cielopay.model.Order;
import braspag.com.cielopay.view.OrderItemActivity;
import braspag.com.cielopay.view.adapter.OrderListItemAdapter;
import braspag.com.cielopay.view.events.RecyclerItemClickListener;
import retrofit2.Call;
import retrofit2.Response;

/**
 * Created by lmarq on 25/09/2016.
 */
public class OrderFragment extends Fragment {

    public List<Order> _orders;
    RecyclerView listPedidos;
    OrderListItemAdapter adapter;
    private SwipeRefreshLayout refresher;

    /**
     * The fragment argument representing the section number for this
     * fragment.
     */
    private static final String ARG_SECTION_NUMBER = "section_number";

    public OrderFragment() {
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        View rootView = inflater.inflate(R.layout.fragment_main, container, false);

        listPedidos = (RecyclerView) rootView.findViewById(R.id.ordersRecyclerView);
        listPedidos.setLayoutManager(new StaggeredGridLayoutManager(1, StaggeredGridLayoutManager.VERTICAL));
        adapter = new OrderListItemAdapter(getContext(), _orders);
        listPedidos.setAdapter(adapter);

        refresher = (SwipeRefreshLayout) rootView.findViewById(R.id.swipeRefreshLayout);
        refresher.setOnRefreshListener(new SwipeRefreshLayout.OnRefreshListener() {
            @Override
            public void onRefresh() {
                getAllOrders();
            }
        });

        listPedidos.addOnItemTouchListener(new RecyclerItemClickListener(getContext(), new RecyclerItemClickListener.OnItemClickListener() {
            @Override
            public void onItemClick(View view, int position) {
                try {
                    Order o = _orders.get(position);
                    callItemActivity(o);
                } catch (Exception e) {
                    Log.d(RestGenerator.LogAPP, e.getLocalizedMessage());
                }
            }
        }));

        getAllOrders();

        return rootView;
    }

    private void getAllOrders() {
        new OrdersAsync().execute();
    }

    private void callItemActivity(Order model) {
        Intent intent = new Intent(this.getContext(), OrderItemActivity.class);
        intent.putExtra("orderItem", model);
        startActivity(intent);
    }

    class OrdersAsync extends AsyncTask<Void, Void, List<Order>> {

        private String errorMsg;

        @Override
        protected List<Order> doInBackground(Void... voids) {
            RestGenerator rest = new RestGenerator();
            Call<ArrayList<Order>> request = rest.createService(IOrder.class).All();
            Response<ArrayList<Order>> response = null;
            try {
                response = request.execute();
                if (response.isSuccessful()) {
                    return response.body();
                } else {
                    errorMsg = response.errorBody().string();
                    return null;
                }
            } catch (IOException e) {
                e.printStackTrace();
                Log.d(RestGenerator.LogAPP, errorMsg);
                return null;
            }
        }

        @Override
        protected void onPostExecute(List<Order> response) {
            super.onPostExecute(response);
            if (response != null) {
                _orders = response;
                try {
                    adapter.swap(_orders);

                    if (refresher.isRefreshing())
                        refresher.setRefreshing(false);

                } catch (Exception e) {
                    e.printStackTrace();
                }
                //progressBar.setVisibility(View.GONE);
            }
        }

    }
}