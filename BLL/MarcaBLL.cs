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
    public class MarcaBLL
    {
        public bool VerificarCampos(Marca marca)
        {
            if (marca.Ds_Marca.Trim().Length == 0)
            {
                throw new Exception("É obrigatório o preenchimento do campo Marca!");
            }                    

            return true;
        }

        public void InserirCodigo(Marca marca)
        {
            MarcaDAL marcadal = new MarcaDAL();
            marcadal.InserirCodigo(marca);
        }

        public void InserirMarca(Marca marca)
        {
            MarcaDAL marcadal = new MarcaDAL();
            marcadal.InserirMarca(marca);
        }

        public void ExcluirMarca(Marca marca)
        {
            MarcaDAL marcadal = new MarcaDAL();
            marcadal.ExcluirMarca(marca);
        }

        public DataTable ConsultarMarca(String NomeCliente)
        {
            MarcaDAL marcadal = new MarcaDAL();
            return marcadal.ConsultarMarca(NomeCliente);
        }

        public DataTable RetornaMarca()
        {
            MarcaDAL marcadal = new MarcaDAL();
            return marcadal.RetornaMarca();
        }
    }
}
