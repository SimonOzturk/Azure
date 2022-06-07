using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Text;
using System.Text.Json;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesOrderController : ControllerBase
    {
        public SqlConnection SqlConnection { get; set; }
        public SalesOrderController(SqlConnection sqlConnection)
        {
            this.SqlConnection = sqlConnection;
        }
        [HttpGet]
        public ActionResult Get()
        {
            var sqlCommand = new SqlCommand("SELECT TOP(10) * FROM Sales.SalesOrderDetail FOR JSON AUTO", SqlConnection);
            //var builder = new StringBuilder();
            //SqlConnection.Open();
            //var reader = sqlCommand.ExecuteReader();

            //while (reader.Read())
            //{
            //    builder.Append(reader.GetString(0));
            //}
            //SqlConnection.Close();
            //return Ok(JsonDocument.Parse(builder.ToString()));
            return Ok(sqlCommand.ExecuteJsonDocument());
        }
    }
}

namespace Microsoft.Data.SqlClient
{
    public static class Extentions
    {
        public static JsonDocument ExecuteJsonDocument(this SqlCommand sqlCommand)
        {
            try
            {
                var builder = new StringBuilder();
                if (sqlCommand.Connection.State == System.Data.ConnectionState.Closed)
                {
                    sqlCommand.Connection.Open();
                }
                var reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    builder.Append(reader.GetString(0));
                }
                sqlCommand.Connection.Close();
                return JsonDocument.Parse(builder.ToString());
            }
            catch (Exception e)
            {
                return JsonDocument.Parse(String.Format("'Exception':'{0}'",e.Message));
            }
            finally
            {
                sqlCommand.Connection.Close();
            }
        }
    }
}
