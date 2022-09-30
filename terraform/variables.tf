variable "AZURE_CREDENTIALS" {
  type = object({
      clientId = string
      clientSecret = string
      subscriptionId = string
      tenantId = string
      activeDirectoryEndpointUrl = string
      resourceManagerEndpointUrl = string
      activeDirectoryGraphResourceId = string
      sqlManagementEndpointUrl = string
      galleryEndpointUrl = string
      managementEndpointUrl = string
  })
  sensitive = true
}