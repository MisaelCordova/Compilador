using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexicoProfessor
{
    internal class AnalisadorSintatico
    {
        private List <TokensEncontrados> tokens;

        public AnalisadorSintatico( List<TokensEncontrados> tokens)
        {
            this.tokens = tokens;
        }

        public AnalisadorSintatico()
        {
        }

        public List<TokensEncontrados> Tokens
        {
            get { return tokens; }
            set { tokens = value; }
        }

        int[,] producoes = new int[,] {
       {10,17,43,55,47,0,0,0,0,0,0,0,0,0},//P1
		{56,57,58,59,0,0,0,0,0,0,0,0,0,0},//P2
		{24,17,32,60,43,61,0,0,0,0,0,0,0,0},//P3
		{18,0,0,0,0,0,0,0,0,0,0,0,0,0},//P4
		{17,32,60,43,61,0,0,0,0,0,0,0,0,0},//P5
		{18,0,0,0,0,0,0,0,0,0,0,0,0,0},//P6
		{23,62,44,60,43,63,0,0,0,0,0,0,0,0},//P7
		{18,0,0,0,0,0,0,0,0,0,0,0,0,0},//P8
		{17,64,0,0,0,0,0,0,0,0,0,0,0,0},//P9
		{48,17,64,0,0,0,0,0,0,0,0,0,0,0},//P10
		{18,0,0,0,0,0,0,0,0,0,0,0,0,0},//P11
		{62,44,60,43,63,0,0,0,0,0,0,0,0,0},//P12
		{18,0,0,0,0,0,0,0,0,0,0,0,0,0},//P13
		{28,42,38,46,38,41,13,65,0,0,0,0,0,0},//P14
		{15,0,0,0,0,0,0,0,0,0,0,0,0,0},//P15
		{25,0,0,0,0,0,0,0,0,0,0,0,0,0},//P16
		{6,0,0,0,0,0,0,0,0,0,0,0,0,0},//P17
		{8,0,0,0,0,0,0,0,0,0,0,0,0,0},//P18
		{15,0,0,0,0,0,0,0,0,0,0,0,0,0},//P19
		{25,0,0,0,0,0,0,0,0,0,0,0,0,0},//P20
		{6,0,0,0,0,0,0,0,0,0,0,0,0,0},//P21
		{8,0,0,0,0,0,0,0,0,0,0,0,0,0},//P22
		{11,17,66,58,59,43,56,0,0,0,0,0,0,0},//P23
		{18,0,0,0,0,0,0,0,0,0,0,0,0,0},//P24
		{51,62,44,60,43,63,50,0,0,0,0,0,0,0},//P25
		{18,0,0,0,0,0,0,0,0,0,0,0,0,0},//P26
		{27,67,43,68,20,0,0,0,0,0,0,0,0,0},//P27
		{67,43,68,0,0,0,0,0,0,0,0,0,0,0},//P28
		{18,0,0,0,0,0,0,0,0,0,0,0,0,0},//P29
		{16,42,69,41,5,27,67,20,70,0,0,0,0,0},//P30
		{2,42,69,41,22,27,67,20,0,0,0,0,0,0},//P31
		{7,67,3,42,69,41,0,0,0,0,0,0,0,0},//P32
		{9,51,71,50,0,0,0,0,0,0,0,0,0,0},//P33
		{26,17,72,0,0,0,0,0,0,0,0,0,0,0},//P34
		{1,51,73,74,50,0,0,0,0,0,0,0,0,0},//P35
		{19,42,17,32,69,41,4,42,69,41,22,27,67,20},//P36
		{18,0,0,0,0,0,0,0,0,0,0,0,0,0},//P37
		{51,62,50,0,0,0,0,0,0,0,0,0,0,0},//P38
		{18,0,0,0,0,0,0,0,0,0,0,0,0,0},//P39
		{14,0,0,0,0,0,0,0,0,0,0,0,0,0},//P40
		{69,0,0,0,0,0,0,0,0,0,0,0,0,0},//P41
		{48,73,74,0,0,0,0,0,0,0,0,0,0,0},//P42
		{18,0,0,0,0,0,0,0,0,0,0,0,0,0},//P43
		{75,76,77,0,0,0,0,0,0,0,0,0,0,0},//P44
		{78,79,0,0,0,0,0,0,0,0,0,0,0,0},//P45
		{38,0,0,0,0,0,0,0,0,0,0,0,0,0},//P46
		{17,0,0,0,0,0,0,0,0,0,0,0,0,0},//P47
		{39,0,0,0,0,0,0,0,0,0,0,0,0,0},//P48
		{40,0,0,0,0,0,0,0,0,0,0,0,0,0},//P49
		{37,0,0,0,0,0,0,0,0,0,0,0,0,0},//P50
		{51,69,50,0,0,0,0,0,0,0,0,0,0,0},//P51
		{32,80,0,0,0,0,0,0,0,0,0,0,0,0},//P52
		{35,80,0,0,0,0,0,0,0,0,0,0,0,0},//P53
		{31,80,0,0,0,0,0,0,0,0,0,0,0,0},//P54
		{30,80,0,0,0,0,0,0,0,0,0,0,0,0},//P55
		{34,80,0,0,0,0,0,0,0,0,0,0,0,0},//P56
		{33,80,0,0,0,0,0,0,0,0,0,0,0,0},//P57
		{18,0,0,0,0,0,0,0,0,0,0,0,0,0},//P58
		{36,75,76,0,0,0,0,0,0,0,0,0,0,0},//P59
		{53,75,76,0,0,0,0,0,0,0,0,0,0,0},//P60
		{75,76,0,0,0,0,0,0,0,0,0,0,0,0},//P61
		{36,75,76,0,0,0,0,0,0,0,0,0,0,0},//P62
		{53,75,76,0,0,0,0,0,0,0,0,0,0,0},//P63
		{12,75,76,0,0,0,0,0,0,0,0,0,0,0},//P64
		{18,0,0,0,0,0,0,0,0,0,0,0,0,0},//P65
		{49,78,79,0,0,0,0,0,0,0,0,0,0,0},//P66
		{45,78,79,0,0,0,0,0,0,0,0,0,0,0},//P67
		{29,78,79,0,0,0,0,0,0,0,0,0,0,0},//P68
		{18,0,0,0,0,0,0,0,0,0,0,0,0,0},//P69
		{21,27,67,20,0,0,0,0,0,0,0,0,0,0},//P70
		{18,0,0,0,0,0,0,0,0,0,0,0,0,0},//P71
		{17,81,0,0,0,0,0,0,0,0,0,0,0,0},//P72
		{48,17,81,0,0,0,0,0,0,0,0,0,0,0},//P73
		{18,0,0,0,0,0,0,0,0,0,0,0,0,0},//P74
		{67,43,68,0,0,0,0,0,0,0,0,0,0,0},//P75
		{14,0,0,0,0,0,0,0,0,0,0,0,0,0}//P76
        };



        int[] addToken()
        {
            int n = tokens.Count();
            int[] tokensAnalizador = new int[n] ;
            int i = 0;
            foreach(TokensEncontrados t in tokens)
            {
                
                tokensAnalizador[i] = t.Codigo+1;
                i++;
            }
            return tokensAnalizador;
        }
        public void Analisar()
        {
           
            int[,] tabParsing = new int[82, 54];

            for (int i = 0; i < 82; i++)
            {
                for (int j = 0; j < 54; j++)
                {
                    tabParsing[i, j] = 0;
                }
            }
          
            tabParsing[55, 1] = 27;
            tabParsing[55, 11] = 2;
            tabParsing[55, 19] = 36;
            tabParsing[55, 23] = 2;
            tabParsing[55, 24] = 2;
            tabParsing[55, 27] = 2;
            tabParsing[56, 11] = 23;
            tabParsing[56, 27] = 74;
            tabParsing[56, 23] = 74;
            tabParsing[56, 24] = 24;
            tabParsing[56, 47] = 24;
            tabParsing[57, 23] = 4;
            tabParsing[57, 24] = 3;
            tabParsing[57, 26] = 74;
            tabParsing[57, 27] = 74;
            tabParsing[57, 47] = 4;
            tabParsing[58, 23] = 7;
            tabParsing[58, 27] = 8;
            tabParsing[59, 27] = 27;
            tabParsing[60, 6] = 21;
            tabParsing[60, 8] = 22;
            tabParsing[60, 15] = 19;
            tabParsing[60, 25] = 20;
            tabParsing[60, 28] = 14;
            tabParsing[61, 17] = 5;
            tabParsing[61, 23] = 6;
            tabParsing[61, 47] = 6;
            tabParsing[62, 17] = 9;
            tabParsing[63, 17] = 12;
            tabParsing[63, 27] = 13;
            tabParsing[63, 50] = 13;
            tabParsing[64, 44] = 11;
            tabParsing[64, 48] = 10;
            tabParsing[64, 50] = 11;
            tabParsing[65, 6] = 17;
            tabParsing[65, 8] = 18;
            tabParsing[65, 15] = 15;
            tabParsing[65, 25] = 16;
            tabParsing[66, 23] = 26;
            tabParsing[66, 24] = 26;
            tabParsing[66, 47] = 26;
            tabParsing[66, 51] = 25;
            tabParsing[67, 1] = 35;
            tabParsing[67, 2] = 31;
            tabParsing[67, 3] = 37;
            tabParsing[67, 7] = 32;
            tabParsing[67, 9] = 33;
            tabParsing[67, 16] = 30;
            tabParsing[67, 19] = 36;
            tabParsing[67, 20] = 37;
            tabParsing[67, 26] = 34;
            tabParsing[67, 27] = 27;
            tabParsing[67, 43] = 37;
            tabParsing[68, 1] = 75;
            tabParsing[68, 2] = 75;
            tabParsing[68, 7] = 75;
            tabParsing[68, 9] = 75;
            tabParsing[68, 16] = 30;
            tabParsing[68, 22] = 75;
            tabParsing[68, 23] = 75;
            tabParsing[68, 24] = 74;
            tabParsing[68, 30] = 75;
            tabParsing[68, 20] = 29;
            tabParsing[69, 17] = 44;
            tabParsing[69, 37] = 44;
            tabParsing[69, 38] = 44;
            tabParsing[69, 39] = 44;
            tabParsing[69, 40] = 44;
            tabParsing[69, 51] = 44;
            tabParsing[70, 3] = 71;
            tabParsing[70, 20] = 71;
            tabParsing[70, 21] = 70;
            tabParsing[70, 43] = 71;
            tabParsing[71, 17] = 72;
            tabParsing[72, 3] = 39;
            tabParsing[72, 20] = 39;
            tabParsing[72, 43] = 39;
            tabParsing[72, 51] = 38;
            tabParsing[73, 14] = 40;
            tabParsing[73, 17] = 41;
            tabParsing[73, 37] = 41;
            tabParsing[73, 38] = 41;
            tabParsing[73, 39] = 41;
            tabParsing[73, 40] = 41;
            tabParsing[73, 51] = 41;
            tabParsing[74, 48] = 42;
            tabParsing[74, 50] = 43;
            tabParsing[75, 17] = 45;
            tabParsing[75, 14] = 45;
            tabParsing[75, 37] = 45;
            tabParsing[75, 38] = 45;
            tabParsing[75, 39] = 45;
            tabParsing[75, 40] = 45;
            tabParsing[75, 51] = 45;
            tabParsing[76, 3] = 65;
            tabParsing[76, 12] = 64;
            tabParsing[76, 20] = 65;
            tabParsing[76, 30] = 65;
            tabParsing[76, 31] = 65;
            tabParsing[76, 32] = 65;
            tabParsing[76, 33] = 65;
            tabParsing[76, 34] = 65;
            tabParsing[76, 35] = 65;
            tabParsing[76, 36] = 62;
            tabParsing[76, 41] = 65;
            tabParsing[76, 43] = 65;
            tabParsing[76, 48] = 65;
            tabParsing[76, 50] = 65;
            tabParsing[76, 53] = 63;
            tabParsing[77, 3] = 58;
            tabParsing[77, 20] = 58;
            tabParsing[77, 30] = 55;
            tabParsing[77, 31] = 54;
            tabParsing[77, 32] = 52;
            tabParsing[77, 33] = 57;
            tabParsing[77, 34] = 56;
            tabParsing[77, 35] = 53;
            tabParsing[77, 41] = 58;
            tabParsing[77, 43] = 58;
            tabParsing[77, 48] = 58;
            tabParsing[77, 50] = 58;
            tabParsing[78, 17] = 47;
            tabParsing[78, 37] = 50;
            tabParsing[78, 38] = 46;
            tabParsing[78, 39] = 48;
            tabParsing[78, 14] = 76;
            tabParsing[78, 40] = 49;
            tabParsing[78, 51] = 51;
            tabParsing[79, 3] = 69;
            tabParsing[79, 12] = 69;
            tabParsing[79, 20] = 69;
            tabParsing[79, 29] = 68;
            tabParsing[79, 30] = 69;
            tabParsing[79, 31] = 69;
            tabParsing[79, 32] = 69;
            tabParsing[79, 33] = 69;
            tabParsing[79, 34] = 69;
            tabParsing[79, 35] = 69;
            tabParsing[79, 36] = 69;
            tabParsing[79, 41] = 69;
            tabParsing[79, 43] = 69;
            tabParsing[79, 45] = 67;
            tabParsing[79, 48] = 69;
            tabParsing[79, 49] = 66;
            tabParsing[79, 50] = 69;
            tabParsing[79, 53] = 69;
            tabParsing[80, 17] = 61;
            tabParsing[80, 36] = 59;
            tabParsing[80, 37] = 61;
            tabParsing[80, 38] = 61;
            tabParsing[80, 39] = 61;
            tabParsing[80, 40] = 61;
            tabParsing[80, 51] = 61;
            tabParsing[80, 53] = 60;
            tabParsing[81, 48] = 73;
            tabParsing[81, 50] = 74;



            int[] pilha = new int[] { 52 };

            int[] producaoInicial = producoes.Cast<int>().Take(14).ToArray();
            pilha = producaoInicial.Concat(pilha).ToArray();

            Console.WriteLine(string.Join(", ", pilha));
            int[] tokensAnalisador = addToken();
            int X = pilha[0];
            int a = tokensAnalisador[0];
            
            while (X != 52)
            {
                Console.WriteLine(X);
                Console.WriteLine(a);
                Console.WriteLine(string.Join(", ", pilha));

                if (X == 1)
                {
                    pilha = pilha.Skip(1).ToArray();
                    X = pilha[0];
                }
                else
                {
                    if (X <= 52)
                    {
                        if (X == a)
                        {
                            pilha = pilha.Skip(1).ToArray();
                             tokensAnalisador = tokensAnalisador.Skip(1).ToArray();
                            X = pilha[0];
                            if (tokensAnalisador.Length != 0)
                            {
                                a = tokensAnalisador[0];
                            }
                        }
                        else
                        {
                            if (X == 18)
                            {
                                pilha = pilha.Skip(1).ToArray();
                              //  tokensAnalisador = tokensAnalisador.Skip(1).ToArray();
                                X = pilha[0];
                             //   if (tokensAnalisador.Length != 0)
                                {
                               //     a = tokensAnalisador[0];
                                }
                                continue;

                            }
                               
                            foreach(TokensEncontrados t in tokens)
                            {
                                if(t.Codigo == a-1)
                                {
                                    Console.WriteLine("Erro na linha "+t.Linha+" codigo "+t.Codigo+" token: "+t.Token+" token esperado: "+X);
                                }

                            }
                            
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine(tabParsing[X, a]+" Valor da tabela");
                        Console.WriteLine(X+"Valor de x Antes do segundo else");
                        int[] topo = producoes.Cast<int>().Skip((tabParsing[X, a] - 1) * 14).Take(14).Concat(pilha).ToArray();
                        if (topo[0] == 1)
                        {
                            X = topo[0];
                        }
                        else
                        {
                            if (topo[0] != 0)
                            {
                                Console.WriteLine("Pilha antes: "+string.Join(", ", pilha));
                                pilha = pilha.Skip(1).ToArray();
                                Console.WriteLine("Pilha depois: " + string.Join(", ", pilha));
                                pilha = producoes.Cast<int>().Skip((tabParsing[X, a] - 1) * 14).Take(14).Concat(pilha).ToArray();
                                Console.WriteLine("Pilha pilha depois do segundo: " + string.Join(", ", pilha));
                                pilha = pilha.Where(val => val != 0).ToArray();
                                Console.WriteLine("Pilha pilha depois do terceiro: " + string.Join(", ", pilha));
                                X = pilha[0];
                            }
                            else
                            {

                                Console.WriteLine("Error");
                                break;
                            }
                        }
                    }
                }
            }
            
            Console.WriteLine("Pilha:");
            Console.WriteLine(string.Join(", ", pilha));
            Console.WriteLine("Entrada:");
  
            Console.WriteLine("Sentença reconhecida com sucesso");
            Console.ReadKey();

        }


    }
}
