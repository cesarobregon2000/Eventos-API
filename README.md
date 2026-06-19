# API de Eventos - Sistema de Reservas

## Descripción
Esta API constituye el núcleo del sistema "Eventos Vivos", diseñada para gestionar la creación de eventos y el ciclo de vida de las reservas de cupos, eliminando la sobreventa mediante reglas de negocio automatizadas.

## Arquitectura
- **Patrón:** Arquitectura Cebolla (Onion Architecture).
- **Justificación:** Se eligió esta arquitectura para garantizar un desacoplamiento total entre la lógica de negocio (Core), la persistencia (Infraestructura) y la interfaz (API). [cite_start]Esto permite que el núcleo del negocio sea testeable de forma aislada y altamente resistente a cambios tecnológicos[cite: 69, 81].

## Tecnologías
**Lenguaje:** C# / .NET Core 8.0 [cite: 89, 90]
**Patrones:** CQRS, MediatR, Inyección de Dependencias [cite: 73, 78, 95]
*Persistencia:** SQL Server, Entity Framework Core, Dapper [cite: 93, 94, 100]
**Validaciones:** FluentValidation [cite: 96]

## Instrucciones de ejecución
1. Asegúrate de tener instalado el .NET SDK 8.0.
2. Configura tu cadena de conexión a SQL Server en `appsettings.json`.
3. Ejecuta el proyecto desde la terminal:
   `dotnet run`

### 1. Configuración del entorno
Para ejecutar el proyecto, debes crear o configurar tu archivo `appsettings.json` en la raíz del proyecto. Utiliza la siguiente estructura como plantilla:

```json
{
  "ConnectionStrings": {
    "SqlServerConnection": "TU_CADENA_DE_CONEXION_AQUI"
  },
  "JwtSettings": {
    "Issuer": "EventosAPI",
    "Audience": "EventosClient",
    "SecretKey": "TU_CLAVE_SECRETA_DE_32_CARACTERES_MINIMO"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
