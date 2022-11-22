using Medical_Industry_API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Medical_Industry_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientDetailsController : ControllerBase
    {

        private readonly IConfiguration _configuration;

        public PatientDetailsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        // GET: api/<PatientController>
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

            return new JsonResult(table);
        }


        // POST api/<PatientController>
        [HttpPost]
        public JsonResult Post(Patient req)
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
            return new JsonResult("Patient Added Successfully");
        }

        // PUT api/<PatientController>/5
        [HttpPut("{id}")]
        public void Put(int id, Patient req)
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

        // DELETE api/<PatientController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"
                    delete from dbo.PatientRecords
                    where PatientId = " + id + @" 
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
            return new JsonResult("Patient Deleted Successfully");
        }
    }
}
