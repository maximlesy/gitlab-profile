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
    int number;

    write_str("> Enter the n-th number you want of the Fibonnaci sequence. ");
    write_str("> The sequence is:   0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, ...");
    write_str("> The positions are: 0, 1, 2, 3, 4, 5, 6, 7,  8,  9,  10, 11, 12,  ...");

    number = read_int();
    int result = fibFast(number);
    write_int(result);

    return 0;
}

int fibFast(int number) {

    if (number == 0) {
        return 0;
    } else if (number == 1) {
        return 1;
    }

    int previous = 0, current = 1, next;
    for (int i = 2; i <= number; i++) {
        next = previous + current;
        previous = current;
        current = next;
    }
    return current;
}


