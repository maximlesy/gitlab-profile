package be.howest.ti.sd.bowling;
import be.howest.ti.sd.utils.ScoreCalculator;
import be.howest.ti.sd.utils.Settings;
import be.howest.ti.sd.exceptions.RollException;

import java.util.*;

public class BowlingGame {
    private int pinsUp;
    private int currentFrame;
    private GameStatus gameStatus;
    private final List<Frame> frames;

    public BowlingGame() {
        this.currentFrame = 0;
        this.pinsUp = Settings.TOTAL_PINS;
        this.gameStatus = GameStatus.IN_PROGRESS;
        this.frames = new ArrayList<>();

        for (int i = 0; i < Settings.MAX_FRAMES; i++) {
            frames.add(new Frame(i));
        }
    }

    public int getPinsUp() {
        return pinsUp;
    }
    public int getCurrentFrame() {
        return currentFrame;
    }
    public Frame getActiveFrame() {
        return frames.get(currentFrame);
    }
    public GameStatus getGameStatus() {
        return gameStatus;
    }

    public void roll(int pinsToKnockDown) {
        verifyRoll(pinsToKnockDown);
        knockDownPins(pinsToKnockDown);
    }

    public int score() {
        return ScoreCalculator.calculateScore(frames);
    }

    private void knockDownPins(int pinsToKnockDown) {
        Frame nextThrowFrame = getActiveFrame();
        nextThrowFrame.addRoll(pinsToKnockDown);

        if (nextThrowFrame.isComplete()) {
            if (nextThrowFrame.isFinalFrame()) {
                gameStatus = GameStatus.FINISHED;
            } else {
                currentFrame++;
            }
        }

        nextThrowFrame = getActiveFrame();
        pinsUp = nextThrowFrame.getPinsRemaining();
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
}
