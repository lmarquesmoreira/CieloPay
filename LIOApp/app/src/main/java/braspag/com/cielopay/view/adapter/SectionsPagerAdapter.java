package braspag.com.cielopay.view.adapter;

import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.support.v4.app.FragmentPagerAdapter;

import braspag.com.cielopay.view.fragment.OrderFragment;
import braspag.com.cielopay.view.fragment.SaleFragment;

/**
 * Created by lmarq on 25/09/2016.
 */
public class SectionsPagerAdapter extends FragmentPagerAdapter {

    public SectionsPagerAdapter(FragmentManager fm) {
        super(fm);
    }

    @Override
    public Fragment getItem(int position) {
        if (position == 0) {
            return new OrderFragment();
        } else {
            return new SaleFragment();
        }
    }

    @Override
    public int getCount() {
        // Show 3 total pages.
        return 2;
    }

    @Override
    public CharSequence getPageTitle(int position) {
        switch (position) {
            case 0:
                return "Pedidos";
            case 1:
                return "Vendas";
        }
        return null;
    }
}

