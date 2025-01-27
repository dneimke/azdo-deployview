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
module storage './storageAccount.bicep' = {
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
    appInsightsKey: appInsights.outputs.instrumentationKey
  }
}

@description('Name of the deployed Function App')
output functionAppName string = functionApp.outputs.functionAppName
