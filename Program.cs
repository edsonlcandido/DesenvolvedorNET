using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Markdig;
using Microsoft.Data.Sqlite;
using EvolveDb;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using DesenvolvedorNET.Repositories;
using DesenvolvedorNET.Db;
using Microsoft.EntityFrameworkCore;
using DesenvolvedorNET.Models;
using Microsoft.AspNetCore.Identity;

namespace DesenvolvedorNET
{ 
    public class Program
    {
        public static void Main(string[] args)
        {
            SQLitePCL.raw.SetProvider(new SQLitePCL.SQLite3Provider_e_sqlite3());

            var outputPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory());
            if (!System.IO.Directory.Exists(outputPath))
            {
                System.IO.Directory.CreateDirectory(outputPath);
            }

            var cnx = new SqliteConnection($@"Data Source={System.IO.Path.Combine(outputPath, "DesenvolvedorNET.db")}");
            var evolve = new Evolve(cnx)
            {
                Locations = new[] { "Db" },
                IsEraseDisabled = true,
            };
            evolve.Migrate();

            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddMvc(opttions =>
            {
                opttions.EnableEndpointRouting = false;
            });

            //configure the connection string to database
            builder.Services.AddDbContext<EmpregadosContext>(options =>
            {
                options.UseSqlite($@"Data Source={System.IO.Path.Combine(outputPath, "DesenvolvedorNET.db")}");
            });
            //configure the connection string to database estoque
            builder.Services.AddDbContext<EstoqueDbContext>(options =>
            {
                options.UseSqlite($@"Data Source={System.IO.Path.Combine(outputPath, "Estoque.db")}");
            });
            builder.Services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<EstoqueDbContext>();

            var app = builder.Build();

            //migrate dbcontext
            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<EmpregadosContext>();
                db.Database.Migrate();
                db.SaveChanges();

                var dbEstoque = scope.ServiceProvider.GetRequiredService<EstoqueDbContext>();
                dbEstoque.Database.Migrate();
                dbEstoque.SaveChanges();
            }

            IHostEnvironment env = app.Services.GetService<IHostEnvironment>();

            if (env.IsDevelopment())
            {
                //create a DeveloperExceptionPageOptions with default values
                DeveloperExceptionPageOptions developerExceptionPageOptions = new DeveloperExceptionPageOptions();
                developerExceptionPageOptions.SourceCodeLineCount = 6;
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseStatusCodePagesWithReExecute("/Error/{0}");                              
            }

            //create a StaticFileoptions with default values
            StaticFileOptions staticFileOptions = new StaticFileOptions();
            staticFileOptions.DefaultContentType = "None";
            staticFileOptions.ServeUnknownFileTypes = false;
            app.UseStaticFiles(staticFileOptions);
            app.MapAreaControllerRoute(
                name: "Estoque",
                areaName: "Estqoue",
                pattern: "Estoque/{controller=Home}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");          

            app.Run();
        }
    }
}