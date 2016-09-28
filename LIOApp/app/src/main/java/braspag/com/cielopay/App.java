package braspag.com.cielopay;

import android.app.Application;

import net.danlew.android.joda.JodaTimeAndroid;

import java.util.HashMap;
import java.util.Map;

import cielo.sdk.order.Credentials;
import cielo.sdk.order.Environment;
import cielo.sdk.order.OrderManager;

/**
 * Created by lmarq on 25/09/2016.
 */

public class App extends Application {

    public static final String TAG = App.class.getSimpleName();
    private static App mInstance;


    @Override
    public void onCreate() {
        super.onCreate();
        mInstance = this;
        JodaTimeAndroid.init(this);
    }

    public static synchronized App getInstance() {
        if(mInstance == null)
            mInstance = new App();
        return mInstance;
    }



}