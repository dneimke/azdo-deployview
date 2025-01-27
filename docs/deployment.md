# Azure DevOps Deployment View

A .NET Azure Function that integrates with Azure DevOps to provide deployment information.

## Prerequisites

- Azure CLI installed
- GitHub CLI installed
- Azure Subscription
- GitHub account with permissions to this repository

## Azure Setup

### 1. Create Azure Resources

First, login to Azure CLI:

```bash
az login
```

Create a resource group:

```bash
az group create --name rg-azdodeploy-dev --location "australiasoutheast"
```

### 2. Create Service Principal

Create a service principal with Contributor access to the resource group:

```bash
az ad sp create-for-rbac --name "azdo-deployview" \
    --role contributor \
    --scopes /subscriptions/{subscription-id}/resourceGroups/rg-azdodeploy-dev \
    --sdk-auth
```

Save the JSON output - you'll need this for the GitHub secret AZURE_CREDENTIALS.

### 3. Configure GitHub Secrets

Add these secrets to your GitHub repository (Settings -> Secrets and variables -> Actions):

- AZURE_CREDENTIALS: (JSON output from service principal creation)
- AZURE_SUBSCRIPTION: Your Azure subscription ID
- AZURE_RG: azdo-deployview-rg
- AZURE_FUNCTION_APP_NAME: The name of your function app (e.g., azdo-deployview-prod-func)

### 4. Configure GitHub Environment

The repository uses a 'production' environment for deployments. This is automatically created by the CI/CD pipeline with:

- Required reviewers
- Wait timer (5 minutes)
- Protected branches only

### 5. Branch Protection

Main branch is protected with these rules:

- Requires pull request before merging
- Requires 1 approval
- Dismisses stale pull request approvals
- Requires status checks to pass

## Infrastructure

The infrastructure is defined in Bicep files located in the /infrastructure directory:

- `main.bicep`: Entry point for all infrastructure
- `functionApp.bicep`: Function App and hosting plan
- `storageAccount.bicep`: Storage account for Function App
- `appInsights.bicep`: Application Insights for monitoring

## Deployment

The CI/CD pipeline will:

- Build and test the application
- Deploy infrastructure using Bicep
- Deploy the Function App

All deployments to production require:

- Pull request approval
- Successful build
- Environment approval
- 5-minute wait timer

## Notes

- Replace {env} with your environment name (e.g., dev, test, prod)
- Replace {location} with your desired Azure region
