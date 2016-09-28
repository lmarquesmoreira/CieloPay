package braspag.com.cielopay.model;

import android.os.Parcel;
import android.os.Parcelable;

import java.util.ArrayList;
import java.util.List;

/**
 * Created by lmarq on 25/09/2016.
 */

public class User implements Parcelable {
    public int Id ;
    public String Name ;
    public String Email ;
    public String Telefone ;
    public String ImagemUrl;
    public String OauthToken;
    public ArrayList<Card> Cards ;
    public List<Address> Addresses ;
    public List<Order> Pedidos ;

    public User(){

    }

    protected User(Parcel in) {
        Id = in.readInt();
        Name = in.readString();
        Email = in.readString();
        Telefone = in.readString();
        ImagemUrl = in.readString();
        OauthToken = in.readString();
        if (in.readByte() == 0x01) {
            Cards = new ArrayList<Card>();
            in.readList(Cards, Card.class.getClassLoader());
        } else {
            Cards = null;
        }
        if (in.readByte() == 0x01) {
            Addresses = new ArrayList<Address>();
            in.readList(Addresses, Address.class.getClassLoader());
        } else {
            Addresses = null;
        }
        if (in.readByte() == 0x01) {
            Pedidos = new ArrayList<Order>();
            in.readList(Pedidos, Order.class.getClassLoader());
        } else {
            Pedidos = null;
        }
    }

    @Override
    public int describeContents() {
        return 0;
    }

    @Override
    public void writeToParcel(Parcel dest, int flags) {
        dest.writeInt(Id);
        dest.writeString(Name);
        dest.writeString(Email);
        dest.writeString(Telefone);
        dest.writeString(ImagemUrl);
        dest.writeString(OauthToken);
        if (Cards == null) {
            dest.writeByte((byte) (0x00));
        } else {
            dest.writeByte((byte) (0x01));
            dest.writeList(Cards);
        }
        if (Addresses == null) {
            dest.writeByte((byte) (0x00));
        } else {
            dest.writeByte((byte) (0x01));
            dest.writeList(Addresses);
        }
        if (Pedidos == null) {
            dest.writeByte((byte) (0x00));
        } else {
            dest.writeByte((byte) (0x01));
            dest.writeList(Pedidos);
        }
    }

    @SuppressWarnings("unused")
    public static final Parcelable.Creator<User> CREATOR = new Parcelable.Creator<User>() {
        @Override
        public User createFromParcel(Parcel in) {
            return new User(in);
        }

        @Override
        public User[] newArray(int size) {
            return new User[size];
        }
    };
}