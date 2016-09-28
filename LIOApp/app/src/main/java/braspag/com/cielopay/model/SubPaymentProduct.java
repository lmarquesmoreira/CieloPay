package braspag.com.cielopay.model;

import android.os.Parcel;
import android.os.Parcelable;

/**
 * Created by lmarq on 25/09/2016.
 */
public class SubPaymentProduct implements Parcelable {

    public String number;
    public String name;

    protected SubPaymentProduct(Parcel in) {
        number = in.readString();
        name = in.readString();
    }

    @Override
    public int describeContents() {
        return 0;
    }

    @Override
    public void writeToParcel(Parcel dest, int flags) {
        dest.writeString(number);
        dest.writeString(name);
    }

    @SuppressWarnings("unused")
    public static final Parcelable.Creator<SubPaymentProduct> CREATOR = new Parcelable.Creator<SubPaymentProduct>() {
        @Override
        public SubPaymentProduct createFromParcel(Parcel in) {
            return new SubPaymentProduct(in);
        }

        @Override
        public SubPaymentProduct[] newArray(int size) {
            return new SubPaymentProduct[size];
        }
    };
}