package be.howest.ti.sd;

import java.util.ArrayList;
import java.util.List;

public class Frame {
    private final int frameNumber;
    private final List<Integer> pointsPerThrow;

    public Frame(int frameNumber) {
        this.frameNumber = frameNumber;
        this.pointsPerThrow = new ArrayList<>();
    }

    public List<Integer> getPointsPerThrow() {
        return pointsPerThrow;
    }
    public int getScore() {
        return pointsPerThrow.stream().reduce(0, Integer::sum);
    }
    public boolean isStrike() {
        return pointsPerThrow.contains(Settings.TOTAL_PINS);
    }

    public boolean isSpare() {
        return getPointsPerThrow().size() == Settings.STRIKE_BONUS_POINTS_ROLLS && getScore() == Settings.TOTAL_PINS;
    }
    public void addRoll(int pinsKnockedDown) {
        if (isFinalFrame() && (isStrike() || isSpare())) {
            this.pointsPerThrow.add(pinsKnockedDown);
        } else if (this.pointsPerThrow.size() < Settings.ROLLS_PER_FRAME) {
            this.pointsPerThrow.add(pinsKnockedDown);
        }
    }
    public boolean isComplete() {
        if (isFinalFrame()) {
            return isFinalFrameComplete();
        } else {
            return pointsPerThrow.size() == Settings.ROLLS_PER_FRAME || pointsPerThrow.contains(Settings.TOTAL_PINS);
        }
    }
    private boolean isFinalFrameComplete() {
        if (isStrike() || isSpare()) {
            return pointsPerThrow.size() == 3 || (pointsPerThrow.size() == 2 && getScore() < Settings.TOTAL_PINS);
        }
        return pointsPerThrow.size() == Settings.ROLLS_PER_FRAME;
    }
    public boolean isFinalFrame() {
        return frameNumber == Settings.MAX_FRAMES - 1;
    }

    public int getPinsRemaining() {
        if (isFinalFrame() && isStrike()) {
            return Settings.TOTAL_PINS;
        }
        return Settings.TOTAL_PINS - getScore();
    }
}