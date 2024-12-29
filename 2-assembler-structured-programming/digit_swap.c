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

    // n1 = input, n2 = output
    // n1 = read_int();

    // if (n1 >= 10 && n1 <= 99) {
    //     n2 = (10 * n1 - 1) % 99 + 1;
    // } else if (n1 <= -10 && n1 >= -99) {
    //     n2 = (10 * n1 + 1) % 99 - 1;
    // } else {
    //     n2 = n1;
    // }

    // write_int(n2);

    // Using the alternative approach this time because it needs more variables than the solution above
    // I only use n1, n2 and n3
    // n1 = input which is transformed into the output, n2 = right digit, n3 = left digit

    n1 = read_int();

    if ((n1 >= 10 && n1 <= 99) || (n1 <= -10 && n1 >= -99)) {
        int n2 = n1 % 10; // extract the right digit (5)
        int n3 = (n1 - n2) / 10; // extract the left digit (6)        
        n1 = ((n2 * 10) + n3); // *input becomes output*: multiply the right digit with 10 again and add the left number after it (56)
    }

    write_int(n1);

    return 0;
}

