using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SqlAdapter.Entities;

namespace SqlAdapter;

public class GpzDbContext : DbContext {

    public DbSet<UserDto> Users => Set<UserDto>();
    public DbSet<AddressEntity> Addresses => Set<AddressEntity>();
    public DbSet<AddressNumberEntity> AddressNumbers => Set<AddressNumberEntity>();
    public DbSet<ClientEntity> Clients => Set<ClientEntity>();
    public DbSet<PhoneNumberEntity> PhoneNumbers => Set<PhoneNumberEntity>();
    public DbSet<PersonalReferenceEntity> PersonalReferences => Set<PersonalReferenceEntity>();
    // Solicitudes(ClientCreditRequest)
    public DbSet<ClientCreditRequestEntity> ClientCreditRequests => Set<ClientCreditRequestEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.Entity<UserDto>()
            .Property(w => w.Profile)
            .HasConversion<int>();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        var basePath = Directory.GetCurrentDirectory();
        var cfg = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile(
                "config.json", 
                optional: false,
                reloadOnChange: true
            ).Build();
        var conn = cfg.GetSection("dbParams")["conn"];
        optionsBuilder.UseSqlServer(conn);
        base.OnConfiguring(optionsBuilder);
    }
}
