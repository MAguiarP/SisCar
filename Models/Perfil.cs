using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Perfil
    {
        private string login;
        private string plano_de_fundo;
        private string descricao;
        private string valor;
        private string cor;
        private string imagem;

        public string Imagem
        {
            get { return imagem; }
            set { imagem = value; }
        }

        public string Cor
        {
            get { return cor; }
            set { cor = value; }
        }

        public string Valor
        {
            get { return Valor; }
            set { Valor = value; }
        }
    }
}
