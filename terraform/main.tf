terraform {
  required_providers {
    azurerm = {
      source  = "hashicorp/azurerm"
      version = "~> 3.0.2"
    }
  }

  cloud {
    organization = "SebBrooks"

    workspaces {
      name = "Roomex"
    }
  }

  required_version = ">= 1.1.0"
}

provider "azurerm" {
  subscription_id = var.AZURE_CREDENTIALS.subscriptionId
  client_id       = var.AZURE_CREDENTIALS.clientId
  client_secret   = var.AZURE_CREDENTIALS.clientSecret
  tenant_id       = var.AZURE_CREDENTIALS.tenantId

  features {}
}