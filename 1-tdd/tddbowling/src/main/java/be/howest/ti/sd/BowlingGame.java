package be.howest.ti.sd;

public class BowlingGame {

    private final int TOTAL_PINS = 10;
    private int pinsUp = TOTAL_PINS;
    public int getPinsUp() {
        return pinsUp;
    }

    public void roll(int pinsToKnockDown) {

        if (pinsToKnockDown > pinsUp) {
            throw new RollException("Cannot knock down more pins than there are up");
        }

        if (pinsToKnockDown < 0) {
            throw new RollException("Cannot knock down a negative number of pins");
        }

        pinsUp -= pinsToKnockDown;
    }

    public int score() {
        return TOTAL_PINS - pinsUp;
    }

    public class RollException extends RuntimeException {
        public RollException(String message) {
            super(message);
        }
    }
}