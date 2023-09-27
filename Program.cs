using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Markdig;


namespace DesenvolvedorNET 
{ 
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddMvc();

            var app = builder.Build();

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                 endpoints.MapGet("/", async context =>
                {
                    var md = System.IO.File.ReadAllText("README.md");
                    var html = Markdown.ToHtml(md);
                    await context.Response.WriteAsync(html);
                });
            });

            app.Run();
        }
    }
}