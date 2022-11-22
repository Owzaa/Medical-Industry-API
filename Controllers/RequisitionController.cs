
using Microsoft.AspNetCore.Mvc;
using Medical_Industry_API.Models;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Medical_Industry_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequisitionController : ControllerBase
    {

        private readonly IConfiguration _configuration;

        public RequisitionController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        // GET: api/<RequisitionController>
        [HttpGet]
        public JsonResult Get()
        {
            string query = "";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("PatientRecordsConn");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult (table);
        }

   
        // POST api/<RequisitionController>
        [HttpPost]
        public JsonResult Post(Requisition req)
        {
            string query = "";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("PatientRecordsConn");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;

                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Requisition Added Successfully");
        }

        // PUT api/<RequisitionController>/5
        [HttpPut("{id}")]
        public void Put(int id,Requisition req)
        {
            string query = "";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("PatientRecordsConn");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;

                    myReader.Close();
                    myCon.Close();
                }
            }
        }

        // DELETE api/<RequisitionController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"
                    delete from dbo.PatientRecords
                    where RequisitionId = " + id + @" 
                    ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("PatientRecordsConn");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Requisition Deleted Successfully");
        }
    }
}
