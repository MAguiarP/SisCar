﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data;
using Npgsql;
using System.Security.Cryptography.X509Certificates;

namespace DAL
{
    public class PerfilDAL
    {
        public void SalvarImagem(Perfil perfil)
        {
            try
            {
                string salvaI = (string.Format(
                        "UPDATE USUARIOS_CONFIG" +
                        "SET VALOR - '{0}'," +
                        "PLANO_DE_FUNDO = '{1}'" +
                        "WHERE LOGIN = '{2}' ", perfil.Imagem, 'I', perfil.Login));

                NpgsqlCommand comandoUpdate = new NpgsqlCommand
             (salvaI, ConnectionFactory.Connect());
                comandoUpdate.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao Salvar o caminho da Imagem!" + ex.Message);
            }
            finally
            {
                ConnectionFactory.Connect().Close();
            }

        }

        public void SalvarCor(Perfil perfil)
        {
            try
            {

            }
        }

    }

    
}