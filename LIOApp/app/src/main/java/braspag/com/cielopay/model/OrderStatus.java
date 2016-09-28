package braspag.com.cielopay.model;

/**
 * Created by lmarq on 25/09/2016.
 */

public enum OrderStatus {

    //ENTERED, RE-ENTERED, PAID, CANCELED e CLOSED
    Entrando("ENTERED"),
    ReEntrando("RE-ENTERED"),
    Pago("PAID"),
    Cancelado("CANCELED"),
    Fechado("CLOSED");

    private final String name;

    OrderStatus(String s) {
        name = s;
    }

    public boolean equalsName(String otherName) {
        return (otherName == null) ? false : name.equals(otherName);
    }

    public String toString() {
        return this.name;
    }
}
