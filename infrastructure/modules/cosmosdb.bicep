param location string
param cosmosDbName string

var locations = [
  {
    locationName: location
    failoverPriority: 0
    isZoneRedundant: false
  }
]

var databaseName = '${cosmosDbName}-db'
// var containerName = 'releases'

resource cosmosService 'Microsoft.DocumentDB/databaseAccounts@2022-05-15' = {
  name: cosmosDbName
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

// resource container 'Microsoft.DocumentDB/databaseAccounts/sqlDatabases/containers@2022-05-15' = {
//   parent: database // Use the databaseName parameter
//   name: containerName
//   properties: {
//     resource: {
//       id: containerName
//       indexingPolicy: {
//         automatic: true
//         includedPaths: [
//           {
//             path: '/environment/*'
//           }
//           {
//             path: '/project/*'
//           }
//         ]
//         excludedPaths: []
//       }
//     }
//   }
// }

output cosmosDbName string = cosmosService.name // Output the name for use in other modules
