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

param cosmosDbName string = 'azdo-deployview'
param databaseName string = 'release-database'
param containerName string = 'releases'

// Tags
var tags = {
  environment: environmentName
  application: appName
}

// Storage Account
module storage './modules/storageAccount.bicep' = {
  name: 'storageAccount'
  params: {
    location: location
    environmentName: environmentName
    tags: tags
    appName: appName
    uniqueSuffix: uniqueSuffix
  }
}

// Application Insights
module appInsights './modules/appInsights.bicep' = {
  name: 'appInsights'
  params: {
    location: location
    tags: tags
    appName: appName
  }
}

// Function App and related resources
module functionApp './modules/functionApp.bicep' = {
  name: 'functionApp'

  params: {
    location: location
    appName: appName
    environmentName: environmentName
    tags: tags
    storageAccountName: storage.outputs.storageAccountName
    appInsightsKey: appInsights.outputs.instrumentationKey
  }
}

module cosmosDb './modules/cosmosdb.bicep' = {
  name: 'cosmosDbDeployment'
  params: {
    location: location
    cosmosDbName: cosmosDbName
  }
}

module database './modules/cosmosdb-database.bicep' = {
  name: 'databaseDeployment'
  params: {
    cosmosDbName: cosmosDb.outputs.cosmosDbName // Use output from cosmosDbModule
    databaseName: databaseName
  }
}

module container './modules/cosmosdb-container.bicep' = {
  name: 'containerDeployment'
  params: {
    databaseName: database.outputs.databaseName // Use output from databaseModule
    containerName: containerName
  }
}

@description('Name of the deployed Function App')
output functionAppName string = functionApp.outputs.functionAppName
