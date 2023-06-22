using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LexicoProfessor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string opcao;
            string path = "";
            do
            {
                Console.Clear();
                Console.WriteLine("Estão disponibilizados 3 exemplos de Código");
                Console.WriteLine("Digite o código correspondente ao número do exemplo para roda-lo ou s para sair.");
                Console.WriteLine("Digite a opção 4 para buscar um txt em uma pasta de seu computador");
                AnalisadorLexico lexico = new AnalisadorLexico();
                opcao = Console.ReadKey(true).KeyChar.ToString().ToLower();
                if (opcao == "1")
                {
                    Console.WriteLine("Opção escolhida: "+ opcao.ToString());
                    lexico.Analise(@"Exemplo1.txt");
                }
                else if(opcao == "2")
                {
                    Console.WriteLine("Opção escolhida: "+ opcao.ToString());
                    lexico.Analise(@"Exemplo2.txt");
                }
                else if(opcao == "3")
                {
                    Console.WriteLine("Opção escolhida: "+ opcao.ToString());
                    lexico.Analise(@"Exemplo3.txt");
                }
                else if(opcao == "4")
                {
                    Console.WriteLine("Opção escolhida: ", opcao);
                    Console.WriteLine("Digite o Caminho que deseja buscar");
                    path = Console.ReadLine();
                    lexico.Analise(path);
                }
                else if(opcao!="s")
                {
                    Console.WriteLine("Opção inválida");
                    Console.ReadKey();
                }
            } while (opcao != "s");
            



        }
    }
}