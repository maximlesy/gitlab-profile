package be.howest.ti.sd;
import java.util.*;

public class BowlingGame {
    private int pinsUp;
    private int currentFrame;
    private GameStatus gameStatus;
    private List<Frame> frames;

    public BowlingGame() {
        this.currentFrame = 1;
        this.pinsUp = Settings.TOTAL_PINS;
        this.gameStatus = GameStatus.IN_PROGRESS;
        this.frames = new ArrayList<>();

        for (int i = 0; i < Settings.MAX_FRAMES; i++) {
            frames.add(new Frame());
        }
    }

    public int getPinsUp() {
        return pinsUp;
    }
    public int getCurrentFrame() {
        return currentFrame;
    }
    public Frame getActiveFrame() {
        return frames.get(currentFrame - 1);
    }

    public GameStatus getGameStatus() {
        return gameStatus;
    }

    public void roll(int pinsToKnockDown) {

        verifyRoll(pinsToKnockDown);
        knockDownPins(pinsToKnockDown);
    }

    public int score() {
        int totalScore = 0;
        for (int i = 0; i < frames.size(); i++) {
            Frame frame = frames.get(i);
            for(int j = 0; j < frame.getRolls().size(); j++) {
                totalScore += frame.getRolls().get(j);
            }
        }
        return totalScore;
    }

    private void knockDownPins(int pinsToKnockDown) {

        Frame activeFrame = getActiveFrame();
        activeFrame.addRoll(pinsToKnockDown);

        pinsUp -= pinsToKnockDown;

        if (activeFrame.isComplete()) {
            currentFrame++;
            pinsUp = Settings.TOTAL_PINS;
        }

        if (currentFrame > Settings.MAX_FRAMES) {
            gameStatus = GameStatus.FINISHED;
        }
    }

    private void verifyRoll(int pinsToKnockDown) {

        if (gameStatus == GameStatus.FINISHED) {
            throw new RollException("Game is already finished");
        }

        if (pinsToKnockDown > pinsUp)  {
            throw new RollException("Cannot knock down more pins than there are up");
        }

        if (pinsToKnockDown > Settings.TOTAL_PINS || pinsToKnockDown - pinsUp > Settings.KNOCKDOWN_LOWER_LIMIT) {
            throw new RollException("Trying to knock down too many pins.");
        }

        if (pinsToKnockDown < 0) {
            throw new RollException("You must knock down at least 1 pin.");
        }
    }

    public class RollException extends RuntimeException {
        public RollException(String message) {
            super(message);
        }
    }
}
