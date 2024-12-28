package be.howest.ti.sd;

import java.util.List;

public class ScoreCalculator {
    public static int calculateScore(List<Frame> frames) {
        int totalScore = 0;
        int frameIndex = 0;

        while (frameIndex < frames.size()) {
            Frame currentFrame = frames.get(frameIndex);
            totalScore += currentFrame.getScore();

            if (currentFrame.wasStrike()) {
                totalScore += getBonus(frames, frameIndex, Settings.STRIKE_BONUS_POINTS_ROLLS);
                frameIndex++;
            } else if (isSpare(currentFrame)) {
                totalScore += getBonus(frames, frameIndex, Settings.SPARE_BONUS_POINTS_ROLLS);
                frameIndex++;
            } else {
                frameIndex++;
            }
        }

        return totalScore;
    }

    private static int getBonus(List<Frame> frames, int frameIndex, int rollsToCount) {
        int bonus = 0;
        int rollsCounted = 0;
        int nextFrameIndex = frameIndex + 1;

        while (rollsCounted < rollsToCount && nextFrameIndex < frames.size()) {
            List<Integer> nextRolls = frames.get(nextFrameIndex).getRolls();
            for (int roll : nextRolls) {
                if (rollsCounted < rollsToCount) {
                    bonus += roll;
                    rollsCounted++;
                } else {
                    break;
                }
            }
            nextFrameIndex++;
        }

        return bonus;
    }

    private static boolean isSpare(Frame frame) {
        return frame.getRolls().size() == Settings.STRIKE_BONUS_POINTS_ROLLS && frame.getScore() == Settings.TOTAL_PINS;
    }
}
