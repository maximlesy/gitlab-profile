import be.howest.ti.sd.BowlingGame;
import be.howest.ti.sd.GameStatus;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.params.ParameterizedTest;
import org.junit.jupiter.params.provider.CsvSource;

import static org.junit.jupiter.api.Assertions.assertEquals;
import static org.junit.jupiter.api.Assertions.assertThrows;

public class BowlingGameTests {

    private BowlingGame bowlingGame;

    @BeforeEach
    public void setUp() {
        bowlingGame = new BowlingGame();
    }

    @Test
    public void initialisingGame_StartsWithTenPinsUp() {
        //arrange
        int expectedPins = 10;

        //act
        int actualPins = bowlingGame.getPinsUp();

        //assert
        assertEquals(expectedPins, actualPins);
    }

    @Test
    public void initialisingGame_StartsOnFrameZero() {
        //arrange
        int expectedFrame = 0;

        //act
        int actualFrame = bowlingGame.getCurrentFrame();

        //assert
        assertEquals(expectedFrame, actualFrame);
    }

    @Test
    public void knockingDownOnePin_DecreasesPinsByOne() {
        int expectedPins = 9;
        int pinsKnockedDown = 1;

        bowlingGame.roll(pinsKnockedDown);
        int actualPins = bowlingGame.getPinsUp();

        assertEquals(expectedPins, actualPins);
    }

    @ParameterizedTest
    @CsvSource({"1,1", "2,2", "3,3", "4,4", "5,5", "6,6", "7,7", "8,8", "9,9", "10,10"})
    public void knockingDownPins_ReturnsCorrectScore(int pinsKnockedDown, int expectedScore) {
        bowlingGame.roll(pinsKnockedDown);
        int actualScore = bowlingGame.score();

        assertEquals(expectedScore, actualScore);
    }

    @Test
    public void knockingDownTooManyPins_ThrowsRollException() {
        assertThrows(BowlingGame.RollException.class, () -> bowlingGame.roll(11));
    }

    @Test
    public void knockingDownNegativePins_ThrowsRollException() {
        assertThrows(BowlingGame.RollException.class, () -> bowlingGame.roll(-1));
    }

    @ParameterizedTest
    @CsvSource({"1,0", "2,1", "3,1", "4,2", "5,2", "6,3", "7,3"})
    public void whenRollingMoreThanTwice_GameMovesToNextFrame(int numberOfRolls, int expectedFrame) {

        for (int i = 0; i < numberOfRolls; i++) {
            bowlingGame.roll(0);
        }

        assertEquals(expectedFrame, bowlingGame.getCurrentFrame());
    }

    @Test
    public void rollingTwentyTimes_EndsGame() {
        int numberOfRolls = 20;
        GameStatus expectedGameStatus = GameStatus.FINISHED;

        for (int i = 0; i < numberOfRolls; i++) {
            bowlingGame.roll(0);
        }

        assertEquals(expectedGameStatus, bowlingGame.getGameStatus());
    }

    @Test
    public void rollingWhenGameHasEnded_ThrowsRollException() {
        int numberOfRolls = 20;

        for (int i = 0; i < numberOfRolls; i++) {
            bowlingGame.roll(0);
        }

        assertThrows(BowlingGame.RollException.class, () -> bowlingGame.roll(0));
    }

    @Test
    public void knockingDownTenPinsOnFirstRoll_ImmediatelyMovesToNextFrame() {
        int pinsKnockedDown = 10;
        int expectedFrame = 1;

        bowlingGame.roll(pinsKnockedDown);
        int actualFrame = bowlingGame.getCurrentFrame();

        assertEquals(expectedFrame, actualFrame);
    }

    @Test
    public void throwingMultipleStrikesInARow_MovesMultipleFrames() {
        int expectedFrame = 3;

        bowlingGame.roll(10);
        bowlingGame.roll(10);
        bowlingGame.roll(10);
        int actualFrame = bowlingGame.getCurrentFrame();
        
        assertEquals(expectedFrame, actualFrame);
    }

    @Test
    public void whenAStrikeWasThrown_TheScoreOfTheNextFrameIsAddedAsBonus() {

        int expectedScore = 20; //10 (strike) + 5 bonus (from frame 2) + 5 points in frame 2

        bowlingGame.roll(10); // strike in frame 1
        bowlingGame.roll(2); // first roll in frame 2 knocks down 2 pins
        bowlingGame.roll(3); // second roll in frame 2 knocks down 3 pins

        int actualScore = bowlingGame.score();

        assertEquals(expectedScore, actualScore);
    }

    @Test
    public void whenMultipleStrikesAreThrown_TheScoresOfTheNextTwoFramesWereAdded() {
        int expectedScore = 90;

        bowlingGame.roll(10); // strike in frame 1 - 10 points (+ 10 bonus frame 2 + 10 bonus frame 3)
        bowlingGame.roll(10); // strike in frame 2 - 10 points (+ 10 bonus frame 3 + 10 bonus frame 4)
        bowlingGame.roll(10); // strike in frame 3 - 10 points (+ 10 bonus frame 4)
        bowlingGame.roll(10); // strike in frame 4 - 10 points (no bonus yet)

        int actualScore = bowlingGame.score();

        assertEquals(expectedScore, actualScore);
    }

    @Test
    public void whenASpareWasThrown_TheScoreOfTheNextRollIsAddedAsBonus() {
        int expectedScore = 18; // 5 (first roll in frame 1) + 5 (second roll in frame 1) + 2 (bonus from frame 2) + 6 (total points in frame 2)

        bowlingGame.roll(5); // 5 points in frame 1
        bowlingGame.roll(5); // 10 points in frame 1, spare
        bowlingGame.roll(2); // 2 points in frame 2, these points should be added as bonus in frame 1
        bowlingGame.roll(4); // extra roll in frame 2, this one can not be accounted for in the score

        int actualScore = bowlingGame.score();

        assertEquals(expectedScore, actualScore);
    }

}
