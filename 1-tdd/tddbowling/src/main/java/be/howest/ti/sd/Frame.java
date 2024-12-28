package be.howest.ti.sd;

import java.util.ArrayList;
import java.util.List;

public class Frame {
    private List<Integer> rolls;
    public Frame() {
        this.rolls = new ArrayList<>();
    }

    public boolean isComplete() {
        return rolls.size() == Settings.ROLLS_PER_FRAME || rolls.contains(Settings.TOTAL_PINS);
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

    public int getScore() {
        return rolls.stream().reduce(0, Integer::sum);
    }
}
