using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;
using System.Data;
using Dapper.Contrib;
using System.Data.SqlClient;
using Dapper.Contrib.Extensions;

public class ChamadaRepository
{
    private string Connection { get; set; } = "data source=localhost; initial catalog=Chamada;persist security info=True;Integrated Security=SSPI;";


    public ChamadaRepository()
    {
        SqlMapperExtensions.TableNameMapper = (type) => type.Name;
    }

    public bool Salvar(ChamadaAluno chamada)
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

    public Materia GetMateria(int idMateria)
    {
        try
        {
            using (var cnx = new SqlConnection(Connection))
            {
                return cnx.Get<Materia>(idMateria);
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
                return cnx.Query<DTO.MateriaDto>("usp_materia_list_professor", new { idProfessor = idProfessor}, commandType: CommandType.StoredProcedure).ToList();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public Professor GetProfessor(int idProfessor)
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

    public IEnumerable<ChamadaAluno> ListByData(int idProfessor, string data)
    {
        try
        {
            using (var cnx = new SqlConnection(Connection))
            {
                return cnx.Query<ChamadaAluno>("usp_chamada_list_data", new { idProfessor = idProfessor, data = data }, commandType: CommandType.StoredProcedure);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }


    public Professor ProfessorLogin(string usuario, string senha)
    {
        try
        {
            using (var cnx = new SqlConnection(Connection))
            {
                return cnx.QueryFirstOrDefault<Professor>("usp_professor_select_loginSenha",
                    new { usuario = usuario, senha = senha }, commandType: CommandType.StoredProcedure);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    public ChamadaAluno GetRespostaChamada(int idMateria, string numeroMatricula, DateTime now)
    {
        try
        {
            using (var cnx = new SqlConnection(Connection))
            {
                return cnx.QueryFirstOrDefault<ChamadaAluno>("usp_chamada_aluno_select_data_materia",
                    new { idMateria = idMateria, numeroMatricula = numeroMatricula, data = now }, commandType: CommandType.StoredProcedure);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
