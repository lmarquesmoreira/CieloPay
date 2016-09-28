package braspag.com.cielopay.model;

import android.os.Parcel;
import android.os.Parcelable;

import com.google.gson.annotations.SerializedName;

/**
 * Created by lmarq on 25/09/2016.
 */
public class OrderItem implements Parcelable {
    public String ImageUrl;
    public String OrderId;
    public String sku;
    public String name;
    public String description;
    @SerializedName("unit_price")
    public int unitPrice;
    public int quantity;
    @SerializedName("unit_of_measure")
    public String unitOfMeasure;
    public String details;
    @SerializedName("created_at")
    public String createdAt;
    @SerializedName("updated_at")
    public String updatedAt;


    protected OrderItem(Parcel in) {
        ImageUrl = in.readString();
        OrderId= in.readString();
        sku = in.readString();
        name = in.readString();
        description = in.readString();
        unitPrice = in.readInt();
        quantity = in.readInt();
        unitOfMeasure = in.readString();
        details = in.readString();
        createdAt = in.readString();
        updatedAt = in.readString();
    }

    @Override
    public int describeContents() {
        return 0;
    }

    @Override
    public void writeToParcel(Parcel dest, int flags) {
        dest.writeString(ImageUrl);
        dest.writeString(OrderId);
        dest.writeString(sku);
        dest.writeString(name);
        dest.writeString(description);
        dest.writeInt(unitPrice);
        dest.writeInt(quantity);
        dest.writeString(unitOfMeasure);
        dest.writeString(details);
        dest.writeString(createdAt);
        dest.writeString(updatedAt);
    }

    @SuppressWarnings("unused")
    public static final Parcelable.Creator<OrderItem> CREATOR = new Parcelable.Creator<OrderItem>() {
        @Override
        public OrderItem createFromParcel(Parcel in) {
            return new OrderItem(in);
        }

        @Override
        public OrderItem[] newArray(int size) {
            return new OrderItem[size];
        }
    };
}