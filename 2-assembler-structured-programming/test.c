#include "header.h"

int main() {

    // ERROR HERE:
    // expected an expressionC/C++(29)
    // #define push_lbl(l) push(&&l)
    // Expands to:
    // stack[stack_ptr++] = &&end
    push_lbl(end);
    

    loop_start_push:
            test n1 >= n2;
            c_goto end_push;

            push_int(read_int());
            n1++;
            goto loop_start_push;

    end_push:
        write_str("Output:");
        n1 = 0;

    print:
        write_str("print");
        goto end;

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

