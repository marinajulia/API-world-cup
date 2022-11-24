﻿using Microsoft.EntityFrameworkCore;
using WorldCup.Domain.Service.Player.Entity;
using WorldCup.Domain.Service.Team.Entity;

namespace WorldCup.Infra.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<PlayerEntity> Players { get; set; }
        public DbSet<TeamEntity> Teams { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }
    }
}
