using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexicoProfessor
{
    internal class AnalisadorSintatico
    {
       public bool Analisar(IGramatica gramatica, List<TokensEncontrados> tokensEncontrados)
        {
            Stack<int> producoes = new Stack<int>();
            Stack<TokensEncontrados> entradas = new Stack<TokensEncontrados>();

          foreach(TokensEncontrados t in entradas)
          {
                    Console.Write(t.Codigo+",");// percorre lista pegando o código 
          }
                Console.WriteLine();
            tokensEncontrados.Reverse();

            foreach (TokensEncontrados token in tokensEncontrados)
            {
                entradas.Push(token);
            }

            producoes.Push(gramatica.getFinalPilha());
          
            empilharReverso(producoes, gramatica.getProducao(1));
           

            
            
            
            while(entradas.Count > 0)
            {
                Console.WriteLine("Produções: "+string.Join(",", producoes));
                Console.Write("Entrada: " );
                
                foreach(TokensEncontrados t in entradas)
                {
                    Console.Write(t.Codigo+",");// percorre lista pegando o código 
                }
                Console.WriteLine();
               

                
                int producao = producoes.Pop();
                TokensEncontrados entrada = entradas.Pop();
                int tokenEntrada = entrada.Codigo + 1;
                if(producao == tokenEntrada)
                {
                    continue;
                }
                entradas.Push(entrada);
                if(producao == gramatica.getVazio())
                {
                    continue;
                }
                if(producao == gramatica.getFinalPilha())
                {
                    
                    Console.WriteLine("Token "+ TokenParser.get(tokenEntrada)+ "inesperado. Esperado final do código");
                    Console.WriteLine("Liha do erro:" + (entrada.Linha));
                    return false;
                }

                int numProximaProducao = gramatica.parse(producao, tokenEntrada);
                
                if(numProximaProducao == 0)
                {
                    Console.WriteLine("Token " +tokenEntrada + " inesperado. Esperado token " + producao);
                    Console.WriteLine("Liha do erro:" + (entrada.Linha));
                    return false;
                }

                int[] proximaProducao = gramatica.getProducao(numProximaProducao);
                empilharReverso(producoes, proximaProducao);
            }
            if(producoes.Count == 0)
            {
                Console.WriteLine("Esperado token final porém as produções estão vazias");
                return false;
            }

            int ultimo = producoes.Pop();

            if(ultimo != gramatica.getFinalPilha())
            {
                Console.WriteLine("Esperando producao final $, porém foi dado a produção " + ultimo);
                return false;
            }
            return true;

             
       }
        private void empilharReverso(Stack<int> stack, int[] numeros)
        {
            for (int i = numeros.Length - 1; i >= 0; i--)
            {
                if (numeros[i] != 0)
                    stack.Push(numeros[i]);
            }
            
        }

    }
}
