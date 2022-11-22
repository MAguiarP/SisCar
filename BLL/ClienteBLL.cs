using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DAL;

namespace BLL
{
    public class ClienteBLL
    {
        public bool VerificarCampos(Cliente cliente)
        {
            if (cliente.Nome.Trim().Length == 0)
            {
                throw new Exception("É Obrigatório o preenchimento do campo Nome!");
            }

            if (cliente.Cpf.Trim().Length == 0)
            {
                throw new Exception("É Obrigatório o preenchimento do campo CPF!");
            }

            try
            {
                Convert.ToString(Convert.ToDateTime(cliente.Data_nasc));
            }
            catch
            {
                throw new Exception("Verifique se o campo Data de Nascimento foi preenchido corretamente!");
            }

            return true;
        }

    }
}