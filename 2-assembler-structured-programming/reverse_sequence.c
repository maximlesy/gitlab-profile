#include "header.h"
/*
# Reverse Sequence
Write a program that reads five numbers (`int`) and
that outputs them in reverse order.

## Example:
### Input:
    1
    2
    3
    4
    5

### Output:
    5
    4
    3
    2
    1
*/

int main() {	
	int numbers[5];

    for (int i = 0; i < 5; i++) {
        numbers[i] = read_int();
    }

    write_str("Input:");
    for (int i = 0; i < 5; i++) {
        write_int(numbers[i]);
    }

    write_str("Output:");
    for (int i = 4; i >= 0; i--) {
        write_int(numbers[i]);
    }

    return 0;
}

