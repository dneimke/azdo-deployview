param location string
param cosmosDbName string

var locations = [
  {
    locationName: location
    failoverPriority: 0
    isZoneRedundant: false
  }
]

resource cosmosDb 'Microsoft.DocumentDB/databaseAccounts@2022-05-15' = {
  name: cosmosDbName
  location: location
  kind: 'GlobalDocumentDB'
  properties: {
    locations: locations
    databaseAccountOfferType: 'Standard'
  }
}

output cosmosDbName string = cosmosDb.name // Output the name for use in other modules
