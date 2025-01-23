using EventManagement.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.SqlClient;

namespace EventManagement.Controllers
{
    public class EventosController : ApiController
    {
        private string connectionString = "server=127.0.0.1;port=3080;database=eventmanagement;uid=root;pwd=root";

        // Obtener la lista de eventos
        [HttpGet]
        public IHttpActionResult Get()
        {
            List<Evento> eventos = new List<Evento>();
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "SELECT * FROM Evento";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var evento = new Evento
                    {
                        ID = reader.GetInt32("ID"),
                        Titulo = reader.GetString("Titulo"),
                        Descripcion = reader.GetString("Descripcion"),
                        Lugar = reader.GetString("Lugar"),
                        Fecha = reader.GetDateTime("Fecha")
                    };
                    eventos.Add(evento);
                }
            }
            return Ok(eventos);
        }

        // Agregar un nuevo evento
        [HttpPost]
        public IHttpActionResult Post([FromBody] Evento evento)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "INSERT INTO Evento (Titulo, Descripcion, Lugar, Fecha, UsuarioID) VALUES (@Titulo, @Descripcion, @Lugar, @Fecha, @UsuarioID)";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Titulo", evento.Titulo);
                cmd.Parameters.AddWithValue("@Descripcion", evento.Descripcion);
                cmd.Parameters.AddWithValue("@Lugar", evento.Lugar);
                cmd.Parameters.AddWithValue("@Fecha", evento.Fecha);
                cmd.Parameters.AddWithValue("@UsuarioID", evento.UsuarioID);
                cmd.ExecuteNonQuery();
            }
            return Ok(evento);
        }

        // Editar un evento
        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody] Evento evento)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "UPDATE Evento SET Titulo = @Titulo, Descripcion = @Descripcion, Lugar = @Lugar, Fecha = @Fecha WHERE ID = @ID";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Titulo", evento.Titulo);
                cmd.Parameters.AddWithValue("@Descripcion", evento.Descripcion);
                cmd.Parameters.AddWithValue("@Lugar", evento.Lugar);
                cmd.Parameters.AddWithValue("@Fecha", evento.Fecha);
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.ExecuteNonQuery();
            }
            return Ok(evento);
        }

        // Eliminar un evento
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "DELETE FROM Evento WHERE ID = @ID";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.ExecuteNonQuery();
            }
            return Ok();
        }
    }
}