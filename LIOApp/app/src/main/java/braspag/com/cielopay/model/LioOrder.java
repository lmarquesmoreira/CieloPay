package braspag.com.cielopay.model;

import android.os.Parcel;
import android.os.Parcelable;

import com.google.gson.annotations.SerializedName;

/**
 * Created by lmarq on 25/09/2016.
 */

public class LioOrder implements Parcelable {
    @SerializedName("Payment_Id")
    public String Payment_Id;
    public String LioResponseId;
    public User User;

    protected LioOrder(Parcel in) {
        Payment_Id = in.readString();
        LioResponseId = in.readString();
        User = (User) in.readValue(User.class.getClassLoader());
    }

    @Override
    public int describeContents() {
        return 0;
    }

    @Override
    public void writeToParcel(Parcel dest, int flags) {
        dest.writeString(Payment_Id);
        dest.writeString(LioResponseId);
        dest.writeValue(User);
    }

    @SuppressWarnings("unused")
    public static final Parcelable.Creator<LioOrder> CREATOR = new Parcelable.Creator<LioOrder>() {
        @Override
        public LioOrder createFromParcel(Parcel in) {
            return new LioOrder(in);
        }

        @Override
        public LioOrder[] newArray(int size) {
            return new LioOrder[size];
        }
    };
}