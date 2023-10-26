using Apps.Dataprocessor.Common.Interfaces;
using Azure.Core;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.Extensions.Configuration;
using System;

namespace Apps.Dataprocessor.Common
{
    public class KeyVaultSecretReader : ISecretReader
    {
        private readonly IConfiguration configuration;

        public KeyVaultSecretReader(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public string GetSecret(string secretLocationUri, string secretName)
        {
            SecretClientOptions options = new SecretClientOptions()
            {
                Retry =
                {
                    Delay= TimeSpan.FromSeconds(2),
                    MaxDelay = TimeSpan.FromSeconds(16),
                    MaxRetries = 5,
                    Mode = RetryMode.Exponential
                 }
            };

            var credential = new ChainedTokenCredential( 
                new ManagedIdentityCredential(),
                new VisualStudioCredential(new VisualStudioCredentialOptions { TenantId = configuration["TenantId"] }),
                new DefaultAzureCredential(
                new DefaultAzureCredentialOptions
                {
                    ManagedIdentityClientId = configuration["UserAssignedManagedIdentityClientId"]
                }));

            var client = new SecretClient(new Uri(secretLocationUri), credential, options);

            KeyVaultSecret secret = client.GetSecret(secretName);

            return secret.Value;

        }
    }
}
