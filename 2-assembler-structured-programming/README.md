# C

Clone this repo and store (push) it to your personal git-group for this course.

## Compile

First, try to compile and run the first assignment `T1A7_reverse_sequence.c`.
On macos this is done using the following commands (if you have `gcc` installed)

```
gcc T1A7_reverse_sequence.c -o run
./run
```
in Visual Studio - Clone repository
```
compile with powershell: 
 cl T1A7_reverse_sequence.c
 run:
 ./T1A7_reverse_sequence
```


The first command **compiles** the c-file into an executable.
The second command **runs** the new executable.

The output of all given files is supposed to be *"end main"*.

If this works, you are ready to make the assignments.
Otherwise: google your way out of it: `how to compile and run a c-program on my device using my os`.

## Simple C

Now that you have your system up and running you can make the assignments.
Those are copy-pasted from *programming fundamentals* and thus should be rather easy for you.

Nice to know is that we give you some helper functions:

 - `read_int()` reads a single int from the command line, returns is (and stores it into the variable `nx`);
 - `write_int(i) ` writes a single int to the command line; and
 - `write_str(txt) ` writes a string (delimited by double quotes) to the command line (will be used for poor mans debugging only).

Make the four assignments, compile them, and try them out (I say try, not test as we do not have tests today).
 
Ready? Commit and push your solutions. You can also commit in between each exercise.
 
## Goodbye variables
 
Use the solutions from the previous step to start from.
Make the assignments again, but this time you are not allowed to make new variables. Instead you will have to make it work using `n1`,`n2`, and `n3` only. You can also use a fourth variable `nx`, but this one is a bit less flexible as some operations may update its contents.

We take away variables, but then we have to give you something in return to make it work:

 - `push_int(n)` adds a single int to an *invisible stack*; and
 -  `pop_int()` removes the last element from this stack and stores it in `nx`.

 **Hint/Remainder**: Watch out calling `pop_int()` puts a value in `nx` causing the old content te be gone. The same happens with calling `read_int()`!
 
You used an argument for your `fib` function, right? You cheater, arguments are (new) variables to. Make sure `fib` takes no arguments. And while you are on it. Make `fib` a void-function and find a way to pass the result in a different way.

## Goodbye if-statements.

Use the solutions from the previous step to start from.
Make the assignments again, but this time you are not allowed to use `if`-statements anymore.

We take away `if`-statements, but then we have to give you something in return to make it work:

- **Labels** In your code you can write on any line `someLabel:`. This is a location in your code where you can *jump* to.
- `goto someLabel;` is a goto-statement, which causes your program to continue its execution on the line where the label can be found.
- `test <some condition>` computes some condition and stores the result in *an invisible flag variable*.
- `c_goto someLabel;` is a conditional goto-statement, which causes your program to continue its execution on the line where the label can be found **if** the last time test was executed the invisible flag variable was set to a true-like value.

Note that if you execute two test-statements in a row, the result of the first one is gone. Conversely, if you call `c_goto` without a preceding test, the flag from the last test is used.

## Goodbye loop-statements.

Use the solutions from the previous step to start from.
Make the assignments again, but this time you are not allowed to use `for/while/dowhile/...`-statements anymore.

## Goodbye level-two ops.

Use the solutions from the previous step to start from.
Make the assignments again, but this time you are not allowed to use the `*`-operator, `/`-operator, nor the `%`-operator.

## Goodbye functions

Use the solutions from the previous step to start from.
Make the assignments again, but this time you are not allowed to use functions anymore.

We take away functions, but then we have to give you something in return to make it work:

- `push_lbl(someLabel)` adds the label `someLabel` to the stack.
- `pop_lbl()` removes the last element from this stack and stores it in `lx`. **Watch out** make sure that the top element of the stack is a label. If it is an int ... then you are on your own.
- The variable `lx` can only contain labels. To use it in a goto, write `goto *lx;` (**Mind the asterisk**).
- The variable `lx` can only contain labels. To use it in a conditional goto, write `c_goto *lx;` (**Mind the asterisk**).

## Digit swap.

Now, make a new assignment and write directly in the style of the last step.

Write the program that reads an int from the command line and that swaps al digits: 1234 becomes 4321.
You can ignore negative numbers if you like.
