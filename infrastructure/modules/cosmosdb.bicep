param location string

@description('Azure Cosmos DB account name, max length 44 characters')
param accountName string = 'sql-${uniqueString(resourceGroup().id)}'

@description('The partition key for the container')
param partitionKeyPath string = '/partitionKey'

@minValue(400)
@maxValue(1000000)
@description('The throughput for the container')
param throughput int = 400

var locations = [
  {
    locationName: location
    failoverPriority: 0
    isZoneRedundant: false
  }
]

var databaseName = '${accountName}-db'
var containerName = 'deployments'

resource cosmosService 'Microsoft.DocumentDB/databaseAccounts@2022-05-15' = {
  name: accountName
  location: location
  kind: 'GlobalDocumentDB'
  properties: {
    locations: locations
    databaseAccountOfferType: 'Standard'
  }
}

resource database 'Microsoft.DocumentDB/databaseAccounts/sqlDatabases@2022-05-15' = {
  parent: cosmosService
  name: databaseName
  properties: {
    resource: {
      id: databaseName
    }
  }
}

resource container 'Microsoft.DocumentDB/databaseAccounts/sqlDatabases/containers@2022-05-15' = {
  parent: database
  name: containerName
  properties: {
    resource: {
      id: containerName
      indexingPolicy: {
        automatic: true
        includedPaths: [
          {
            path: '/'
          }
        ]
        excludedPaths: []
      }
      partitionKey: {
        paths: [
          '/ReleasePipeline'
          '/Stage'
        ]
        kind: 'Hash'
      }
      defaultTtl: 86400
    }
    options: {
      throughput: throughput
    }
  }
}

output cosmosAccountId string = cosmosService.id
output cosmosAccountName string = cosmosService.name
