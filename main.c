#include <stdio.h>
#include "helpers/vector.h"
#include "compiler.h"
int main()
{
    printf("Hello world!\n");
    int res = compile_file("./test.c", "./test", 0);
    if (res == COMPILER_FILE_COMPILED_OK)
    {
        printf("everything compiled file\n");
    }
    else if(res == COMPILER_FAILED_WHIT_ERRORS)
    {
        printf("Compile failed\n");
    }
    else
    {
        printf("Unknown response for compile time\n");
    }
    return 0;
}