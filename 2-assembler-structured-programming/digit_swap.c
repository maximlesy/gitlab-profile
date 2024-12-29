#include "header.h"
/*
# Digit Swap
Read one number (`int`) as input.

If the number has exactly two digits, the program swaps both digits.
Otherwise, the number is printed as is.
The sign of the number is **always** preserved.

**Non-functional requirement:** The input is a number, do not try to convert it to a string.
**Hint:** The integer division does not exist in JavaScript.
You can simulate an integer division, however, by doing a regular (decimal)
division, and then "round the result to the floor" (naar beneden afronden).
This can be done in JavaScript using `Math.floor(x/y)`.

## Examples:
    > 1234
    1234

    > -1234
    -1234

    > -4
    -4

    > 6
    6

    > 34
    43

    > -12
    -21

    > -70
    -7
*/

// Example (source: https://stackoverflow.com/questions/74311104/given-a-two-digit-integer-swap-its-digits-and-print-the-result-python)
// Positive two digit number:
// 10 * 34 - 1 = 339
// 339 % 99 = 42
// 42 + 1 = 43

// Negative two digit number:
// 10 * (-34) + 1 = -339
// -339 % 99 = -42
// -42 - 1 = -43

int main() {
    int number;
    int swappedNumber;

    number = read_int();

    if (number >= 10 && number <= 99) {
        swappedNumber = (10 * number - 1) % 99 + 1;
    } else if (number <= -10 && number >= -99) {
        swappedNumber = (10 * number + 1) % 99 - 1;
    } else {
        swappedNumber = number;
    }

    write_int(swappedNumber);

    // Alternative approach (own code base on https://codecrucks.com/program/program-to-swap-first-and-last-digit-of-a-number-using-while-loop/)
    
    // if ((number >= 10 && number <= 99) || (number <= -10 && number >= -99)) {
    //     int right = number % 10; // extract the right digit (5)
    //     int left = (number - right) / 10; // extract the left digit (6)        
    //     swappedNumber = ((right * 10) + left); // multiply the right digit with 10 again and add the left number after it (56)
    // } else {
    //     swappedNumber = number;
    // }

    // write_int(swappedNumber);

    return 0;
}

