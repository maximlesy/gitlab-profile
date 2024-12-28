package be.howest.ti.sd;

public class BowlingGame {

    private int pins = 10;
    public int getPins() {
        return pins;
    }

    public void roll(int pinsToKnockDown) {
        pins -= pinsToKnockDown;
    }
}
