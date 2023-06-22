using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LexicoProfessor
{
    internal class AnalisadorLexico
    {

       public void Analise(string caminho)
        {
            // path = @"C:\\Users\\misac\\Desktop\\compiladoress\\codigo.txt";
            string content = "";
            try
            {
                content = File.ReadAllText(caminho);
            }
            catch (IOException e)
            {
                Console.WriteLine($"Ocorreu um erro ao ler o arquivo: {e.Message}");
            }

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
            string pegaValor(string valor)
            {
                foreach (KeyValuePair<int, string> item in tokensLinguagem)
                {
                    if (item.Value == valor)
                        return item.Value;
                }
                return "";
            }

            // Definição da especificação de tokens
            Tuple<string, string>[] tokenSpec = new Tuple<string, string>[]
            {
                    Tuple.Create("COMENTARIO",@"#\*(.*?|\n)*?\*#"),
                    Tuple.Create("STRING", "\"(.*?)\""),
                    Tuple.Create("LITERALS",@"\!\w+"),
                    Tuple.Create("NUMBER", @"\d+(\.\d+)?"),
                    Tuple.Create("WORD", @"[A-Za-z_]+\d*"),
                    Tuple.Create("SKIP",@"[\t]+"),
                    Tuple.Create("LINEFEED",@"[\r]+"),
                    Tuple.Create("MAIORIGUAL",@">=+"),
                    Tuple.Create("MENORIGUAL",@"<=+"),
                    Tuple.Create("DIFERENTE",@"<>"),
                    Tuple.Create("PONTOPONTO",@"\.\."),
                    Tuple.Create("NEWLINE", @"\n"),
                    Tuple.Create("CHAR",@"'(.*?)'"),
                    Tuple.Create("COMENTARIOSINGLE",@"##(.*?)\n"),
                    Tuple.Create("MISMATCH", @"."),



            };

            // Criando a expressão regular que reconhece cada tipo de token
            string[] tokenRegexes = tokenSpec.Select(pair => $"(?<{pair.Item1}>{pair.Item2})").ToArray();
            string finalRegex = string.Join("|", tokenRegexes);
            Regex tokenizer = new Regex(finalRegex);


            //uso do tokenizador    
            MatchCollection matches = tokenizer.Matches(content);
            bool blocoComentario = false;
            int linha = 1;
            foreach (Match match in matches)
            {
                var teste = GetTokenType(match);
                // Console.WriteLine($"Token: {match.Value}, Tipo: {GetTokenType(match)}");
                TokensEncontrados tokenEncontrado = new TokensEncontrados();
                bool invalid = false;
                if (GetTokenType(match) == "SKIP")
                {
                    continue;
                }
                if (GetTokenType(match) == "COMENTARIOSINGLE")
                {
                    if (linha > 1)
                    {
                        linha--;
                    }
                    continue;
                }
                if (GetTokenType(match) == "COMENTARIO")
                {
                    if (match.Value.StartsWith("#*"))
                    {
                        blocoComentario = true;
                        continue;
                    }
                    else if (match.Value.EndsWith("*#"))
                    {
                        blocoComentario = false;
                        continue;
                    }
                    if (blocoComentario)
                        continue;
                }
                if (GetTokenType(match) == "STRING")
                {
                    tokenEncontrado.Codigo = 38;
                    tokenEncontrado.Token = "nomestring";
                    tokenEncontrado.Linha = linha;
                }
                if (GetTokenType(match) == "CHAR")
                {
                    if (match.Value.Length > 1)
                    {
                        Console.WriteLine("Erro: variáveis do tipo char não podem receber mais que um caractere");
                        continue;
                    }
                    tokenEncontrado.Codigo = 39;
                    tokenEncontrado.Token = "nomechar";
                    tokenEncontrado.Linha = linha;
                }
                if (GetTokenType(match) == "LITERALS")
                {
                    tokenEncontrado.Codigo = 13;
                    tokenEncontrado.Token = "literal";
                    tokenEncontrado.Linha = linha;
                }
                if (GetTokenType(match) == "NEWLINE")
                {
                    linha++;
                    continue;
                }
                if (GetTokenType(match) == "NUMBER")
                {
                    if (match.Value.Contains("."))
                    {
                        tokenEncontrado.Codigo = 36;
                        tokenEncontrado.Token = "numreal";
                        tokenEncontrado.Linha = linha;
                    }
                    else
                    {
                        tokenEncontrado.Codigo = 37;
                        tokenEncontrado.Token = "numinteiro";
                        tokenEncontrado.Linha = linha;
                    }
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
                        tokenEncontrado.Linha = linha;
                    }
                    else
                    {
                        tokenEncontrado.Codigo = pegarkey(match.Value);
                        tokenEncontrado.Token = pegaValor(match.Value);
                        tokenEncontrado.Linha = linha;
                    }
                }
                if (GetTokenType(match) == "MAIORIGUAL")
                {
                    tokenEncontrado.Codigo = 29;
                    tokenEncontrado.Token = match.Value;
                    tokenEncontrado.Linha = linha;
                }
                if (GetTokenType(match) == "MENORIGUAL")
                {
                    tokenEncontrado.Codigo = 33;
                    tokenEncontrado.Token = match.Value;
                    tokenEncontrado.Linha = linha;
                }

                if (GetTokenType(match) == "DIFERENTE")
                {
                    tokenEncontrado.Codigo = 32;
                    tokenEncontrado.Token = match.Value;
                    tokenEncontrado.Linha = linha;
                }
                if (GetTokenType(match) == "PONTOPONTO")
                {
                    tokenEncontrado.Codigo = 45;
                    tokenEncontrado.Token = match.Value;
                    tokenEncontrado.Linha = linha;
                }
                if (GetTokenType(match) == "LINEFEED")
                {
                    continue;
                }
                if (GetTokenType(match) == "MISMATCH")
                {
                    if (match.Value == " ")
                    {
                        continue;
                    }
                    if (pegarkey(match.Value) == 0)
                    {
                        Console.WriteLine("Caractere irreconhecivel na linha " + linha);
                        invalid = true;
                    }
                    else
                    {

                        tokenEncontrado.Codigo = pegarkey(match.Value);
                        tokenEncontrado.Token = match.Value;
                        tokenEncontrado.Linha = linha;
                    }

                }
                if (invalid == false)
                {
                    tokensEncontrados.Add(tokenEncontrado);
                }
            }
           Console.WriteLine("TABELA DE TOKENS ENCONTRADOS");
            foreach (var linhaTabela in tokensEncontrados)
            {
                Console.WriteLine("Código: " + linhaTabela.Codigo.ToString() + " Token: " + linhaTabela.Token + " Linha: " + linhaTabela.Linha);

            }
            AnalisadorSintatico analisador = new AnalisadorSintatico(tokensEncontrados);
            analisador.Analisar();
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
