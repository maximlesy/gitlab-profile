package be.howest.ti.sd.utils;

import be.howest.ti.sd.bowling.Frame;

import java.util.List;

public class ScoreCalculator {
    public static int calculateScore(List<Frame> frames) {
        int totalScore = 0;
        int frameIndex = 0;

        while (frameIndex < frames.size()) {
            Frame currentFrame = frames.get(frameIndex);
            totalScore += currentFrame.getScore();

            if (currentFrame.isStrike()) {
                totalScore += getBonus(frames, frameIndex, Settings.STRIKE_BONUS_POINTS_ROLLS);
                frameIndex++;
            } else if (currentFrame.isSpare()) {
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
            List<Integer> nextRolls = frames.get(nextFrameIndex).getPointsPerThrow();
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
}
