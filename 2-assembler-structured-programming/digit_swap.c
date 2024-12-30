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

int main() {
    n1 = read_int();

    test ((n1 < 10 || n1 > 99) && (n1 > -10 || n1 < -99));
    c_goto end;

    write_str("Performing transformation");

    // Extract the right digit (n1 % 10)
    n2 = n1;
    extract_right_digit:
        test n2 < 10 && n2 > -10;
        c_goto right_digit_extracted;
        test n2 >= 10;
        c_goto subtract_ten;
        test n2 <= -10;
        c_goto add_ten;

    subtract_ten:
        n2 -= 10;
        goto extract_right_digit;

    add_ten:
        n2 += 10;
        goto extract_right_digit;

    right_digit_extracted:

        // Extract the left digit ((n1 - n2) / 10)
        n3 = n1 - n2;
        n1 = 0;
    divide_by_ten:
        test n3 == 0;
        c_goto left_digit_extracted;
        test n3 > 0;
        c_goto subtract_ten_from_n3;
        test n3 < 0;
        c_goto add_ten_to_n3;

    subtract_ten_from_n3:
        n3 -= 10;
        n1++;
        goto divide_by_ten;

    add_ten_to_n3:
        n3 += 10;
        n1--;
        goto divide_by_ten;

    left_digit_extracted:
        n3 = n1;

        // Multiply the right digit by 10 and add the left digit
        n1 = 0;
        n2 = n2; // Store the original right digit in n2
    multiply_by_ten:
        test n1 == 10;
        c_goto multiplication_done;
        n1++;
        n3 += n2;
        goto multiply_by_ten;

    multiplication_done:
        n1 = n3;

    end:
        write_int(n1);
        return 0;
}

// KEEPING ALTERNATIVE SOLUTION FOR REFERENCE 

// Example (source: https://stackoverflow.com/questions/74311104/given-a-two-digit-integer-swap-its-digits-and-print-the-result-python)
// Positive two digit number:
// 10 * 34 - 1 = 339
// 339 % 99 = 42
// 42 + 1 = 43

// Negative two digit number:
// 10 * (-34) + 1 = -339
// -339 % 99 = -42
// -42 - 1 = -43

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

