using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DAL;
using System.Data;

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

        public void InserirCodigo(Cliente cliente)
        {
            ClienteDAL clientedal = new ClienteDAL();
            clientedal.InserirCodigo(cliente);
        }

        public void InserirCliente(Cliente cliente )
        {
            ClienteDAL clientedal = new ClienteDAL();
            clientedal.InserirCliente(cliente);
        }

        public void AtualizarCliente(Cliente cliente)
        {
            ClienteDAL clientedal = new ClienteDAL();
            clientedal.AtualizarCliente(cliente);
        }

        public void ExcluirCliente(Cliente cliente)
        {
            ClienteDAL clientedal = new ClienteDAL();
            clientedal.ExcluirCliente(cliente);
        }

        public DataTable ConsultarCliente(String NomeCliente)
        {
            ClienteDAL clientedal = new ClienteDAL();
            return clientedal.ConsultarCliente(NomeCliente);
        }
    }
}