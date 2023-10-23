param serverName string
param databaseName string

@allowed([
  'Free'
  'Basic'
  'Standard'
  'Premium'
])
param edition string = 'Free'


resource database 'Microsoft.Sql/servers/databases@2019-06-01-preview' = {
  name: '${serverName}/${databaseName}'
  location: resourceGroup().location
  properties: {
    collation: 'SQL_Latin1_General_CP1_CI_AS'
    edition: edition
    maxSizeBytes: 1073741824  // 1GB for free tier
  }
}
