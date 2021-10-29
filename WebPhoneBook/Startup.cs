using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebPhoneBook.DataBaseAccess;

namespace WebPhoneBook
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            DataBase phoneBook = new DataBase();
            phoneBook.Connect();

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

                    foreach (var person in phoneBook.repository.GetDB())
                    {
                        content.Append("<tr>");
                        content.Append($"<td><font color='black' size='5'>{person.Id}</font></td>");
                        content.Append($"<td><font color='black' size='5'>{person.LastName}</font></td>");
                        content.Append($"<td><font color='black' size='5'>{person.FirstName}</font></td>");
                        content.Append($"<td><font color='black' size='5'>{person.MiddleName}</font></td>");
                        content.Append("</tr>");
                    }


                    content.Append("</table");

                    await context.Response.WriteAsync($"<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\">\n{content}");
                });
            });
        }
    }
}
