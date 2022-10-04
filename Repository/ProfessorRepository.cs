﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;
using System.Data;
using Dapper.Contrib;
using System.Data.SqlClient;
using Dapper.Contrib.Extensions;
using System.Configuration;
using PRESENCA_FACIL.DTO;

namespace PRESENCA_FACIL.Repository
{
    public class ProfessorRepository: BaseRepository
    {

        public bool Salvar(Professor prof)
        {
            try
            {
                using (var cnx = new SqlConnection(Connection))
                {
                    return cnx.Insert(prof) != 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public ProfessorDTO Login(string usuario, string senha)
        {
            try
            {
                using (var cnx = new SqlConnection(Connection))
                {
                    return cnx.QueryFirstOrDefault<ProfessorDTO>("usp_professor_select_loginSenha",
                        new { usuario = usuario, senha = senha, frase = FraseEcpt }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public Professor Get(int idProfessor)
        {
            try
            {
                using (var cnx = new SqlConnection(Connection))
                {
                    return cnx.Get<Professor>(idProfessor);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}