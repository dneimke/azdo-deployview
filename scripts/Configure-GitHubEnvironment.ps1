# Repository details
$owner = "dneimke"
$repo = "azdo-deployview"

# Function to create GitHub environment with protection rules
function New-GitHubEnvironment {
    param (
        [string]$environmentName
    )

    Write-Host "Creating environment: $environmentName"

    # First, create the basic environment
    $createResult = gh api `
        --method PUT `
        "/repos/$owner/$repo/environments/$environmentName" `
        --header 'Accept: application/vnd.github.v3+json'

    if ($?) {
        Write-Host "Environment created successfully. Adding protection rules..."

        $reviewerId = $env:GITHUB_USER_ID

        # Update the environment with protection rules
        $updateResult = gh api `
            --method PUT `
            "/repos/$owner/$repo/environments/$environmentName" `
            --header 'Accept: application/vnd.github.v3+json' `
            --header 'Content-Type: application/json' `
            --raw-field "wait_timer=5" `
            --raw-field "reviewers=$(ConvertTo-Json @(@{type='User';id=$reviewerId}))" `
            --raw-field "deployment_branch_policy=$(ConvertTo-Json @{protected_branches=$true;custom_branch_policies=$false})"

        Write-Host "Environment setup complete"
        Write-Host $updateResult
    }
    else {
        Write-Error "Failed to create environment"
        Write-Host $createResult
    }
}

# Check if gh CLI is logged in
try {
    gh auth status
}
catch {
    Write-Error "Please login to GitHub CLI first using 'gh auth login'"
    exit 1
}

# Get user ID if not set
if (-not $env:GITHUB_USER_ID) {
    $userInfo = gh api user | ConvertFrom-Json
    $env:GITHUB_USER_ID = $userInfo.id
    Write-Host "Set GITHUB_USER_ID to: $($env:GITHUB_USER_ID)"
}

# Create the production environment
New-GitHubEnvironment -environmentName "production"