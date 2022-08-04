using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using wsSolicitud.Models;

public class SolicitudContext : DbContext {

  private readonly IConfiguration config;
  
  public DbSet<Solicitud> Solicitud { get; set; }

  public SolicitudContext(IConfiguration config, DbContextOptions<SolicitudContext> options) :
    base (options) {
    this.config = config;
  }

  protected override void OnConfiguring(DbContextOptionsBuilder options) {
    if (!options.IsConfigured)
      options.UseMySql(
          config.GetConnectionString("MySql"),
          Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.8.3-mariadb")
      );
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder) {
    modelBuilder.Entity<Solicitud>().ToTable("Solicitud");
  }

}

