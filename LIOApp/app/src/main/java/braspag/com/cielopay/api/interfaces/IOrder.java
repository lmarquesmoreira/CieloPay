package braspag.com.cielopay.api.interfaces;

import java.util.ArrayList;

import braspag.com.cielopay.api.response.OrderResponse;
import braspag.com.cielopay.model.Order;
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

public interface IOrder
{
    @GET("pedido/")
    Call<ArrayList<Order>> All();

    @GET("pedido/{id}")
    Call<Order> Get(@Path("id") String orderId);

    @POST("pedido")
    Call<OrderResponse> Save(@Body Order order);

    @PUT("pedido/{id}?operation={operation}")
    Call Update(@Body Order order, @Path("id") String orderId, @Path("operation") String operation);

    @DELETE("pedido/{id}")
    Call Delete(@Path("id") String orderId);
}
