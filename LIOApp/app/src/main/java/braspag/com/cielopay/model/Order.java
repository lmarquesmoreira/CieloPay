package braspag.com.cielopay.model;

import android.os.Parcel;
import android.os.Parcelable;

import com.google.gson.annotations.SerializedName;

import java.util.ArrayList;

/**
 * Created by lmarq on 25/09/2016.
 */
public class Order implements Parcelable {
    public Boolean VelocityApproved;
    public String LioResponseId;
    public User User;
    public int UserId;
    public String PaymentId;
    public String id;
    public String number;
    public String reference;
    public String status;
    @SerializedName("created_at")
    public String createdAt;
    @SerializedName("updated_at")
    public String updatedAt;
    public ArrayList<OrderItem> items;
    public String notes;
    public ArrayList<Transaction> transactions;
    public int price;
    public int remaining;



    protected Order(Parcel in) {
        byte VelocityApprovedVal = in.readByte();
        VelocityApproved = VelocityApprovedVal == 0x02 ? null : VelocityApprovedVal != 0x00;
        LioResponseId = in.readString();
        User = (User) in.readValue(User.class.getClassLoader());
        UserId = in.readInt();
        PaymentId = in.readString();
        id = in.readString();
        number = in.readString();
        reference = in.readString();
        status = in.readString();
        createdAt = in.readString();
        updatedAt = in.readString();
        if (in.readByte() == 0x01) {
            items = new ArrayList<OrderItem>();
            in.readList(items, OrderItem.class.getClassLoader());
        } else {
            items = null;
        }
        notes = in.readString();
        if (in.readByte() == 0x01) {
            transactions = new ArrayList<Transaction>();
            in.readList(transactions, Transaction.class.getClassLoader());
        } else {
            transactions = null;
        }
        price = in.readInt();
        remaining = in.readInt();
    }

    @Override
    public int describeContents() {
        return 0;
    }

    @Override
    public void writeToParcel(Parcel dest, int flags) {
        if (VelocityApproved == null) {
            dest.writeByte((byte) (0x02));
        } else {
            dest.writeByte((byte) (VelocityApproved ? 0x01 : 0x00));
        }
        dest.writeString(LioResponseId);
        dest.writeValue(User);
        dest.writeInt(UserId);
        dest.writeString(PaymentId);
        dest.writeString(id);
        dest.writeString(number);
        dest.writeString(reference);
        dest.writeString(status);
        dest.writeString(createdAt);
        dest.writeString(updatedAt);
        if (items == null) {
            dest.writeByte((byte) (0x00));
        } else {
            dest.writeByte((byte) (0x01));
            dest.writeList(items);
        }
        dest.writeString(notes);
        if (transactions == null) {
            dest.writeByte((byte) (0x00));
        } else {
            dest.writeByte((byte) (0x01));
            dest.writeList(transactions);
        }
        dest.writeInt(price);
        dest.writeInt(remaining);
    }

    @SuppressWarnings("unused")
    public static final Parcelable.Creator<Order> CREATOR = new Parcelable.Creator<Order>() {
        @Override
        public Order createFromParcel(Parcel in) {
            return new Order(in);
        }

        @Override
        public Order[] newArray(int size) {
            return new Order[size];
        }
    };
}