package braspag.com.cielopay.model;

import android.os.Parcel;
import android.os.Parcelable;

/**
 * Created by lmarq on 25/09/2016.
 */

public class Address implements Parcelable {
    public int Id;
    public int UserId;
    public String Street;
    public String Number;
    public String ZipCode;
    public String Neighborhood;
    public String State;
    public User User;

    protected Address(Parcel in) {
        Id = in.readInt();
        UserId = in.readInt();
        Street = in.readString();
        Number = in.readString();
        ZipCode = in.readString();
        Neighborhood = in.readString();
        State = in.readString();
        User = (User) in.readValue(User.class.getClassLoader());
    }

    @Override
    public int describeContents() {
        return 0;
    }

    @Override
    public void writeToParcel(Parcel dest, int flags) {
        dest.writeInt(Id);
        dest.writeInt(UserId);
        dest.writeString(Street);
        dest.writeString(Number);
        dest.writeString(ZipCode);
        dest.writeString(Neighborhood);
        dest.writeString(State);
        dest.writeValue(User);
    }

    @SuppressWarnings("unused")
    public static final Parcelable.Creator<Address> CREATOR = new Parcelable.Creator<Address>() {
        @Override
        public Address createFromParcel(Parcel in) {
            return new Address(in);
        }

        @Override
        public Address[] newArray(int size) {
            return new Address[size];
        }
    };
}
