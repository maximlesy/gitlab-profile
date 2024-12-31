#include "header.h"
/*
# Recursion

Fibonacci was an Italian mathematician who lived around 1200 A.D..
He devised a sequence of numbers, called the Fibonacci-numbers which can easily expressed
as a "meervoudig functievoorschrift". We do not need to understand the implications, need or even mathematics.

We should however be able to translate this into a recursive JavaScript function.

<pre>
          /
          | 0, for n = 0
          |
fib(n) = <  1, for n = 1
          |
          | fib(n-1) + fib(n-2), else
          \
</pre>

For bigger numbers, this solution is correct but too slow.
Write a second version `fibFast` that uses a loop rather than recursion.
**Hint:** Search the internet for help.
**Hint:** Skip this *fast* exercise if you are running behind!


*/

int main() {
    write_str("> Enter the n-th number you want of the Fibonnaci sequence. ");
    write_str("> The sequence is:   0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, ...");
    write_str("> The positions are: 0, 1, 2, 3, 4, 5, 6, 7,  8,  9,  10, 11, 12,  ...");

    nx = read_int(); // index that is wanted of the sequence

    push_lbl(fibonacci);
    pop_lbl();
    goto *lx;

    fibonacci:
    test (nx == 0 || nx == 1);
    c_goto write_output;

    write_str("Calculating ...");
    n1 = 0; // previous
    n2 = 1; // current

    loop_start:
        test (nx < 2);
        c_goto end_loop;

        n3 = n1 + n2;
        n1 = n2;
        n2 = n3;
        nx--;
        goto loop_start;

    end_loop:
        nx = n2; // index becomes output: the Fibonacci sequence at that number

    write_output:
        write_int(nx);

    return 0;
}


