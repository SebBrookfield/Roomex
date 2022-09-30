resource "azurerm_service_plan" "roomex-api-service-plan" {
  name                = "roomex-service-plan"
  resource_group_name = azurerm_resource_group.roomex.name
  location            = azurerm_resource_group.roomex.location
  os_type             = "Linux"
  sku_name            = "F1"
}

resource "azurerm_linux_web_app" "roomex-api" {
  name                = "roomex-api"
  resource_group_name = azurerm_resource_group.roomex.name
  location            = azurerm_service_plan.roomex-api-service-plan.location
  service_plan_id     = azurerm_service_plan.roomex-api-service-plan.id
  https_only            = true
  
  site_config {
    minimum_tls_version = "1.2"
    application_stack {
      dotnet_version = "6.0"
    }
  }
}