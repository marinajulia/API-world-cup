using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using WorldCup.Api.Infra;
using WorldCup.Infra.Data;
using WorldCup.Infra.Repositories.Player;
using WorldCup.Infra.Repositories.Team;
using WorldCup.Infra.Repositories.UnitOfWork;
using WorldCup.Infra.UnitOfWork;

namespace WorldCup
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers()
                //para resolover o problema de depend�ncia circular
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "EFCore.ApiWorldCup", Version = "v1" });
            });

            services.AddDbContext<ApplicationContext>(p => p.UseSqlServer(@"Data Source=DESKTOP-RTPBNVC\SQLEXPRESS;Initial Catalog=WorldCupAPI;Integrated Security=True;")
            );

            services.Resolve();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EFCore.ApiWorldCup v1"));
            }

            //InicializarBaseDeDados(app);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        //private void InicializarBaseDeDados(IApplicationBuilder app)
        //{
        //    using var db = app
        //        .ApplicationServices
        //        .CreateScope()
        //        .ServiceProvider
        //        .GetRequiredService<ApplicationContext>();

        //    if (db.Database.EnsureCreated())
        //    {
        //        db.Departamentos.AddRange(Enumerable.Range(1, 10)
        //            .Select(p => new Departamento
        //            {
        //                Descricao = $"Departamento = {p}",
        //                Colaboradores = Enumerable.Range(1, 10)
        //                    .Select(x => new Colaborador
        //                    {
        //                        Nome = $"Colaborador: {x}/{p}"
        //                    }).ToList()
        //            }));

        //        db.SaveChanges();
        //    }
        //}
    }
}