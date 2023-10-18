@minLength(5)
param appServicePlanName string

resource appServicePlan 'Microsoft.Web/serverfarms@2015-08-01' = {
  kind: 'app'
  location: resourceGroup().location
  name: appServicePlanName
  properties: {
    name: appServicePlanName
    numberOfWorkers: 1
  }
  sku: {
    name: 'Y1'
    tier: 'Dynamic'
    size: 'Y1'
    family: 'Y'
    capacity: 1
  }
}