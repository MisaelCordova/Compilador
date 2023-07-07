using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexicoProfessor
{
    internal class TokenParser
    {
        private static IDictionary<int, string> tokensLinguagem = new Dictionary<int, string>()
        {
                    { 0, "write" },
                    { 1, "while" },
                    { 2, "until" },
                    { 3, "to" },
                    { 4, "then" },
                    { 5, "string" },
                    { 6, "repeat" },
                    { 7, "real" },
                    { 8, "read" },
                    { 9, "program" },
                    { 10, "procedure" },
                    { 11, "or" },
                    { 12, "of" },
                    { 13, "literal" },
                    { 14, "integer" },
                    { 15, "if" },
                    { 16, "identificador" },
                    { 17, "î" },
                    { 18, "for" },
                    { 29, "end" },
                    { 20, "else" },
                    { 21, "do" },
                    { 22, "declaravariaveis" },
                    { 23, "const" },
                    { 24, "char" },
                    { 25, "chamaprocedure" },
                    { 26, "begin" },
                    { 27, "array" },
                    { 28, "and" },
                    { 29, ">=" },
                    { 30, ">" },
                    { 31, "=" },
                    { 32, "<>" },
                    { 33, "<=" },
                    { 34, "<" },
                    { 35, "+" },
                    { 36, "numreal" },
                    { 37, "numinteiro" },
                    { 38, "nomestring" },
                    { 39, "nomechar" },
                    { 40, "]" },
                    { 41, "[" },
                    { 42, ";" },
                    { 43, ":" },
                    { 44, "/" },
                    { 45, ".." },
                    { 46, "." },
                    { 47, "," },
                    { 48, "*" },
                    { 49, ")" },
                    { 50, "(" },
                    { 52, "$" },
                    { 53, "-" },
                };
        public static string get(int token)
        {
            return tokensLinguagem.TryGetValue(token, out string value) ? value : token.ToString();
        }
    }
}
