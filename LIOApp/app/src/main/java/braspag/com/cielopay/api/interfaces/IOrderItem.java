package braspag.com.cielopay.api.interfaces;

import java.util.ArrayList;

import braspag.com.cielopay.model.OrderItem;
import retrofit2.Call;
import retrofit2.http.Body;
import retrofit2.http.DELETE;
import retrofit2.http.GET;
import retrofit2.http.POST;
import retrofit2.http.PUT;
import retrofit2.http.Path;

/**
 * Created by lmarq on 25/09/2016.
 */

public interface IOrderItem
{
    @GET("orders/{orderId}/items")
    Call<ArrayList<OrderItem>> All(@Path("orderId") String orderId);


    @POST("orders/{orderId}/items")
    Call Save(@Body OrderItem item, @Path("orderId") String orderId);

    @PUT("orders/{orderId}/items/{id}")
    Call Update(@Body OrderItem item, @Path("orderId") String orderId, @Path("id") String itemId);

    @DELETE("orders/{orderId}/items/{id}")
    Call Delete(@Path("orderId") String orderId, @Path("id") String itemId);


}
