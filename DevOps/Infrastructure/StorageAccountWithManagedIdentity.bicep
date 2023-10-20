param storageAccountName string

@allowed([
  'Storage'
  'StorageV2'
])
param storageKind string = 'StorageV2'

@description('Storage Account type')
@allowed([
  'Standard_LRS'
  'Standard_GRS'
  'Standard_RAGRS'
  'Standard_ZRS'
  'Premium_LRS'
  'Premium_ZRS'
  'Standard_GZRS'
  'Standard_RAGZRS'
])
param storageAccountType string = 'Standard_GRS'

@description('Location for all resources.')
param location string = resourceGroup().location
param userManagedIdentityName string

resource storageAccount 'Microsoft.Storage/storageAccounts@2018-07-01' = {
  name: storageAccountName
  location: location
  sku: {
    name: storageAccountType
  }
  kind: storageKind
  properties: {}
  identity: {
    type: 'UserAssigned'
    userAssignedIdentities: {
      '${resourceId('Microsoft.ManagedIdentity/userAssignedIdentities/', userManagedIdentityName)}': {}
    }
  }
}