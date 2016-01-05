#Login to Azure account
Login-AzureRmAccount

$resourceGroupName = "RESOURCEGROUPNAME"

#New Resource Group
New-AzureRmResourceGroup -Name $resourceGroupName -Location "West Europe"

#Deplot template with tags
New-AzureRmResourceGroupDeployment -ResourceGroupName $resourceGroupName `
    -TemplateFile 'StorageTemplate.json'

#NOT WORKING
Get-AzureRmResourceGroup $resourceGroupName

#Setting tag
Set-AzureRmResourceGroup -Name $resourceGroupName -Tag @( @{ Name="project"; Value="tags" }, @{ Name="env"; Value="demo"} )

#Getting current tags and setting new ones
$tags = (Get-AzureRmResourceGroup -Name $resourceGroupName).Tags
$tags += @{Name="status";Value="approved"}
Set-AzureRmResourceGroup -Name $resourceGroupName -Tag $tags

#Get resource with specific tag
Find-AzureRmResourceGroup -Tag @{ Name="env"; Value="demo" } | %{ $_.ResourceGroupName }

#Get all tags for subscription
Get-AzureRmTag

Remove-AzureRmResourceGroup -Name $resourceGroupName -Force