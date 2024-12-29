#include "header.h"
/*
# Factorial
Ask for a positive number (``int``) as input and output its factorial.

The factorial of a number n is n! with n! = n * (n-1) * ... * 3 * 2 * 1

For negative numbers the factorial is not defined. In this case you can
simply print `does not compute`.
*/

int main() {	

	//n1 = input, n2 = factorial, n3 = loop counter

	n1 = read_int();
	n2 = 1;

	if (n1 < 0) {
		write_str("does not compute");
		return 0;
	}

	for (n3 = 1; n3 <= n1; n3++) {
            n2 *= n3;
    }

    write_int(n2);
	
	return 0;
}
