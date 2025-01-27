<#
    Before running this script:

    - Install GitHub CLI if you haven't already
    - Login to GitHub CLI using gh auth login
    - For AZURE_CREDENTIALS, you'll need a JSON string from creating a service principal:

    ```
    az ad sp create-for-rbac --name "myApp" --role contributor \
        --scopes /subscriptions/{subscription-id}/resourceGroups/{resource-group} \
        --sdk-auth
    ```
#>


# Define the repository
$repo = "dneimke/azdo-deployview"

# Function to add a secret
function Add-GitHubSecret {
    param (
        [string]$secretName,
        [string]$secretValue
    )

    if ([string]::IsNullOrWhiteSpace($secretValue)) {
        Write-Host "Please enter value for $secretName"
        $secretValue = Read-Host -AsSecureString
        $secretValue = [Runtime.InteropServices.Marshal]::PtrToStringAuto([Runtime.InteropServices.Marshal]::SecureStringToBSTR($secretValue))
    }

    Write-Host "Adding secret: $secretName"
    Write-Output $secretValue | gh secret set $secretName -R $repo
}

# Check if gh CLI is logged in
try {
    gh auth status
}
catch {
    Write-Error "Please login to GitHub CLI first using 'gh auth login'"
    exit 1
}

# Add required secrets
Add-GitHubSecret -secretName "AZURE_CREDENTIALS" -secretValue ""
Add-GitHubSecret -secretName "AZURE_SUBSCRIPTION" -secretValue ""
Add-GitHubSecret -secretName "AZURE_RG" -secretValue ""
Add-GitHubSecret -secretName "AZURE_FUNCTION_APP_NAME" -secretValue ""
Add-GitHubSecret -secretName "AZURE_FUNCTIONAPP_PUBLISH_PROFILE" -secretValue ""

Write-Host "Secrets have been added successfully to $repo"