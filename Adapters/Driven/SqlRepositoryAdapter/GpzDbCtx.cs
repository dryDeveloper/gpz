using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SqlRepositoryAdapter.Entities;

namespace SqlRepositoryAdapter;

public class GpzDbCtx : DbContext {

    public DbSet<UserEntity> Users { get; set; }
    public DbSet<UserProfileEntity> UserProfiles { get; set; }
    public DbSet<AddressEntity> Addresses { get; set; }
    public DbSet<AddressTypeEntity> AddressType { get; set; }
    public DbSet<AddressNumberEntity> AddressNumbers { get; set; }
    public DbSet<ClientEntity> Clients { get; set; }
    public DbSet<PersonalReferenceEntity> PersonalReferences { get; set; }
    public DbSet<PhoneNumberEntity> PhoneNumbers { get; set; }
    public DbSet<PhoneTypeEntity> PhoneType { get; set; }
    public DbSet<RequestTypeEntity> RequestType { get; set; }
    public DbSet<ProjectTypeEntity> ProjectType { get; set; }
    public DbSet<ClientCreditRequestEntity> ClientCreditRequests { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {

        modelBuilder.Entity<ClientCreditRequestEntity>()
            .HasMany(e => e.Addresses)
            .WithOne(e => e.ClientCreditRequestEntity)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<ClientCreditRequestEntity>()
            .HasMany(e => e.PhoneNumbers)
            .WithOne(e => e.ClientCreditRequestEntity)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<ClientCreditRequestEntity>()
            .HasMany(e => e.PersonalReferences)
            .WithOne(e => e.ClientCreditRequestEntity)
            .OnDelete(DeleteBehavior.NoAction);

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        var basePath = Directory.GetCurrentDirectory();
        var cfg = new ConfigurationBuilder().SetBasePath(basePath).AddJsonFile(
            "config.json", 
            optional: false,
            reloadOnChange: true
        ).Build();
        var conn = cfg.GetSection("dbParams")["conn"];
        optionsBuilder.UseSqlServer(conn);
        base.OnConfiguring(optionsBuilder);
    }
}

