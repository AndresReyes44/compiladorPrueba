#include "compiler.h"
#include <stdarg.h>
#include <stdlib.h>

struct lex_process_function lex_process_function = {
    .next_char = compile_process_next_char,
    .peek_char = compile_process_peek_char,
    .push_char = compile_process_push_char
};

void compiler_error(struct compile_process* process, const char* msg, ...)
{
    va_list args;
    va_start(args, msg);
    vfprintf(stderr, msg, args);
    va_end(args);

    fprintf(stderr, " on line %i, col %i in file %s\n", process->pos.line, process->pos.col, compiler->pos.filename);
    exit(1);
}

void compiler_warning(struct compile_process* process, const char* msg, ...)
{
    va_list args;
    va_start(args, msg);
    vfprintf(stderr, msg, args);
    va_end(args);
    fprintf(stderr, " on line %i, col %i in file %s\n", process->pos.line, process->pos.col, compiler->pos.filename);
    exit(1);
}

int compile_file(const char* filename, const char* out_filename, int flags)
{
    struct compile_process* process = compile_process_create(filename, out_filename, flags);
    if (!process)
        return COMPILER_FAILED_WHIT_ERRORS;

    //Aqui se realiza el lexical analysis
    struct lex_process* lex_process = lex_process_create(process, &compiler_lex_function, NULL);
    if (!lex_process)
    {
        return COMPILER_FAILED_WHIT_ERRORS;
    }

    process->token_vec = lex_process->token_vec;

    if (lex(lex_process) != LEXICAL_ANALYSIS_OK)
    {
     
        return COMPILER_FAILED_WHIT_ERRORS;
    }

    
    //Aqui se realiza el parce

    //Aqui la generacion de codigo

    return COMPILER_FILE_COMPILED_OK;
}