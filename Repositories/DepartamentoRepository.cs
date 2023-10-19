using DesenvolvedorNET.Db;
using DesenvolvedorNET.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace DesenvolvedorNET.Repositories
{
    public class DepartamentoRepository
    {
        public static async Task<IEnumerable<Departamento>> GetAll(EmpregadosContext context)
        {                
                return await context.Departamentos.ToListAsync();            
        }
        public static async Task<Departamento> GetById(int id, EmpregadosContext context)
        {
            return await context.Departamentos.FindAsync(id);
        }
    }
}
