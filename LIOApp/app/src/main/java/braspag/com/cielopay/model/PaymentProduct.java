package braspag.com.cielopay.model;

import android.os.Parcel;
import android.os.Parcelable;

/**
 * Created by lmarq on 25/09/2016.
 */

public class PaymentProduct implements Parcelable {

    public String number;
    public String name;
    public SubPaymentProduct sub;

    protected PaymentProduct(Parcel in) {
        number = in.readString();
        name = in.readString();
        sub = (SubPaymentProduct) in.readValue(SubPaymentProduct.class.getClassLoader());
    }

    @Override
    public int describeContents() {
        return 0;
    }

    @Override
    public void writeToParcel(Parcel dest, int flags) {
        dest.writeString(number);
        dest.writeString(name);
        dest.writeValue(sub);
    }

    @SuppressWarnings("unused")
    public static final Parcelable.Creator<PaymentProduct> CREATOR = new Parcelable.Creator<PaymentProduct>() {
        @Override
        public PaymentProduct createFromParcel(Parcel in) {
            return new PaymentProduct(in);
        }

        @Override
        public PaymentProduct[] newArray(int size) {
            return new PaymentProduct[size];
        }
    };
}