#Login to Azure account
Login-AzureRmAccount

$resourceGroupName = "RESOURCEGROUPNAME"
$resourceGroupName2 = "RESOURCEGROUPNAME2"
$appHostingPlanName = "APPHOSTINGPLANNAME"
$databaseName = "DATABASENAME"
$administratorLogin = "ADMINISTRATORLOGIN"

#Get resource type location
Get-AzureRmResourceProvider -ListAvailable

((Get-AzureRmResourceProvider -ProviderNamespace Microsoft.Web).ResourceTypes | Where-Object ResourceTypeName -eq sites).Locations

#Create a resource group
New-AzureRmResourceGroup -Name $resourceGroupName -Location "West Europe"

#Get available API versions for the resources
((Get-AzureRmResourceProvider -ProviderNamespace Microsoft.Web).ResourceTypes | Where-Object ResourceTypeName -eq sites).ApiVersions

#Create your template
#VS Code

#Deploy the template
New-AzureRmResourceGroupDeployment -ResourceGroupName $resourceGroupName `
    -TemplateFile 'WebWithSQLTemplate.json'

#Dynamic Template Parameters - DO SPRAWDZENIA!!!
New-AzureRmResourceGroupDeployment -ResourceGroupName $resourceGroupName `
    -TemplateFile 'WebWithSQLTemplate.json' `
    -hostingPlanName $appHostingPlanName ` 
    -databaseName $databaseName -administratorLogin $administratorLogin

#Get information about your resource groups
Get-AzureRmResourceGroup

#NOT WORKING IN CURRENT BUILD!!!
Get-AzureRmResource -ResourceGroupName $resourceGroupName

#Move a resource
#List of currently supported resources to move:
#https://azure.microsoft.com/en-us/documentation/articles/resource-group-move-resources/
New-AzureRmResourceGroup -Name $resourceGroupName -Location "West Europe"

New-AzureRmResourceGroup -Name $resourceGroupName2 -Location "West Europe"
New-AzureRmResourceGroupDeployment -ResourceGroupName $resourceGroupName2 `
    -TemplateFile 'WebSiteTemplate.json'

$webapp = Get-AzureRmResource -ResourceGroupName $resourceGroupName2 -ResourceName {GETNAMEOFCREATEDWEBAPP} -ResourceType Microsoft.Web/sites
$plan = Get-AzureRmResource -ResourceGroupName $resourceGroupName2 -ResourceName objmoveasp -ResourceType Microsoft.Web/serverFarms
# New-AzureRmWebApp -ResourceGroupName $resourceGroupName
Move-AzureRmResource -DestinationResourceGroupName $resourceGroupName -ResourceId ($webapp.ResourceId, $plan.ResourceId)

#Delete a resource group
Remove-AzureRmResourceGroup -Name $resourceGroupName
Remove-AzureRmResourceGroup -Name $resourceGroupName -Force
Remove-AzureRmResourceGroup -Name $resourceGroupName2 -Force