package braspag.com.cielopay.api.interfaces;

import braspag.com.cielopay.model.Card;
import retrofit2.Call;
import retrofit2.http.GET;

/**
 * Created by lmarq on 25/09/2016.
 */

public interface ICard {

    @GET("api/deviceconfig/")
    Call<Card> GetCard();
}
