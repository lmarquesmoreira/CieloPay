package braspag.com.cielopay.view.adapter;

import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import java.util.ArrayList;
import java.util.List;

import braspag.com.cielopay.R;
import braspag.com.cielopay.model.OrderItem;
import braspag.com.cielopay.view.holder.OrderItemListHolder;

/**
 * Created by lmarq on 25/09/2016.
 */
/*
* Relativo aos itens de um pedido
* */
public class ItemListAdapter extends RecyclerView.Adapter<OrderItemListHolder> {

    List<OrderItem> _orderItems;

    public ItemListAdapter(List<OrderItem> orders) {
        if (orders == null)
            orders = new ArrayList<>();
        _orderItems = orders;
    }

    public void swap(List<OrderItem> orders) {
        if (_orderItems != null) {
            _orderItems.clear();
            _orderItems.addAll(orders);
        } else {
            _orderItems = orders;
        }
        notifyDataSetChanged();
    }


    @Override
    public OrderItemListHolder onCreateViewHolder(ViewGroup parent, int viewType) {
        View view = LayoutInflater.from(parent.getContext()).inflate(R.layout.card_order_item, parent, false);
        OrderItemListHolder holder = new OrderItemListHolder(view);
        return holder;
    }

    @Override
    public void onBindViewHolder(OrderItemListHolder holder, int position) {
        OrderItem model = _orderItems.get(position);
        holder.setDataOnCard(model);
    }

    @Override
    public int getItemCount() {
        return _orderItems.size();
    }
}
