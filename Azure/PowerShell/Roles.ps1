Login-AzureRmAccount

#View available roles
Get-AzureRmRoleDefinition

#Grant Reader permission to a group for the subscription.

#Get Reader definition
Get-AzureRmRoleDefinition Reader

#Get srcurity group from AAD
$group = Get-AzureRmAdGroup -SearchString "{GROUP NAME}"

New-AzureRmRoleAssignment -ObjectId $group.Id -Scope /subscriptions/{SUBSCRIPTION ID}/ -RoleDefinitionName Reader
Remove-AzureRmRoleAssignment -ObjectId $group.Id -Scope /subscriptions/{SUBSCRIPTION ID}/ -RoleDefinitionName Reader

#Grant Contributor permission to an application for a resource group.
Get-AzureRmRoleDefinition Contributor
$service = Get-AzureRmADServicePrincipal -SearchString {SOMEAPPLICATIONNAME}
New-AzureRmRoleAssignment -ObjectId $service.Id -ResourceGroupName ExampleGroupName -RoleDefinitionName Contributor