#include "header.h"

int main() {	
	n1 = 1;
	n2 = 2;
	n3 = 4;
	nx = 5;

    write_int(n1);
    write_int(n2);
    write_int(n3);
    write_int(nx);

    write_str("push 6 ... pop ... check nx (was 5)!");
    push_int(6);
    pop_int();
    write_int(nx);

    return 0;
}

