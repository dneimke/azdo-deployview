param location string = resourceGroup().location
param environmentName string
param appName string = 'azdodeploy'

// Tags
var tags = {
  environment: environmentName
  application: appName
}

// Storage Account
module storage './storageAccount.bicep' = {
  name: 'storageAccount'
  params: {
    location: location
    environmentName: environmentName
    tags: tags
    appName: appName
  }
}

// Application Insights
module appInsights './appInsights.bicep' = {
  name: 'appInsights'
  params: {
    location: location
    tags: tags
    appName: appName
  }
}

// Function App and related resources
module functionApp './functionApp.bicep' = {
  name: 'functionApp'
  params: {
    location: location
    appName: appName
    environmentName: environmentName
    tags: tags
    storageAccountName: storage.outputs.storageAccountName
    storageAccountKey: storage.outputs.storageAccountKey
    appInsightsKey: appInsights.outputs.instrumentationKey
  }
}

output functionAppName string = functionApp.outputs.functionAppName