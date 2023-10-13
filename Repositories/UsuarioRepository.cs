using Dapper;
using DesenvolvedorNET.Models;
using Microsoft.Data.Sqlite;
using Microsoft.Data.Sqlite;

namespace DesenvolvedorNET.Repositories
{
    public class UsuarioRepository
    {
        //class to access database using Dapper ORM e Sqlite database for UsuarioModel
        //create a method to get all Usuarios from database
        //create a method to get a Usuario by id from database
        //create a method to insert a Usuario in database
        //create a method to update a Usuario in database
        //create a method to delete a Usuario in database
        //Usuario model is in Models/UsuarioModel.cs

        private static string _conectionString
        {
            get { return $@"Data Source={System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "DesenvolvedorNET.db")}"; }
        }

        //method to get all Usuarios from database
        public static async Task<IEnumerable<Usuario>> GetAll()
        {
            using (var cnn = new SqliteConnection(_conectionString))
            {
                string query = "SELECT * FROM Usuarios";
                var usuarios = await cnn.QueryAsync<Usuario>("SELECT * FROM Usuarios");
                return usuarios;
            }
        }
        //method to get a Usuario by id from database
        public static async Task<Usuario> GetById(string id)
        {
            using (var cnn = new SqliteConnection(_conectionString))
            {
                string query = "SELECT * FROM Usuarios WHERE Id = @Id";
                var usuario = await cnn.QueryFirstOrDefaultAsync<Usuario>(query, new { Id = id });
                return usuario;
            }
        }
        //method to insert a Usuario in database
        public static async Task<int> Insert(Usuario usuario)
        {
            using (var cnn = new SqliteConnection(_conectionString))
            {
                string query = "INSERT INTO Usuarios (Id, Nome) VALUES (@Id, @Nome)";
                var result = await cnn.ExecuteAsync(query, usuario);
                return result;
            }
        }
        //method to update a Usuario in database
        public static async Task<int> Update(Usuario usuario)
        {
            using (var cnn = new SqliteConnection(_conectionString))
            {
                string query = "UPDATE Usuarios SET Nome = @Nome WHERE Id = @Id";
                var result = await cnn.ExecuteAsync(query, usuario);
                return result;
            }
        }   
        //method to delete a Usuario in database
        public static async Task Delete(string id)
        {
            using (var cnn = new SqliteConnection(_conectionString))
            {
                string query = "DELETE FROM Usuarios WHERE Id = @Id";
                await cnn.ExecuteAsync(query, new { Id = id });                
            }
        }
    }
}
