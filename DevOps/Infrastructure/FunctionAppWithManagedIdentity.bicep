param appName string
param location string = 'West Europe'
param appServicePlanName string
param alwaysOn bool = true
param storageAccountName string
param applicationInsightsInstrumentationKey string
param resourceGroup string = resourceGroup().name
param extensionVersion string = '~4'
param workerRuntime string = 'dotnet'
param identityName string

resource app 'Microsoft.Web/sites@2018-02-01' = {
  kind: 'functionapp'
  name: appName
  location: location
  identity: {
    type: 'UserAssigned'
    userAssignedIdentities: {
      '${resourceId('Microsoft.ManagedIdentity/userAssignedIdentities/', identityName)}': {}
    }
  }
  properties: {
    clientAffinityEnabled: false
    serverFarmId: '/subscriptions/${subscription().subscriptionId}/resourcegroups/${resourceGroup}/providers/Microsoft.Web/serverfarms/${appServicePlanName}'
    use32BitWorkerProcess: false
    httpsOnly: true
    siteConfig: {
      alwaysOn: alwaysOn
      appSettings: [
        {
          name: 'FUNCTIONS_WORKER_RUNTIME'
          value: workerRuntime
        }
        {
          name: 'AzureWebJobsStorage'
          value: 'DefaultEndpointsProtocol=https;AccountName=${storageAccountName};AccountKey=${listKeys(resourceId('Microsoft.Storage/storageAccounts', storageAccountName), '2015-05-01-preview').key1}'
        }
        {
          name: 'FUNCTIONS_EXTENSION_VERSION'
          value: extensionVersion
        }
        {
          name: 'WEBSITE_CONTENTAZUREFILECONNECTIONSTRING'
          value: 'DefaultEndpointsProtocol=https;AccountName=${storageAccountName};AccountKey=${listKeys(resourceId('Microsoft.Storage/storageAccounts', storageAccountName), '2015-05-01-preview').key1}'
        }
        {
          name: 'WEBSITE_CONTENTSHARE'
          value: '${toLower(appName)}a5de'
        }
        {
          name: 'APPINSIGHTS_INSTRUMENTATIONKEY'
          value: applicationInsightsInstrumentationKey
        }     
      ]
    }
  }
}
