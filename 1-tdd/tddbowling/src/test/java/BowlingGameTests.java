import be.howest.ti.sd.BowlingGame;
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
    public void initialisingGame_StartsOnFrameOne() {
        //arrange
        int expectedFrame = 1;

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
    @CsvSource({"1,1", "2,2", "3,2", "4,3", "5,3", "6,4", "7,4"})
    public void whenRollingMoreThanTwice_GameMovesToNextFrame(int numberOfRolls, int expectedFrame) {

        for (int i = 0; i < numberOfRolls; i++) {
            bowlingGame.roll(0);
        }

        assertEquals(expectedFrame, bowlingGame.getCurrentFrame());
    }

}
