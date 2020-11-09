﻿using Microsoft.EntityFrameworkCore;
using SeekQ.MyConnections.Api.Domain.ConnectionsAggregate;
using SeekQ.MyConnections.Api.Infrastructure.EntityConfigurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeekQ.MyConnections.Api.Infrastructure
{
    public class MyConnectionsDbContext : DbContext
    {
        public MyConnectionsDbContext(DbContextOptions<MyConnectionsDbContext> options)
            : base(options)
        {

        }

        public DbSet<Connection> Connections { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ConnectionEntityConfiguration());
        }
    }
}
