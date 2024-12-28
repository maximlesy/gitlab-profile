package be.howest.ti.sd;

public class BowlingGame {

    private final int MAX_FRAMES = 10;
    private final int TOTAL_PINS = 10;
    private int pinsUp = TOTAL_PINS;
    private int currentFrame = 1;
    private GameStatus gameStatus = GameStatus.NOT_STARTED;
    private int currentFrameRolls = 0;

    public int getPinsUp() {
        return pinsUp;
    }
    public int getCurrentFrame() {
        return currentFrame;
    }

    public GameStatus getGameStatus() {
        return gameStatus;
    }

    public void roll(int pinsToKnockDown) {

        verifyRoll(pinsToKnockDown);

        if (pinsToKnockDown == TOTAL_PINS) {
            currentFrame++;
            currentFrameRolls = 0;
        }

        updateFrame();

        pinsUp -= pinsToKnockDown;
    }

    public int score() {
        return TOTAL_PINS - pinsUp;
    }

    private void updateFrame() {
        currentFrameRolls++;

        if (currentFrameRolls == 2) {
            currentFrame++;
            currentFrameRolls = 0;
        }

        if (currentFrame > MAX_FRAMES) {
            gameStatus = GameStatus.FINISHED;
        } else {
            gameStatus = GameStatus.IN_PROGRESS;
        }
    }

    private void verifyRoll(int pinsToKnockDown) {
        if (gameStatus == GameStatus.FINISHED) {
            throw new RollException("Game is already finished");
        }

        if (pinsToKnockDown > pinsUp) {
            throw new RollException("Cannot knock down more pins than there are up");
        }

        if (pinsToKnockDown < 0) {
            throw new RollException("Cannot knock down a negative number of pins");
        }
    }


    public class RollException extends RuntimeException {
        public RollException(String message) {
            super(message);
        }
    }
}
