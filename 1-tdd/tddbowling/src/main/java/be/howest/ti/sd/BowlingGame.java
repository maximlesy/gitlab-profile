package be.howest.ti.sd;

public class BowlingGame {

    private final int TOTAL_PINS = 10;
    private int pinsUp = TOTAL_PINS;
    public int getPinsUp() {
        return pinsUp;
    }

    public void roll(int pinsToKnockDown) {
        pinsUp -= pinsToKnockDown;
    }

    public int score() {
        return TOTAL_PINS - pinsUp;
    }
}
