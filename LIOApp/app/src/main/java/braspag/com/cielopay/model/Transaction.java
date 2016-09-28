package braspag.com.cielopay.model;

import android.os.Parcel;
import android.os.Parcelable;

import com.google.gson.annotations.SerializedName;

/**
 * Created by lmarq on 25/09/2016.
 */
public class Transaction implements Parcelable {
    public String id;
    @SerializedName("transaction_type")
    public String transactionType;
    public String status;
    public String description;
    @SerializedName("terminal_number")
    public int terminalNumber;
    public Card card;
    public int number;
    @SerializedName("authorization_code")
    public int authorizationCode;
    @SerializedName("payment_product")
    public PaymentProduct paymentProduct;
    public int amount;
    @SerializedName("created_at")
    public String createdAt;
    @SerializedName("updated_at")
    public String updatedAt;

    protected Transaction(Parcel in) {
        id = in.readString();
        transactionType = in.readString();
        status = in.readString();
        description = in.readString();
        terminalNumber = in.readInt();
        card = (Card) in.readValue(Card.class.getClassLoader());
        number = in.readInt();
        authorizationCode = in.readInt();
        paymentProduct = (PaymentProduct) in.readValue(PaymentProduct.class.getClassLoader());
        amount = in.readInt();
        createdAt = in.readString();
        updatedAt = in.readString();
    }

    @Override
    public int describeContents() {
        return 0;
    }

    @Override
    public void writeToParcel(Parcel dest, int flags) {
        dest.writeString(id);
        dest.writeString(transactionType);
        dest.writeString(status);
        dest.writeString(description);
        dest.writeInt(terminalNumber);
        dest.writeValue(card);
        dest.writeInt(number);
        dest.writeInt(authorizationCode);
        dest.writeValue(paymentProduct);
        dest.writeInt(amount);
        dest.writeString(createdAt);
        dest.writeString(updatedAt);
    }

    @SuppressWarnings("unused")
    public static final Parcelable.Creator<Transaction> CREATOR = new Parcelable.Creator<Transaction>() {
        @Override
        public Transaction createFromParcel(Parcel in) {
            return new Transaction(in);
        }

        @Override
        public Transaction[] newArray(int size) {
            return new Transaction[size];
        }
    };
}