#include <stdio.h>

int flag;

int n1, n2, n3;

int nx;
void* lx;

#define write_int(i) printf("%d\n", i)
#define write_str(txt) printf("%s\n", txt)

int read_int() {
	printf("Enter number: ");
	scanf("%d", &nx);
	return nx;
}

#define push(d) stack[stack_ptr++] = d
#define pop() stack[--stack_ptr]

#define push_int(n) push((void*)(size_t)n)
#define push_lbl(l) push(&&l)

#define pop_int() nx = (int) (size_t) pop()
#define pop_lbl() lx = pop()

void* stack[1024];
int stack_ptr = 0;


#define test flag =
#define c_goto if(flag) goto
