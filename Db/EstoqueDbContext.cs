using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DesenvolvedorNET.Db
{
    //add support to entity framework core identity
    public class EstoqueUsuario : IdentityUser
    {
    }

    public class EstoqueDbContext : DbContext
    {
    }
}
