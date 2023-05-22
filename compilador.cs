/*using System;
using System.IO;
using System.Collections.Generic;

namespace Compilador
{
    class program
    {
        static void Main(string[]args)
        {
            string filename = "program.txt";
            StreamReader input = new StreamReader(filename);
            
        }

    public class AnalizadorLexico {
    public List<Token> analizar(string codigoFuente) {
        List<Token> listaTokens = new List<Token>();

        // Aquí es donde se realizará la lógica para analizar el código fuente

        return listaTokens;
    }
    public enum TipoToken {
    Identificador,
    NumeroEntero,
    NumeroDecimal,
    Cadena,
    Comentario,
    Simbolo
    }

    public class Token {
    public TipoToken Tipo { get; set; }
    public string Valor { get; set; }
    }

    }
    }
    public enum TipoToken {
    Identificador,
    NumeroEntero,
    NumeroDecimal,
    Cadena,
    Comentario,
    Simbolo
}

public class Token {
    public TipoToken Tipo { get; set; }
    public string Valor { get; set; }
}
public enum TipoToken {
    Identificador,
    NumeroEntero,
    NumeroDecimal,
    Cadena,
    Comentario,
    Simbolo
}

public class Token {
    public TipoToken Tipo { get; set; }
    public string Valor { get; set; }
}
public List<Token> analizar(string codigoFuente) {
    List<Token> listaTokens = new List<Token>();
    int estadoActual = 0;
    string lexema = "";

    for (int i = 0; i < codigoFuente.Length; i++) {
    char caracterActual = codigoFuente[i];
    int columna = obtenerColumna(caracterActual);

    if (columna == -1) {
        // Caracter desconocido, error léxico
        estadoActual = 37;
        lexema += caracterActual;
    } else {
        int estadoSiguiente = tablaTransiciones[estadoActual, columna];

        if (estadoSiguiente == 42) {
            // Error léxico
            listaTokens.Add(new Token { Tipo = TipoToken.Simbolo, Valor = lexema });
            lexema = caracterActual.ToString();
            estadoActual = 0;
            columna = obtenerColumna(caracterActual);
            estadoSiguiente = tablaTransiciones[estadoActual, columna];
        }

        if (estadoSiguiente >= 1 && estadoSiguiente <= 8) {
            // Identificador
            lexema += caracterActual;
            estadoActual = estadoSiguiente;
        } else if (estadoSiguiente >= 13 && estadoSiguiente <= 16) {
            // Número entero o decimal
            lexema += caracterActual;
            estadoActual = estadoSiguiente;
        } else if (estadoSiguiente == 19 || estadoSiguiente == 21 || estadoSiguiente == 23 ||
                   estadoSiguiente == 25 || estadoSiguiente == 26 || estadoSiguiente == 27 ||
                   estadoSiguiente == 28 || estadoSiguiente == 29 || estadoSiguiente == 30 ||
                   estadoSiguiente == 31 || estadoSiguiente == 32 || estadoSiguiente == 33 ||
                   estadoSiguiente == 34 || estadoSiguiente == 35 || estadoSiguiente == 36) {
            // Símbolos
            if (lexema != "") {
                listaTokens.Add(new Token { Tipo = obtenerTipoToken(estadoActual), Valor = lexema });
                lexema = "";
            }
            listaTokens.Add(new Token { Tipo = obtenerTipoToken(estadoSiguiente), Valor = caracterActual.ToString() });
            estadoActual = 0;
        } else if (estadoSiguiente == 10 || estadoSiguiente == 11 || estadoSiguiente == 12) {
            // Palabra reservada o booleano
            if (lexema != "") {
                listaTokens.Add(new Token { Tipo = obtenerTipoToken(estadoActual), Valor = lexema });
                lexema = "";
            }
            listaTokens.Add(new Token { Tipo = obtenerTipoToken(estadoSiguiente), Valor = caracterActual.ToString() });
            estadoActual = 0;
        }
    }
}

// Si hay un lexema sin agregar, lo agrega a la lista de tokens
if (lexema != "") {
    listaTokens.Add(new Token { Tipo = obtenerTipoToken(estadoActual), Valor = lexema });
}

return listaTokens;
}
public class Token
{
    public TokenType Type { get; set; }
    public string Value { get; set; }
}

public enum TokenType
{
    Identifier,
    String,
    Int,
    Float,
    LessThan,
    LessThanOrEqual,
    GreaterThan,
    GreaterThanOrEqual,
    Assign,
    Equal,
    NotEqual,
    Plus,
    Minus,
    Multiply,
    Semicolon,
    Comma,
    LeftParenthesis,
    RightParenthesis,
    LeftBracket,
    RightBracket,
    LeftBrace,
    RightBrace,
    InvalidSymbol
}

}*/
/*
using System;
using System.IO;
using System.Collections.Generic;

namespace Compilador
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = "program.txt";
            using (StreamReader input = new StreamReader(filename))
            {
                AnalizadorLexico analizador = new AnalizadorLexico();
                List<Token> tokens = new List<Token>();

                string linea;
                while ((linea = input.ReadLine()) != null)
                {
                    List<Token> tokensLinea = analizador.analizar(linea);
                    tokens.AddRange(tokensLinea);
                }

                // Imprime la lista de tokens
                foreach (Token token in tokens)
                {
                    Console.WriteLine("{0}\t{1}", token.Tipo, token.Valor);
                }
            }
        }

        public class AnalizadorLexico
        {
            {
                private int[,] tablaTransiciones = new int[,] {
                // Estados
                // 0 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30 31 32 33 34 35 36 37 38 39 40 41 42
                {1,3,0,9,10,11,12,26,27,28,6,29,30,31,32,33,34,35,36,2,42,37},
                {1,	1,	13,	13,	13,	13,	13,	13,	13,	13,	13,	13,	13,	13,	13,	13,	13,	13,	13,	38, 38, 37},
                {2,	2,	2,	2,	2,	2,	2,	2,	2,	2,	2,	2,	2,	2,	2,	2,	2,	2,	2,	14,	2,	2},
                {39, 3,	15,	15,	15,	15,	15,	15,	15,	15,	15,	15,	15,	15,	15,	15,	15,	15,	15,	38,	4,	37},
                {39,	5,	39,	39,	39,	39,	39,	39,	39,	39,	39,	39,	39,	39,	39,	39,	39,	39,	39,	39,	39,	37},
                {39,	5,	16,	16,	16,	16,	16,	16,	16,	16,	16,	16,	16,	16,	16,	16,	16,	16,	16,	39,	39,	37},
                {17,	17,	17,	41,	41,	41,	41,	41,	41,	7,	41,	41,	41,	17,	41,	17,	41,	41,	41,	41,	41,	37},
                {7,	7,	7,	7,	7,	7,	7,	7,	7,	8,	7,	7,	7,	7,	7,	7,	7,	7,	7,	7,	7,	7},
                {7,	7,	7,	7,	7,	7,	7,	7,	7,	7,	18,	7,	7,	7,	7,	7,	7,	7,	7,	7,	7,	7},
                {19,	19,	19,	42,	42,	20,	42,	19,	19,	42,	42,	42,	42,	19,	42,	19,	42,	42,	42,	42,	42,	37},
                {23,	23,	23,	42,	42,	24,	42,	23,	23,	42,	42,	42,	42,	23,	42,	23,	42,	23,	42,	21,	42,	37},
                {42,	42,	42,	42,	42,	25,	42,	42,	42,	42,	42,	42,	42,	42,	42,	42,	42,	42,	42,	42,	42,	37},
                {13,	13,	13,	13,	13,	13,	13,	13,	13,	13,	13,	13,	13,	13,	13,	13,	13,	13,	13,	13,	13,	13},
                {14,	14,	14,	14,	14,	14,	14,	14,	14,	14,	14,	14,	14,	14,	14,	14,	14,	14,	14,	14,	14,	14},
                {15,	15,	15,	15,	15,	15,	15,	15,	15,	15,	15,	15,	15,	15,	15,	15,	15,	15,	15,	15,	15,	15},
                {16,	16,	16,	16,	16,	16,	16,	16,	16,	16,	16,	16,	16,	16,	16,	16,	16,	16,	16,	16,	16,	16},
                {17,	17,	17,	17,	17,	17,	17,	17,	17,	17,	17,	17,	17,	17,	17,	17,	17,	17,	17,	17,	17,	17},
                {18,	18,	18,	18,	18,	18,	18,	18,	18,	18,	18,	18,	18,	18,	18,	18,	18,	18,	18,	18,	18,	18},
                {19,	19,	19,	19,	19,	19,	19,	19,	19,	19,	19,	19,	19,	19,	19,	19,	19,	19,	19,	19,	19,	19},
                {20,	20,	20,	20,	20,	20,	20,	20,	20,	20,	20,	20,	20,	20,	20,	20,	20,	20,	20,	20,	20,	20},
                {21,	21,	21,	21,	21,	21,	21,	21,	21,	21,	21,	21,	21,	21,	21,	21,	21,	21,	21,	21,	21,	21},
                {22,	22,	22,	22,	22,	22,	22,	22,	22,	22,	22,	22,	22,	22,	22,	22,	22,	22,	22,	22,	22,	22},
                {23,	23,	23,	23,	23,	23,	23,	23,	23,	23,	23,	23,	23,	23,	23,	23,	23,	23,	23,	23,	23,	23},
                {24,	24,	24,	24,	24,	24,	24,	24,	24,	24,	24,	24,	24,	24,	24,	24,	24,	24,	24,	24,	24,	24},
                {25,	25,	25,	25,	25,	25,	25,	25,	25,	25,	25,	25,	25,	25,	25,	25,	25,	25,	25,	25,	25,	25},
                {26,	26,	26,	26,	26,	26,	26,	26,	26,	26,	26,	26,	26,	26,	26,	26,	26,	26,	26,	26,	26,	26},
                {27,	27,	27,	27,	27,	27,	27,	27,	27,	27,	27,	27,	27,	27,	27,	27,	27,	27,	27,	27,	27,	27},
                {28,	28,	28,	28,	28,	28,	28,	28,	28,	28,	28,	28,	28,	28,	28,	28,	28,	28,	28,	28,	28,	28},
                {29,	29,	29,	29,	29,	29,	29,	29,	29,	29,	29,	29,	29,	29,	29,	29,	29,	29,	29,	29,	29,	29},
                {30,	30,	30,	30,	30,	30,	30,	30,	30,	30,	30,	30,	30,	30,	30,	30,	30,	30,	30,	30,	30,	30},
                {31,	31,	31,	31,	31,	31,	31,	31,	31,	31,	31,	31,	31,	31,	31,	31,	31,	31,	31,	31,	31,	31},
                {32,	32,	32,	32,	32,	32,	32,	32,	32,	32,	32,	32,	32,	32,	32,	32,	32,	32,	32,	32,	32,	32},
                {33,	33,	33,	33,	33,	33,	33,	33,	33,	33,	33,	33,	33,	33,	33,	33,	33,	33,	33,	33,	33,	33},
                {34,	34,	34,	34,	34,	34,	34,	34,	34,	34,	34,	34,	34,	34,	34,	34,	34,	34,	34,	34,	34,	34},
                {35,	35,	35,	35,	35,	35,	35,	35,	35,	35,	35,	35,	35,	35,	35,	35,	35,	35,	35,	35,	35,	35},
                {36,	36,	36,	36,	36,	36,	36,	36,	36,	36,	36,	36,	36,	36,	36,	36,	36,	36,	36,	36,	36,	36},
                {37,	37,	37,	37,	37,	37,	37,	37,	37,	37,	37,	37,	37,	37,	37,	37,	37,	37,	37,	37,	37,	37},
                {38,	38,	38,	38,	38,	38,	38,	38,	38,	38,	38,	38,	38,	38,	38,	38,	38,	38,	38,	38,	38,	38},
                {39,	39,	39,	39,	39,	39,	39,	39,	39,	39,	39,	39,	39,	39,	39,	39,	39,	39,	39,	39,	39,	39},
                {40,	40,	40,	40,	40,	40,	40,	40,	40,	40,	40,	40,	40,	40,	40,	40,	40,	40,	40,	40,	40,	40},
                {41,	41,	41,	41,	41,	41,	41,	41,	41,	41,	41,	41,	41,	41,	41,	41,	41,	41,	41,	41,	41,	41},
                {42,	42,	42,	42,	42,	42,	42,	42,	42,	42,	42,	42,	42,	42,	42,	42,	42,	42,	42,	42,	42,	42}
                */
using System;
using System.IO;
using System.Collections.Generic;

namespace Compilador
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = "program.txt";
            using (StreamReader input = new StreamReader(filename))
            {
                AnalizadorLexico analizador = new AnalizadorLexico();
                List tokens = new List();

                            string linea;

            while ((linea = input.ReadLine()) != null)
            {
                List<Token> tokensLinea = analizador.Analizar(linea);
                tokens.AddRange(tokensLinea);
            }

            // Do something with the tokens
        }
    }
}

public class AnalizadorLexico
{
    private int[,] tablaTransiciones = new int[,]
    {
        // The transition table
    };

    public List<Token> Analizar(string codigoFuente)
    {
        List<Token> listaTokens = new List<Token>();
        int estadoActual = 0;
        string lexema = "";

        for (int i = 0; i < codigoFuente.Length; i++)
        {
            char caracterActual = codigoFuente[i];
            int columna = ObtenerColumna(caracterActual);

            if (columna == -1)
            {
                // Caracter desconocido, error léxico
                estadoActual = 37;
                lexema += caracterActual;
            }
            else
            {
                int estadoSiguiente = tablaTransiciones[estadoActual, columna];

                if (estadoSiguiente == 42)
                {
                    // Error léxico
                    listaTokens.Add(new Token { Tipo = TipoToken.Simbolo, Valor = lexema });
                    lexema = caracterActual.ToString();
                    estadoActual = 0;
                    columna = ObtenerColumna(caracterActual);
                    estadoSiguiente = tablaTransiciones[estadoActual, columna];
                }

                if (estadoSiguiente >= 1 && estadoSiguiente <= 8)
                {
                    // Identificador
                    lexema += caracterActual;
                    estadoActual = estadoSiguiente;
                }
                else if (estadoSiguiente >= 13 && estadoSiguiente <= 16)
                {
                    // Número entero o decimal
                    lexema += caracterActual;
                    estadoActual = estadoSiguiente;
                }
                else if (estadoSiguiente == 19 || estadoSiguiente == 21 || estadoSiguiente == 23 ||
                        estadoSiguiente == 25 || estadoSiguiente == 26 || estadoSiguiente == 27 ||
                        estadoSiguiente == 28 || estadoSiguiente == 29 || estadoSiguiente == 30 ||
                        estadoSiguiente == 31 || estadoSiguiente == 32 || estadoSiguiente == 33 ||
                        estadoSiguiente == 34 || estadoSiguiente == 35 || estadoSiguiente == 36)
                {
                    // Símbolos
                    if (lexema != "")
                    {
                        listaTokens.Add(new Token { Tipo = ObtenerTipoToken(estadoActual), Valor = lexema });
                        lexema = "";
                    }
                    listaTokens.Add(new Token { Tipo = ObtenerTipoToken(estadoSiguiente), Valor = caracterActual.ToString() });
                    estadoActual = 0;
                }
                else if (estadoSiguiente >= 10 && estadoSiguiente <= 12)
                {
                    // Palabra reservada o booleano
                    if (lexema != "")
                    {
                        listaTokens.Add(new Token { Tipo = ObtenerTipoToken(estadoActual), Valor = lexema });
                        lexema = "";
                 }
                    listaTokens.Add(new Token { Tipo = ObtenerTipoToken(estadoSiguiente), Valor = caracterActual.ToString() });
                    estadoActual = 0;
                    }
                     else if (estadoSiguiente == 10 || estadoSiguiente == 11 || estadoSiguiente == 12)
                {
                    // Palabra reservada o booleano
                    if (lexema != "")
                    {
                        listaTokens.Add(new Token { Tipo = ObtenerTipoToken(estadoActual), Valor = lexema });
                        lexema = "";
                    }
                    listaTokens.Add(new Token { Tipo = ObtenerTipoToken(estadoSiguiente), Valor = caracterActual.ToString() });
                    estadoActual = 0;
                }
                    else if (estadoSiguiente == 0)
                    {
                        // Espacio en blanco o fin de línea, ignorar
                        if (lexema != "")
                {
                    listaTokens.Add(new Token { Tipo = ObtenerTipoToken(estadoActual), Valor = lexema });
                    lexema = "";
                }
                estadoActual = 0;
            }
            else
            {
                // Error léxico
                estadoActual = 37;
                lexema += caracterActual;
            }
        }
    }


             // Agregar el último token
    if (lexema != "")
    {
        listaTokens.Add(new Token { Tipo = ObtenerTipoToken(estadoActual), Valor = lexema });
    }

    return listaTokens;
}

        private int ObtenerColumna(char c)
{
    if (char.IsLetter(c))
    {\n        return 0;
    }

    if (char.IsDigit(c))
    {
        return 1;
    }

    switch (c)
    {
        case ' ':
        case '\t':
        case '\r':
        case '\n':
            return 2;
        case '+':
        case '-':
        case '*':
        case '/':
            return 3;
        case '=':
        case '<':\n        case '>':
            return 4;
        case '!':
        case '&':
        case '|':
            return 5;
        case '(':
        case ')':
        case '{':
        case '}':
        case '[':
        case ']':
        case ',':
        case '.':
        case ';':
            return 6;
        default:
            return -1;
    }
}


        private TipoToken ObtenerTipoToken(int estado)
        {
            switch (estado)
            {
                case 1:
                    return TipoToken.Identificador;
                case 2:
                    return TipoToken.PalabraReservada;
                case 3:
                case 4:
                    return TipoToken.NumeroEntero;
                case 5:
                    return TipoToken.NumeroDecimal;
                case 13:
                case 15:
                    return TipoToken.Simbolo;
                case 16:
                    return TipoToken.Booleano;
                case 19:
                    return TipoToken.Suma;
                case 21:
                    return TipoToken.Resta;
                case 23:
                    return TipoToken.Multiplicacion;
                case 25:
                    return TipoToken.Division;
                case 26:
                    return TipoToken.Asignacion;
                case 27:
                    return TipoToken.MenorQue;
                case 28:
                    return TipoToken.MayorQue;
                case 29:
                    return TipoToken.MenorIgualQue;
                case 30:
                    return TipoToken.MayorIgualQue;
                case 31:
                    return TipoToken.Igual;
                case 32:
                    return TipoToken.Diferente;
                case 33:
                    return TipoToken.YLogico;
                case 34:
                    return TipoToken.OLogico;
                case 35:
                    return TipoToken.Negacion;
                default:
                    return TipoToken.Desconocido;
            }
        }
    }

    public class Token
    {
        public TipoToken Tipo { get; set; }
        public string Valor { get; set; }
    }

    public enum TipoToken
    {
        Identificador,
        Entero,
        Decimal,
        OperadorSuma,
        OperadorResta,
        OperadorMultiplicacion,
        OperadorDivision,
        OperadorAsignacion,
        OperadorMenorQue,
        OperadorMayorQue,
        OperadorMenorIgual,
        OperadorMayorIgual,
        OperadorIgualdad,
        OperadorDesigualdad,
        OperadorAnd,
        OperadorOr,
        ParentesisAbierto,
        ParentesisCerrado,
        LlaveAbierta,
        LlaveCerrada,
        CorcheteAbierto,
        CorcheteCerrado,
        Coma,
        Punto,
        PuntoComa,
        PalabraReservada,
        Booleano,
        Desconocido
    }

    public class Token
    {
        public TipoToken Tipo { get; set; }
        public string Valor { get; set; }
        public int Id { get; set; }
    }

    public class TablaSimbolos
    {
        private Dictionary<string, int> simbolos = new Dictionary<string, int>();
        private int contador = 0;

        public int ObtenerId(string identificador)
        {
            if (simbolos.ContainsKey(identificador))
            {
                return simbolos[identificador];
            }
            else
            {
                contador++;
                simbolos.Add(identificador, contador);
                return contador;
            }
        }
    }

    private int[,] tablaTransiciones = new int[,]
    {
                // Estados
                // 0 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30 31 32 33 34 35 36 37 38 39 40 41 42
                {1,	3,	0,	9,	10,	11,	12,	26,	27,	28,	6,	29,	30,	31,	32,	33,	34,	35,	36,	2,	42},
                {1,	1,	13,	13,	13,	13,	13,	13,	13,	13,	13,	13,	13,	13,	13,	13,	13,	13,	13,	38, 38, 37},
                {2,	2,	2,	2,	2,	2,	2,	2,	2,	2,	2,	2,	2,	2,	2,	2,	2,	2,	2,	14,	2,	2},
                {39, 3,	15,	15,	15,	15,	15,	15,	15,	15,	15,	15,	15,	15,	15,	15,	15,	15,	15,	38,	4,	37},
                {39,	5,	39,	39,	39,	39,	39,	39,	39,	39,	39,	39,	39,	39,	39,	39,	39,	39,	39,	39,	39,	37},
                {39,	5,	16,	16,	16,	16,	16,	16,	16,	16,	16,	16,	16,	16,	16,	16,	16,	16,	16,	39,	39,	37},
                {17,	17,	17,	41,	41,	41,	41,	41,	41,	7,	41,	41,	41,	17,	41,	17,	41,	41,	41,	41,	41,	37},
                {7,	7,	7,	7,	7,	7,	7,	7,	7,	8,	7,	7,	7,	7,	7,	7,	7,	7,	7,	7,	7,	7},
                {7,	7,	7,	7,	7,	7,	7,	7,	7,	7,	18,	7,	7,	7,	7,	7,	7,	7,	7,	7,	7,	7},
                {19,	19,	19,	42,	42,	20,	42,	19,	19,	42,	42,	42,	42,	19,	42,	19,	42,	42,	42,	42,	42,	37},
                {23,	23,	23,	42,	42,	24,	42,	23,	23,	42,	42,	42,	42,	23,	42,	23,	42,	23,	42,	21,	42,	37},
                {42,	42,	42,	42,	42,	25,	42,	42,	42,	42,	42,	42,	42,	42,	42,	42,	42,	42,	42,	42,	42,	37},
                {13,	13,	13,	13,	13,	13,	13,	13,	13,	13,	13,	13,	13,	13,	13,	13,	13,	13,	13,	13,	13,	13},
                {14,	14,	14,	14,	14,	14,	14,	14,	14,	14,	14,	14,	14,	14,	14,	14,	14,	14,	14,	14,	14,	14},
                {15,	15,	15,	15,	15,	15,	15,	15,	15,	15,	15,	15,	15,	15,	15,	15,	15,	15,	15,	15,	15,	15},
                {16,	16,	16,	16,	16,	16,	16,	16,	16,	16,	16,	16,	16,	16,	16,	16,	16,	16,	16,	16,	16,	16},
                {17,	17,	17,	17,	17,	17,	17,	17,	17,	17,	17,	17,	17,	17,	17,	17,	17,	17,	17,	17,	17,	17},
                {18,	18,	18,	18,	18,	18,	18,	18,	18,	18,	18,	18,	18,	18,	18,	18,	18,	18,	18,	18,	18,	18},
                {19,	19,	19,	19,	19,	19,	19,	19,	19,	19,	19,	19,	19,	19,	19,	19,	19,	19,	19,	19,	19,	19},
                {20,	20,	20,	20,	20,	20,	20,	20,	20,	20,	20,	20,	20,	20,	20,	20,	20,	20,	20,	20,	20,	20},
                {21,	21,	21,	21,	21,	21,	21,	21,	21,	21,	21,	21,	21,	21,	21,	21,	21,	21,	21,	21,	21,	21},
                {22,	22,	22,	22,	22,	22,	22,	22,	22,	22,	22,	22,	22,	22,	22,	22,	22,	22,	22,	22,	22,	22},
                {23,	23,	23,	23,	23,	23,	23,	23,	23,	23,	23,	23,	23,	23,	23,	23,	23,	23,	23,	23,	23,	23},
                {24,	24,	24,	24,	24,	24,	24,	24,	24,	24,	24,	24,	24,	24,	24,	24,	24,	24,	24,	24,	24,	24},
                {25,	25,	25,	25,	25,	25,	25,	25,	25,	25,	25,	25,	25,	25,	25,	25,	25,	25,	25,	25,	25,	25},
                {26,	26,	26,	26,	26,	26,	26,	26,	26,	26,	26,	26,	26,	26,	26,	26,	26,	26,	26,	26,	26,	26},
                {27,	27,	27,	27,	27,	27,	27,	27,	27,	27,	27,	27,	27,	27,	27,	27,	27,	27,	27,	27,	27,	27},
                {28,	28,	28,	28,	28,	28,	28,	28,	28,	28,	28,	28,	28,	28,	28,	28,	28,	28,	28,	28,	28,	28},
                {29,	29,	29,	29,	29,	29,	29,	29,	29,	29,	29,	29,	29,	29,	29,	29,	29,	29,	29,	29,	29,	29},
                {30,	30,	30,	30,	30,	30,	30,	30,	30,	30,	30,	30,	30,	30,	30,	30,	30,	30,	30,	30,	30,	30},
                {31,	31,	31,	31,	31,	31,	31,	31,	31,	31,	31,	31,	31,	31,	31,	31,	31,	31,	31,	31,	31,	31},
                {32,	32,	32,	32,	32,	32,	32,	32,	32,	32,	32,	32,	32,	32,	32,	32,	32,	32,	32,	32,	32,	32},
                {33,	33,	33,	33,	33,	33,	33,	33,	33,	33,	33,	33,	33,	33,	33,	33,	33,	33,	33,	33,	33,	33},
                {34,	34,	34,	34,	34,	34,	34,	34,	34,	34,	34,	34,	34,	34,	34,	34,	34,	34,	34,	34,	34,	34},
                {35,	35,	35,	35,	35,	35,	35,	35,	35,	35,	35,	35,	35,	35,	35,	35,	35,	35,	35,	35,	35,	35},
                {36,	36,	36,	36,	36,	36,	36,	36,	36,	36,	36,	36,	36,	36,	36,	36,	36,	36,	36,	36,	36,	36},
                {37,	37,	37,	37,	37,	37,	37,	37,	37,	37,	37,	37,	37,	37,	37,	37,	37,	37,	37,	37,	37,	37},
                {38,	38,	38,	38,	38,	38,	38,	38,	38,	38,	38,	38,	38,	38,	38,	38,	38,	38,	38,	38,	38,	38},
                {39,	39,	39,	39,	39,	39,	39,	39,	39,	39,	39,	39,	39,	39,	39,	39,	39,	39,	39,	39,	39,	39},
                {40,	40,	40,	40,	40,	40,	40,	40,	40,	40,	40,	40,	40,	40,	40,	40,	40,	40,	40,	40,	40,	40},
                {41,	41,	41,	41,	41,	41,	41,	41,	41,	41,	41,	41,	41,	41,	41,	41,	41,	41,	41,	41,	41,	41},
                {42,	42,	42,	42,	42,	42,	42,	42,	42,	42,	42,	42,	42,	42,	42,	42,	42,	42,	42,	42,	42,	42}
    };


