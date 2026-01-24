using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace SqlAdapter;

public class AppDbCtx : DbContext {

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        var cfg = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
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
