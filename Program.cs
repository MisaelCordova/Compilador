﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LexicoProfessor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            List<TokensEncontrados> tokensEncontrados = new List<TokensEncontrados>();
            IDictionary<int, string> tokensLinguagem = new Dictionary<int, string>()
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
                { 19, "end" },
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
                { 51, "$" },
                { 52, "-" },
            };
            int pegarkey(string valor)
            {
                foreach (KeyValuePair<int, string> item in tokensLinguagem)
                {
                    if (item.Value == valor)
                        return item.Key;
                }
                return 0;   
                   
                
            }
            
            
            // Definição da especificação de tokens
            Tuple<string, string>[] tokenSpec = new Tuple<string, string>[]
            {
                Tuple.Create("NUMBER", @"\d+"),
                Tuple.Create("WORD", @"[A-Za-z_]+\d*"),
                Tuple.Create("MISMATCH", @"\."),
                Tuple.Create("SKIP",@"[\t]+")
               // Tuple.Create("WHITESPACE", @"\s+")
                
            };

            // Criando a expressão regular que reconhece cada tipo de token
            string[] tokenRegexes = tokenSpec.Select(pair => $"(?<{pair.Item1}>{pair.Item2})").ToArray();
          
            string finalRegex = string.Join("|", tokenRegexes);
            Console.WriteLine(finalRegex);
            Regex tokenizer = new Regex(finalRegex);

            // Exemplo de uso do tokenizer
            string text = " .>=>=and<=+ the ";
            MatchCollection matches = tokenizer.Matches(text);

            foreach (Match match in matches)
            {
                Console.WriteLine($"Token: {match.Value}, Tipo: {GetTokenType(match)}");
                TokensEncontrados tokenEncontrado = new TokensEncontrados();
                if (GetTokenType(match) == "NUMBER")
                {
                    //verificar se é int ou real
                }
                if (GetTokenType(match) == "WORD")
                {
                    //como fazer a distinção quando é palavra reservadar ou identificador
                    var PalavraReservada = (from item in tokensLinguagem
                                            where item.Value == match.Value         
                                            select item.Key).ToList();
                    if (PalavraReservada.Count == 0)
                    {
                        tokenEncontrado.Codigo = 16;
                        tokenEncontrado.Token = "identificador";
                    }
             

                }
                if (GetTokenType(match) == "MISMATCH")
                {
                    tokenEncontrado.Codigo = pegarkey(match.Value);
                    if(tokenEncontrado.Codigo == 0)
                    {
                        
                        Console.WriteLine("Caractere irreconhecivel");
                    }
                    tokenEncontrado.Token = match.Value;
                }
                
                tokensEncontrados.Add(tokenEncontrado);
            }
            foreach(var linha in tokensEncontrados)
            {
                Console.WriteLine(linha.Codigo.ToString(), linha.Token);
            }
            

            // Função para determinar o tipo de um token com base no grupo de captura correspondente
            string GetTokenType(Match match)
            {
                foreach (Tuple<string, string> tokenType in tokenSpec)
                {
                    Group group = match.Groups[tokenType.Item1];
                    if (group.Success)
                    {
                        return tokenType.Item1;
                    }
                }
                return "UNKNOWN";
            }
            Console.ReadKey();

        }
    }
}
