import be.howest.ti.sd.BowlingGame;
import org.junit.jupiter.api.Test;
import static org.junit.jupiter.api.Assertions.assertEquals;

public class BowlingGameTests {
    @Test
    public void initialisingGame_StartsWithTenPinsUp() {
        //arrange
        BowlingGame bowlingGame = new BowlingGame();
        int expectedPins = 10;

        //act
        int actualPins = bowlingGame.getPins();

        //assert
        assertEquals(expectedPins, actualPins);
    }

    @Test
    public void knockingDownOnePin_DecreasesPinsByOne() {
        BowlingGame bowlingGame = new BowlingGame();
        int expectedPins = 9;

        bowlingGame.roll(1);
        int actualPins = bowlingGame.getPins();

        assertEquals(expectedPins, actualPins);
    }
    
}
