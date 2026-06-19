# API de Eventos - Sistema de Reservas

## Descripción
Esta API constituye el núcleo del sistema "Eventos Vivos", diseñada para gestionar la creación de eventos y el ciclo de vida de las reservas de cupos, eliminando la sobreventa mediante reglas de negocio automatizadas.

## Arquitectura
- **Patrón:** Arquitectura Cebolla (Onion Architecture).
- **Justificación:** Se eligió esta arquitectura para garantizar un desacoplamiento total entre la lógica de negocio (Core), la persistencia (Infraestructura) y la interfaz (API). [cite_start]Esto permite que el núcleo del negocio sea testeable de forma aislada y altamente resistente a cambios tecnológicos.

## Tecnologías
**Lenguaje:** C# / .NET Core 8.0 
**Patrones:** CQRS, MediatR, Inyección de Dependencias 
*Persistencia:** SQL Server, Entity Framework Core, Dapper 
**Validaciones:** FluentValidation 

## Diagramas de Proceso
A continuación, se detalla el flujo lógico del sistema para la gestión de reservas:

Crear Evento
<img width="1178" height="1094" alt="Crear Evento" src="https://github.com/user-attachments/assets/6145083c-8a58-41ed-8819-395f323eb7be" />

Crear Reserva
<img width="1178" height="237" alt="Crear Reserva" src="https://github.com/user-attachments/assets/6cee59f4-27aa-4e94-8ddb-79fd1d5c7bfb" />

Confirmar Pago
<img width="1178" height="345" alt="Confirmar Pago" src="https://github.com/user-attachments/assets/3245a3a3-0ced-4d0e-8bdf-8e3a1a172872" />

Cancelar Reserva
<img width="760" height="1078" alt="Cancelar Reserva" src="https://github.com/user-attachments/assets/b873d348-2f5f-4770-9428-c5c40e7f900f" />

## Estructura del módulo.
Se organizó mediante una arquitectura de proyectos (API, Application, Domain, Infrastructure) asegurando la separación de responsabilidades.

## Base de Datos
El script de creación de la base de datos se encuentra en la carpeta denomina Database.
Para ejecutarlo:
1. Abre SQL Server Management Studio (SSMS).
2. Crea una consulta vacía.
3. Pega el contenido de Schema.sql y ejecútalo. Esto creará automáticamente la base de datos Eventos y todos sus objetos.

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
