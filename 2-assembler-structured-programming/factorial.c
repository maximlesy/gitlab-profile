#include "header.h"
/*
# Factorial
Ask for a positive number (``int``) as input and output its factorial.

The factorial of a number n is n! with n! = n * (n-1) * ... * 3 * 2 * 1

For negative numbers the factorial is not defined. In this case you can
simply print `does not compute`.
*/

int main() {	
	int number;
	unsigned long long factorial = 1;

	number = read_int();

	if (number < 0) {
		write_str("does not compute");
		return 0;
	}

	for (int i = 1; i <= number; i++) {
            factorial *= (unsigned long long)i;
    }

    printf("%llu\n", factorial); // not using write_str because of compiler warnings
	
	return 0;
}
