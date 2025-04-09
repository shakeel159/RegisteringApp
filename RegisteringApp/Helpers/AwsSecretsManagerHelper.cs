using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class AwsSecretsManagerHelper
{
    private readonly string _secretName;
    private readonly AmazonSecretsManagerClient _client;

    public AwsSecretsManagerHelper(string secretName, string region)
    {
        _secretName = secretName;
        _client = new AmazonSecretsManagerClient(Amazon.RegionEndpoint.GetBySystemName(region));
    }

    public async Task<string> GetConnectionStringAsync()
    {
        try
        {
            var request = new GetSecretValueRequest { SecretId = _secretName };
            var response = await _client.GetSecretValueAsync(request);

            var secretJson = JsonConvert.DeserializeObject<Dictionary<string, string>>(response.SecretString);
            return $"Server={secretJson["host"]};Database={secretJson["dbname"]};User Id={secretJson["username"]};Password={secretJson["password"]};";
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error retrieving secret: {ex.Message}");
            throw;
        }
    }
}