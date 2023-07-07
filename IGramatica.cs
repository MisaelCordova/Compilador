using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexicoProfessor
{
    internal interface IGramatica
    {
        int[] getProducao(int numero);

        int parse(int producao, int token);

        int getFinalPilha();

        int getVazio();
    }
}
