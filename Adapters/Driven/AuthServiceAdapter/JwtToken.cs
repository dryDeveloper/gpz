using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Core.Dtos;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Ports.Driven;

namespace AuthServiceAdapter;

public class JwtToken(IConfigurationRoot cfg) : IAuthToken {

    public string Generate(UserDto user) {
        var apiCfg = cfg.GetSection("api");
        var creds = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(apiCfg["jwt:key"]!)),
            // securityKey, 
            SecurityAlgorithms.HmacSha256
        );
        var claims = new [] {
            new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Role, "user")
        };
        Console.WriteLine($"ISSUER: {apiCfg["jwt:issuer"]}");
        Console.WriteLine($"AUDIENCE: {apiCfg["jwt:audience"]}");
        var token = new JwtSecurityToken(
            issuer: apiCfg["jwt:issuer"],
            audience: apiCfg["jwt:audience"],
            claims: claims,
            expires: DateTime.Now.AddHours(1),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

}
