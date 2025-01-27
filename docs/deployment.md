# Deployment Guide

## Prerequisites
- Azure subscription
- Azure CLI installed
- Bicep CLI installed
- Sufficient permissions to create resources in Azure

## Setup Steps

### 1. Create Resource Group
```bash
az group create --name rg-azdodeploy-{env} --location {location}
```

### 2. Deploy Infrastructure
Deploy the Bicep templates using Azure CLI:
```bash
az deployment group create \
  --resource-group rg-azdodeploy-{env} \
  --template-file infrastructure/main.bicep \
  --parameters environmentName={env} appName=azdodeploy
```

### 3. Required Azure Resources
The deployment will create:
- Storage Account
- Application Insights
- Function App with hosting plan

### 4. Configuration
After deployment:
1. Note the Function App name from the deployment output
2. Configure these Function App settings if not already set by the Bicep template:
   - APPINSIGHTS_INSTRUMENTATIONKEY
   - AzureWebJobsStorage
   - FUNCTIONS_EXTENSION_VERSION
   - FUNCTIONS_WORKER_RUNTIME

### 5. Security
Ensure:
- Appropriate RBAC permissions are set
- Function App uses managed identity if needed
- Network security rules are configured as required

### 6. Verification
1. Check if all resources are created successfully
2. Verify Function App is running
3. Test the deployment monitoring functionality

## Troubleshooting
- Check Application Insights for function execution logs
- Review Function App's diagnostic logs
- Verify storage account connectivity

## Notes
- Replace {env} with your environment name (e.g., dev, test, prod)
- Replace {location} with your desired Azure region


