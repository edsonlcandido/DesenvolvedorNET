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
        public static async Task<IEnumerable<Empregado>> GetAll(EmpregadosContext context)
        {
            //get empregados from database, LINQ query for get departamentos
            return await context.Empregados.Include(e => e.Departamento).ToListAsync();
        }
        public static async Task<Empregado> GetById(int id, EmpregadosContext context)
        {
            //get empregado from database, LINQ query for get empregado

            return await context.Empregados.Where(e=> e.Id == id)
                .Include(e=>e.Departamento)
                .FirstOrDefaultAsync();
        }
        public static async Task Add(Empregado empregado, EmpregadosContext context)
        {
            context.Empregados.Add(empregado);
            await context.SaveChangesAsync();
        }

        public static async Task Update(Empregado empregado, EmpregadosContext context)
        {
            context.Update(empregado);
            await context.SaveChangesAsync();
        }

        public static async Task Delete(Empregado empregado, EmpregadosContext context)
        {
            context.Remove(empregado);
            await context.SaveChangesAsync();
        }
    }
}
