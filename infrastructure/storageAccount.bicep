@description('Azure region for all resources')
param location string

@description('Environment name')
@allowed(['dev', 'test', 'prod'])
param environmentName string

@description('Application name - will be used in resource naming')
@minLength(3)
@maxLength(11)
param appName string

@description('Unique suffix for resource names')
@minLength(13)
param uniqueSuffix string

@description('Resource tags object')
param tags object

// Ensure storage account name meets Azure requirements
var storageAccountName = take('${replace(toLower(appName), '-', '')}${take(uniqueSuffix, 8)}${environmentName}', 24)

resource storageAccount 'Microsoft.Storage/storageAccounts@2023-01-01' = {
  name: storageAccountName
  location: location
  tags: tags
  sku: {
    name: 'Standard_LRS'
  }
  kind: 'StorageV2'
  properties: {
    allowBlobPublicAccess: false
    allowSharedKeyAccess: true
    minimumTlsVersion: 'TLS1_2'
    supportsHttpsTrafficOnly: true
    networkAcls: {
      defaultAction: 'Allow'
      bypass: 'AzureServices'
    }
    encryption: {
      keySource: 'Microsoft.Storage'
      services: {
        blob: {
          enabled: true
        }
        file: {
          enabled: true
        }
        queue: {
          enabled: true
        }
        table: {
          enabled: true
        }
      }
    }
  }
}

@description('Storage account name')
output storageAccountName string = storageAccount.name

#disable-next-line outputs-should-not-contain-secrets
@description('Storage account primary key')
output storageAccountKey string = listKeys(storageAccount.id, storageAccount.apiVersion).keys[0].value
