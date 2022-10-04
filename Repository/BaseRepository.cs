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
    public class BaseRepository
    {
        protected string Connection { get; set; } = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        protected string FraseEcpt { get; set; } = "5e94f70d-7686-492d-a2b4-b8f56199d85c";


        public BaseRepository()
        {
            SqlMapperExtensions.TableNameMapper = (type) => type.Name;
        }
    }
}