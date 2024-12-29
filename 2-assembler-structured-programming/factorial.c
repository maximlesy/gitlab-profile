#include "header.h"
/*
# Factorial
Ask for a positive number (``int``) as input and output its factorial.

The factorial of a number n is n! with n! = n * (n-1) * ... * 3 * 2 * 1

For negative numbers the factorial is not defined. In this case you can
simply print `does not compute`.
*/

int main() {	
    // n1 = input, n2 = factorial, n3 = loop counter
    n1 = read_int();
    n2 = 1;
    n3 = 1;

    test n1 < 0; 
    c_goto does_not_compute;

	loop_start:
		test n3 > n1;
		c_goto end_loop;

		n2 *= n3;
		n3++;
		goto loop_start;

	end_loop:
		write_int(n2);
		goto end;

	does_not_compute:
		write_str("does not compute");

	end:
		return 0;
}
