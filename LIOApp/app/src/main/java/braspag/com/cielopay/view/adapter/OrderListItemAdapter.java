package braspag.com.cielopay.view.adapter;

import android.content.Context;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import java.util.ArrayList;
import java.util.List;

import braspag.com.cielopay.MainActivity;
import braspag.com.cielopay.R;
import braspag.com.cielopay.model.Order;
import braspag.com.cielopay.view.holder.OrderListItemHolder;

/**
 * Created by lmarq on 25/09/2016.
 */


public class OrderListItemAdapter extends RecyclerView.Adapter<OrderListItemHolder> {
    private static List<Order> _orders;
    private Context _context;

    public OrderListItemAdapter(List<Order> orders) {
        if (orders == null)
            orders = new ArrayList<>();
        _orders = orders;
    }

    public OrderListItemAdapter(Context context, List<Order> orders) {
        if (orders == null)
            orders = new ArrayList<>();
        _orders = orders;
        _context = context;
    }

    public void swap(List<Order> orders) {
        if (_orders != null) {
            _orders.clear();
            _orders.addAll(orders);
        } else {
            _orders = orders;
        }
        notifyDataSetChanged();
    }

    @Override
    public OrderListItemHolder onCreateViewHolder(ViewGroup parent, int viewType) {
        View view = LayoutInflater.from(parent.getContext()).inflate(R.layout.card_order, parent, false);
        OrderListItemHolder holder = new OrderListItemHolder(view);
        return holder;
    }

    @Override
    public void onBindViewHolder(OrderListItemHolder holder, int position) {
        Order model = _orders.get(position);
        holder.setDataOnCard(_context, model);
    }

    @Override
    public int getItemCount() {
        return _orders.size();
    }
}
