using Microsoft.Extensions.DependencyInjection;
using WorldCup.Domain.Service.Player;
using WorldCup.Domain.Service.Team;
using WorldCup.Infra.Data;
using WorldCup.Infra.Repositories.Player;
using WorldCup.Infra.Repositories.Team;
using WorldCup.Infra.Repositories.UnitOfWork;
using WorldCup.Infra.UnitOfWork;
using WorldCup.SharedKernel.Notification;

namespace WorldCup.Api.Infra
{
    public static class DependencyResolver
    {
        public static void Resolve(this IServiceCollection services)
        {
            //var mappingConfig = new MapperConfiguration(m =>
            //{
            //    m.AddProfile(new AutoMapperProfile());
            //});

            //var mapper = mappingConfig.CreateMapper();
            //services.AddSingleton(mapper);

            services.AddScoped<INotification, Notification>();
            services.AddDbContext<ApplicationContext>();

            Context(services);
            Repositories(services);
            Services(services);
        }
        public static void Context(IServiceCollection services)
        {
            services.AddScoped<ApplicationContext, ApplicationContext>();

        }
        public static void Repositories(IServiceCollection services)
        {
            services.AddScoped<IPlayerRepository, PlayerRepository>();
            services.AddScoped<ITeamRepository, TeamRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public static void Services(IServiceCollection services)
        {
            services.AddScoped<ITeamService, TeamService>();
            services.AddScoped<IPlayerService, PlayerService>();
        }
    }
}
