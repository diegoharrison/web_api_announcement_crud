using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Model;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnuncioController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public AnuncioController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult GetAnuncio()
        {
            string query = @"SELECT * FROM TESTE_WEBMOTORS..TB_ANUNCIOWEBMOTORS";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("AnuncioAppConfig");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }

        [HttpPost]
        public JsonResult PostAnuncio(Anuncio anuncio)
        {
            string query = @"
                           INSERT INTO DBO.TB_ANUNCIOWEBMOTORS
                           VALUES (@AnuncioMarca,
                                   @AnuncioModelo, 
                                   @AnuncioVersao, 
                                   @AnuncioAno,
                                   @AnuncioQuilometragem,
                                   @AnuncioObs
                           )
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("AnuncioAppConfig");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@AnuncioMarca", anuncio.Marca);
                    myCommand.Parameters.AddWithValue("@AnuncioModelo", anuncio.Modelo);
                    myCommand.Parameters.AddWithValue("@AnuncioVersao", anuncio.Versao);
                    myCommand.Parameters.AddWithValue("@AnuncioAno", anuncio.Ano);
                    myCommand.Parameters.AddWithValue("@AnuncioQuilometragem", anuncio.Quilometragem);
                    myCommand.Parameters.AddWithValue("@AnuncioObs", anuncio.Observacao);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Added Successfully");
        }

        [HttpPut]
        public JsonResult PutAnuncio(Anuncio anuncio)
        {
            string query = @"
                           UPDATE DBO.TB_ANUNCIOWEBMOTORS SET 
                               MARCA  = @AnuncioMarca,
                               MODELO = @AnuncioModelo, 
                               VERSAO = @AnuncioVersao, 
                               ANO = @AnuncioAno,
                               QUILOMETRAGEM = @AnuncioQuilometragem,
                               OBSERVACAO = @AnuncioObs
                               WHERE ID = @AnuncioId
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("AnuncioAppConfig");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@AnuncioId", anuncio.Id);
                    myCommand.Parameters.AddWithValue("@AnuncioMarca", anuncio.Marca);
                    myCommand.Parameters.AddWithValue("@AnuncioModelo", anuncio.Modelo);
                    myCommand.Parameters.AddWithValue("@AnuncioVersao", anuncio.Versao);
                    myCommand.Parameters.AddWithValue("@AnuncioAno", anuncio.Ano);
                    myCommand.Parameters.AddWithValue("@AnuncioQuilometragem", anuncio.Quilometragem);
                    myCommand.Parameters.AddWithValue("@AnuncioObs", anuncio.Observacao);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Update Successfully");
        }

        [HttpDelete("{id}") ]
        public JsonResult DeleteAnuncio(Anuncio Anuncio)
        {
            string query = @"
                           DELETE FROM DBO.TB_ANUNCIOWEBMOTORS WHERE ID = @AnuncioId";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("AnuncioAppConfig");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@AnuncioId", Anuncio.Id);      
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Delete Successfully");
        }
    }
}
