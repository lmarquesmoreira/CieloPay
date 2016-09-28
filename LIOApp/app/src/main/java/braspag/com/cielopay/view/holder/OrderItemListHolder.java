package braspag.com.cielopay.view.holder;

import android.content.Context;
import android.support.v7.widget.RecyclerView;
import android.util.Log;
import android.view.View;
import android.widget.TextView;

import com.squareup.picasso.Picasso;

import braspag.com.cielopay.R;
import braspag.com.cielopay.api.RestGenerator;
import braspag.com.cielopay.model.OrderItem;
import de.hdodenhof.circleimageview.CircleImageView;

/**
 * Created by lmarq on 25/09/2016.
 */

public class OrderItemListHolder extends RecyclerView.ViewHolder {

    private TextView title;
    private Context context;
    private CircleImageView imageView;

    public OrderItemListHolder(View itemView) {
        super(itemView);
        context = itemView.getContext();
        title = (TextView) itemView.findViewById(R.id.order_item_title);
        imageView = (CircleImageView) itemView.findViewById(R.id.order_item_image);
    }

    public void setDataOnCard(final OrderItem model) {

        title.setText(model.name);

        try {
            Picasso.with(context).load(model.ImageUrl).into(imageView);
        } catch (Exception e) {
            Log.d(RestGenerator.LogAPP, e.getLocalizedMessage());
        }

    }
}
