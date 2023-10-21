param serverName string
param administratorLogin string
param administratorLoginPassword string

resource server 'Microsoft.Sql/servers@2019-06-01-preview' = {
  name: serverName
  location: resourceGroup().location
  properties: {
    version: '12.0'
    administratorLogin: administratorLogin
    administratorLoginPassword: administratorLoginPassword
    minimalTlsVersion: '1.2'
  }
}