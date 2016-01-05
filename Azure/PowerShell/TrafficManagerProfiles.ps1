Login-AzureRmAccount

$resourceGroupName = "RESOURCEGROUPNAME"
$resourceGroupNameUS = "RESOURCEGROUPNAMEUS"
$resourceGroupNameEU = "RESOURCEGROUPNAMEEU"
$trafficManagerProfileName = "TRAFFICMANAGERPROFILENAME"
$relativeDNSName = "RELATIVEDNSNAME"
$trafficManagerEndpointName = "TRAFFICMANAGERENDPOINTNAME"

New-AzureRmResourceGroup -Name $resourceGroupName -location "West Europe"

#Create resource groups
New-AzureRmResourceGroup -Name $resourceGroupNameUS -Location "West US"
New-AzureRmResourceGroup -Name $resourceGroupNameEU -Location "West Europe"

#Deploy WebSites
New-AzureRmResourceGroupDeployment -ResourceGroupName $resourceGroupNameUS `
    -TemplateFile "WebSiteWithNameTemplate.json"

New-AzureRmResourceGroupDeployment -ResourceGroupName $resourceGroupNameEU `
    -TemplateFile "WebSiteWithNameTemplate.json"

$profile = New-AzureRmTrafficManagerProfile –Name $trafficManagerProfileName -ResourceGroupName $resourceGroupName -TrafficRoutingMethod Performance -RelativeDnsName $relativeDNSName -Ttl 30 -MonitorProtocol HTTP -MonitorPort 80 -MonitorPath "/"

$websiteeu = Get-AzureRMWebApp -Name {WEBSITE IN EU NAME}
Add-AzureRmTrafficManagerEndpointConfig –EndpointName objeu –TrafficManagerProfile $profile –Type AzureEndpoints -TargetResourceId $websiteeu.Id –EndpointStatus Enabled
$websiteus = Get-AzureRMWebApp -Name {WEBSITE IN US NAME}
Add-AzureRmTrafficManagerEndpointConfig –EndpointName $trafficManagerEndpointName –TrafficManagerProfile $profile –Type AzureEndpoints -TargetResourceId $websiteus.Id –EndpointStatus Enabled

Set-AzureRmTrafficManagerProfile –TrafficManagerProfile $profile

Remove-AzureRmResourceGroup -Name $resourceGroupName -Force
Remove-AzureRmResourceGroup -Name $resourceGroupNameUS -Force
Remove-AzureRmResourceGroup -Name $resourceGroupNameEU -Force