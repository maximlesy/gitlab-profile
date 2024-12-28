import be.howest.ti.sd.BowlingGame;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.params.ParameterizedTest;
import org.junit.jupiter.params.provider.CsvSource;

import static org.junit.jupiter.api.Assertions.assertEquals;

public class BowlingGameTests {
    @Test
    public void initialisingGame_StartsWithTenPinsUp() {
        //arrange
        BowlingGame bowlingGame = new BowlingGame();
        int expectedPins = 10;

        //act
        int actualPins = bowlingGame.getPinsUp();

        //assert
        assertEquals(expectedPins, actualPins);
    }

    @Test
    public void knockingDownOnePin_DecreasesPinsByOne() {
        BowlingGame bowlingGame = new BowlingGame();
        int expectedPins = 9;

        bowlingGame.roll(1);
        int actualPins = bowlingGame.getPinsUp();

        assertEquals(expectedPins, actualPins);
    }

    @ParameterizedTest
    @CsvSource({"1,1", "2,2", "3,3", "4,4", "5,5", "6,6", "7,7", "8,8", "9,9", "10,10"})
    public void knockingDownPins_ReturnsCorrectScore(int pinsKnockedDown, int expectedScore) {
        BowlingGame bowlingGame = new BowlingGame();

        bowlingGame.roll(pinsKnockedDown);
        int actualScore = bowlingGame.score();

        assertEquals(expectedScore, actualScore);
    }

}
