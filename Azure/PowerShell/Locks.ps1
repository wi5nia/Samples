#Login to Azure account
Login-AzureRmAccount

New-AzureRmResourceLock `
    -LockLevel CanNotDelete `
    -LockName LockSite -ResourceName {SAMPLESITENAME} -ResourceType Microsoft.Web/sites