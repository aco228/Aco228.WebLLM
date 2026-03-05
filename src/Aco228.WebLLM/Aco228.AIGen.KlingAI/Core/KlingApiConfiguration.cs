using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Aco228.Common.Services;
using Aco228.WService.Base;
using Microsoft.IdentityModel.Tokens;

namespace Aco228.AIGen.KlingAI.Core;

public class KlingApiConfiguration : ApiServiceConf
{
    public override string BaseUrl => "https://api.klingai.com/v1/";
    private static string AccessKey { get; set; }
    private static string SecretKey { get; set; }

    public KlingApiConfiguration(ISecretProvider secretProvider)
    {
        AccessKey = secretProvider.Get("KLING_AI_API_ACCESS_KEY") ?? throw new InvalidOperationException("KlingAIAccessKey is not set");
        SecretKey = secretProvider.Get("KLING_AI_API_SECRET") ?? throw new InvalidOperationException("KlingAIAccessKey is not set");
    }

    override public HttpClient Prepare(HttpClient httpClient)
    {
        httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {GenerateJwt()}");
        return httpClient;
    }

    private string GenerateJwt()
    {
        var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(SecretKey));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            claims: new[]
            {
                new Claim("iss", AccessKey)
            },
            notBefore: DateTime.UtcNow.AddSeconds(-5),
            expires: DateTime.UtcNow.AddMinutes(30),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}