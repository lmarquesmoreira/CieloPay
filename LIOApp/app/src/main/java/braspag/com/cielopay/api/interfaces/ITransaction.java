package braspag.com.cielopay.api.interfaces;

import java.util.ArrayList;

import braspag.com.cielopay.model.Transaction;
import retrofit2.Call;
import retrofit2.http.GET;
import retrofit2.http.Path;

/**
 * Created by lmarq on 25/09/2016.
 */

public interface ITransaction
{
    @GET("orders/{orderId}/transactions")
    Call<ArrayList<Transaction>> All(@Path("orderId") String orderId);

    @GET("orders/{orderId}/transactions/{id}")
    Call<Transaction> Get(@Path("orderId") String orderId, @Path("id") String transactionId);
}
