using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LexicoProfessor
{
    internal class TokensEncontrados
    {
        private int codigo;
        private string token;
        private int linha;

        public TokensEncontrados(int codigo, string token, int linha)
        {
            this.codigo = codigo;
            this.token = token;
            this.linha = linha;
        }
        public TokensEncontrados()
        {
             
        }
        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        public string Token
        {
            get => token;
            set => token = value;
        }
        public int Linha
        {
            get => linha;
            set => linha = value;
        }
    }
}


