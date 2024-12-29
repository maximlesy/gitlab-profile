package be.howest.ti.sd;

import java.util.ArrayList;
import java.util.List;

public class Frame {
    private int frameNumber;
    private List<Integer> rolls;
    public Frame(int frameNumber) {
        this.frameNumber = frameNumber;
        this.rolls = new ArrayList<>();
    }

    public boolean isComplete() {
        if ((isFinalFrame() && wasStrike()) || (isFinalFrame() && isSpare())) {

            // Strike was thrown and we allowed for the extra roll
            if (rolls.size() == 3) {
                return true;
            }

            // Spare was thrown and we allowed for the extra roll
            if (rolls.size() == 2 && getScore() < Settings.TOTAL_PINS) {
                return true;
            }

            return false;

        } else {
            return rolls.size() == Settings.ROLLS_PER_FRAME || rolls.contains(Settings.TOTAL_PINS);
        }
    }

    public void addRoll(int pinsKnockedDown) {
        if(rolls.size() < Settings.ROLLS_PER_FRAME) {
            rolls.add(pinsKnockedDown);
        }
    }
    public List<Integer> getRolls() {
        return rolls;
    }
    public boolean wasStrike() {
        return rolls.contains(Settings.TOTAL_PINS);
    }

    public boolean isSpare() {
        return getRolls().size() == Settings.STRIKE_BONUS_POINTS_ROLLS && getScore() == Settings.TOTAL_PINS;
    }

    public int getScore() {
        return rolls.stream().reduce(0, Integer::sum);
    }

    private boolean isFinalFrame() {
        return frameNumber == Settings.MAX_FRAMES - 1;
    }
}
