using System.Data;
using MySql.Data.MySqlClient;

public class SolicitudContext {

  private readonly IConfiguration config;
  private readonly string connectionString;

  public SolicitudContext(IConfiguration config) {
    this.config = config;
    connectionString = this.config.GetConnectionString("MySql");
  }

  public IDbConnection CreateConnection() => new MySqlConnection(connectionString);


}

