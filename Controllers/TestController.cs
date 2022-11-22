using Medical_Industry_API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;

namespace Medical_Industry_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController
    {

        private readonly IConfiguration _configuration;

        public TestController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        // GET api/<TestController>/5
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

        // POST api/<TestController>
        [HttpPost]
        public JsonResult Post(Test req)
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
            return new JsonResult("Test Added Successfully");
        }

        // PUT api/<TestController>/5
        [HttpPut("{id}")]
        public void Put(int id, Test req)
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

        // DELETE api/<TestController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"
                    delete from dbo.PatientRecords
                    where TestId = " + id + @" 
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
            return new JsonResult("Test Deleted Successfully");
        }
    }
}
