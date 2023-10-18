@description('<USER ASSIGNED IDENTITY NAME>')
param IdentityName string

resource Identity 'Microsoft.ManagedIdentity/userAssignedIdentities@2018-11-30' = {
  name: IdentityName
  location: resourceGroup().location
}