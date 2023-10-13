using DesenvolvedorNET.Db;
using DesenvolvedorNET.Models;
using Microsoft.EntityFrameworkCore;

namespace DesenvolvedorNET.Repositories
{
    public class EmpregadoRepository
    {
        //class to access database using ef core for EmpregadoModel using DesenvolvedorNETContext
        //create a method to get all Empregados from database
        //create a method to get a Empregado by id from database
        //create a method to insert a Empregado in database
        //create a method to update a Empregado in database
        //create a method to delete a Empregado in database
        //Empregado model is in Models/EmpregadoModel.cs
        public static async Task<IEnumerable<Empregado>> GetAll(DesenvolvedorNETContext context)
        {
            return await context.Empregados.ToListAsync();
        }
    }
}
