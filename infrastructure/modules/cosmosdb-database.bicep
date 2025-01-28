param cosmosDbName string
param databaseName string

resource cosmosDb 'Microsoft.DocumentDB/databaseAccounts@2022-05-15' existing = {
  name: cosmosDbName
}

resource database 'Microsoft.DocumentDB/databaseAccounts/sqlDatabases@2022-05-15' = {
  parent: cosmosDb
  name: databaseName
  properties: {
    resource: {
      id: databaseName
    }
  }
}

output databaseName string = database.name
