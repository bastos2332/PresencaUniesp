
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;
using System.Data;
using Dapper.Contrib;
using System.Data.SqlClient;
using Dapper.Contrib.Extensions;
using System.Configuration;


namespace PRESENCA_FACIL.Repository
{
    public class PresencaRepository : BaseRepository
    {


        public bool Salvar(PresencaAluno chamada)
        {
            try
            {
                using (var cnx = new SqlConnection(Connection))
                {
                    return cnx.Insert(chamada) != 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public MateriaTurma GetMateria(int idMateria)
        {
            try
            {
                using (var cnx = new SqlConnection(Connection))
                {
                    return cnx.Get<MateriaTurma>(idMateria);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<DTO.MateriaDto> ListMateriasProfessor(int idProfessor)
        {
            try
            {
                using (var cnx = new SqlConnection(Connection))
                {
                    return cnx.Query<DTO.MateriaDto>("usp_materia_list_professor", new { idProfessor = idProfessor }, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       

        public IEnumerable<PresencaAluno> ListByData(int idProfessor, string data)
        {
            try
            {
                using (var cnx = new SqlConnection(Connection))
                {
                    return cnx.Query<PresencaAluno>("usp_chamada_list_data", new { idProfessor = idProfessor, data = data }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public IEnumerable<PresencaAluno> ListByMateriaData(int idMateria, string data)
        {
            try
            {
                using (var cnx = new SqlConnection(Connection))
                {
                    return cnx.Query<PresencaAluno>("usp_presenca_materia_list_data", new { idMateria = idMateria, data = data }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        public PresencaAluno GetRespostaChamada(int idMateria, string numeroMatricula, DateTime now)
        {
            try
            {
                using (var cnx = new SqlConnection(Connection))
                {
                    return cnx.QueryFirstOrDefault<PresencaAluno>("usp_chamada_aluno_select_data_materia",
                        new { idMateria = idMateria, numeroMatricula = numeroMatricula, data = now }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}


