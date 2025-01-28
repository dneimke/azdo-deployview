param databaseName string
param containerName string

resource database 'Microsoft.DocumentDB/databaseAccounts/sqlDatabases@2022-05-15' existing = {
  name: databaseName
}

resource container 'Microsoft.DocumentDB/databaseAccounts/sqlDatabases/containers@2022-05-15' = {
  parent: database // Use the databaseName parameter
  name: containerName
  properties: {
    resource: {
      id: containerName
      indexingPolicy: {
        automatic: true
        includedPaths: [
          {
            path: '/environment/*'
          }
          {
            path: '/project/*'
          }
        ]
        excludedPaths: []
      }
    }
  }
}
