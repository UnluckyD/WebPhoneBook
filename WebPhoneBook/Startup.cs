using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Text;
using WebPhoneBook.Domain;
using Microsoft.EntityFrameworkCore;

namespace WebPhoneBook
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<PhoneBookRepository>();
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
            @"Data Source=(local)\mssqllocaldb; Database=PhoneBookDb; Persist Security Info=False; MultipleActiveResultSets=True; Trusted_Connection=True;"
            ));
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    var content = new StringBuilder();
                    content.Append("<table border='2'>");

                    foreach (var person in )
                    {
                        content.Append("<tr>");
                        content.Append($"<td><font color='black' size='5'>{person.Id}</font></td>");
                        content.Append($"<td><font color='black' size='5'>{person.LastName}</font></td>");
                        content.Append($"<td><font color='black' size='5'>{person.FirstName}</font></td>");
                        content.Append($"<td><font color='black' size='5'>{person.MiddleName}</font></td>");
                        content.Append("</tr>");
                    }


                    content.Append("</table");

                    await context.Response.WriteAsync($"<!DOCTYPE html>\n<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\">\n{content}");
                });
            });
        }
    }
}
