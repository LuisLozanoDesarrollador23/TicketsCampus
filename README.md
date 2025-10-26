# TicketsCampus

Sistema de gestión de tickets.

## 📋 Descripción

Solución a la prueba tecnica para el puesto de desarrollor .NET

## 🏗️ Arquitectura

El proyecto está organizado en 4 capas principales:

### **TicketsCampus.ApiMinimal**
- API REST desarrollada con Minimal APIs de .NET
- Endpoints ligeros y de alto rendimiento

### **TicketsCampus.Data**
- Implementación de repositorios
- Contexto de Entity Framework Core
- Configuración de modelos y migraciones

### **TicketsCampus.Service**
- Servicios que orquestan operaciones rest
- DTOs y transformaciones de datos

### **TicketsCampus.Web**
- Cliente frontend Blazor

## 🚀 Tecnologías

- **.NET** (9.0)
- **Entity Framework Core** - ORM para acceso a datos
- **Minimal APIs** - Framework para la API REST
- **ASP.NET Core** - Framework web
