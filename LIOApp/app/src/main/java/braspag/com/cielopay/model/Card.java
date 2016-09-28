package braspag.com.cielopay.model;

import android.os.Parcel;
import android.os.Parcelable;

/**
 * Created by lmarq on 25/09/2016.
 */
public class Card implements Parcelable {
    public String brand;
    public int bin;
    public int last;

    protected Card(Parcel in) {
        brand = in.readString();
        bin = in.readInt();
        last = in.readInt();
    }

    @Override
    public int describeContents() {
        return 0;
    }

    @Override
    public void writeToParcel(Parcel dest, int flags) {
        dest.writeString(brand);
        dest.writeInt(bin);
        dest.writeInt(last);
    }

    @SuppressWarnings("unused")
    public static final Parcelable.Creator<Card> CREATOR = new Parcelable.Creator<Card>() {
        @Override
        public Card createFromParcel(Parcel in) {
            return new Card(in);
        }

        @Override
        public Card[] newArray(int size) {
            return new Card[size];
        }
    };
}