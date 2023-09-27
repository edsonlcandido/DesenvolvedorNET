using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Markdig;
using Microsoft.Data.Sqlite;
using EvolveDb;

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
            builder.Services.AddMvc();
            builder.Services.AddRazorPages();

            var app = builder.Build();

            app.UseStaticFiles();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();  
                
            });

            app.Run();
        }
    }
}