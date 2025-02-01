@description('Azure region for all resources')
param location string = resourceGroup().location

@description('Environment name (dev, test, prod)')
@allowed(['dev', 'test', 'prod'])
param environmentName string

@description('Application name - will be used as prefix for resources')
@minLength(3)
@maxLength(11)
param appName string = 'azdodeploy'

// Generate unique suffix
var uniqueSuffix = uniqueString(resourceGroup().id, appName, environmentName)

// Tags
var tags = {
  environment: environmentName
  application: appName
}

// Storage Account
module storageModule './modules/storageAccount.bicep' = {
  name: 'storageAccount'
  params: {
    location: location
    tags: tags
    appName: appName
    uniqueSuffix: uniqueSuffix
  }
}

// Application Insights
module appInsightsModule './modules/appInsights.bicep' = {
  name: 'appInsights'
  params: {
    location: location
    tags: tags
    appName: appName
  }
}

module cosmosDbModule './modules/cosmosdb.bicep' = {
  name: 'cosmosDbDeployment'
  params: {
    location: location
    accountName: appName
  }
}

module functionAppModule './modules/functionApp.bicep' = {
  name: 'functionApp'

  params: {
    location: location
    appName: appName
    tags: tags
    storageAccountName: storageModule.outputs.storageAccountName
    appInsightsKey: appInsightsModule.outputs.instrumentationKey
  }
}

@description('Name of the deployed Function App')
output functionAppName string = functionAppModule.outputs.functionAppName
