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

    //n1 = counter, n2 = limit
    n2 = 5;
    for (n1 = 0; n1 < n2; n1++) {
        push_int(read_int());
    }

    write_str("Output:");
    for (n1 = 0; n1 < n2; n1++) {
        pop_int();
        write_int(nx);
    }

    return 0;
}

