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

        internal static Task<Departamento> GetById(int departamentoId, EmpregadosContext dbContext)
        {
            return dbContext.Departamentos.Where(d => d.Id == departamentoId).FirstOrDefaultAsync();
        }
    }
}
