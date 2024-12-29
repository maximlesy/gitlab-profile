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
    // n1 = counter, n2 = limit
    n2 = 5;
    n1 = 0;

    loop_start_push:
        test n1 >= n2;
        c_goto end_push;

        push_int(read_int());
        n1++;
        goto loop_start_push;

    end_push:
        write_str("Output:");
        n1 = 0;

    loop_start_pop:
        test n1 >= n2;
        c_goto end;

        pop_int();
        write_int(nx);
        n1++;
        goto loop_start_pop;

    end:
        return 0;
}


