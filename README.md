🐛 QA Report Tracker API & AI Bot

Un sistema integral para la gestión, reporte y seguimiento de errores diseñado específicamente para Analistas de QA. Este proyecto implementa un backend robusto basado en Arquitectura Hexagonal (Use Cases), un frontend en Angular, e integra herramientas modernas como Model Context Protocol (MCP) para permitir que modelos de Inteligencia Artificial (LLMs) asistan e interactúen autónomamente con el sistema de incidencias.

✨ Características Principales

Arquitectura Limpia (Hexagonal/Use Cases): Lógica de negocio de QA completamente aislada de los detalles de infraestructura, facilitando el mantenimiento y la escalabilidad.

Integración Nativa con Jira: Creación automática de tickets (Issues) en los tableros de QA a través de la API REST de Atlassian, estandarizando el formato de los reportes.

Notificaciones por Email: Alertas en tiempo real usando SendGrid para notificar a los equipos correspondientes cuando se registran incidencias críticas o bloqueantes.

Servidor MCP Integrado: Expone herramientas de backend (como report_bug_to_jira) a LLMs (ej. Claude, Gemini) para la gestión, clasificación y reporte automatizado de incidencias detectadas en logs o reportes vagos.

Despliegue Cloud Native (GCP): Preparado para desplegarse como contenedores Serverless escalables en Google Cloud Run.

🏗️ Arquitectura del Proyecto

El backend está construido en .NET siguiendo los principios de Clean Architecture. La persistencia de datos principal se realiza mediante MongoDB, ofreciendo alta flexibilidad para guardar los detalles técnicos y adjuntos de los reportes de QA.

📁 QA_Tracker_API/
│
├── 📂 Domain/              # Entidades puras (BugReport) e Interfaces (Puertos)
├── 📂 Application/         # Casos de Uso (ej. ReportBugUseCase)
├── 📂 Infrastructure/      # Implementaciones (MongoDB, JiraService, SendGrid)
└── 📂 Presentation/        # API Controllers y Servidor Background MCP



🚀 Tecnologías y Herramientas

Frontend: Angular (Alojamiento previsto en Firebase Hosting / Cloud Storage).

Backend: ASP.NET Core (C#).

Base de Datos: MongoDB.

Gestión de Tareas: Jira API v2 (Basic Auth).

Notificaciones: SendGrid API.

Infraestructura Cloud: Google Cloud Platform (GCP) - Cloud Run, Cloud Logging.

IaC (Infrastructure as Code): Terraform para el aprovisionamiento automatizado del entorno en GCP.

⚙️ Requisitos Previos (Desarrollo Local)

Para ejecutar este proyecto en tu máquina, necesitarás:

.NET SDK instalado.

Node.js y Angular CLI para el frontend.

Una instancia local de MongoDB o un clúster de MongoDB Atlas.

Credenciales de APIs de terceros (Jira y SendGrid).

Variables de Entorno (.env / appsettings.json)

Debes configurar los siguientes secretos en tu entorno antes de arrancar la aplicación. Nunca subas estos valores al repositorio:

{
  "MongoDB": {
    "ConnectionString": "mongodb://localhost:27017",
    "DatabaseName": "QATrackerDb"
  },
  "Jira": {
    "BaseUrl": "[https://TU-DOMINIO.atlassian.net](https://TU-DOMINIO.atlassian.net)",
    "Email": "tu-email@ejemplo.com",
    "ApiToken": "TU_API_TOKEN",
    "ProjectKey": "QA"
  },
  "SendGrid": {
    "ApiKey": "SG.tu_api_key_aqui",
    "FromEmail": "notificaciones@tudominio.com"
  }
}


🤖 Uso del Bot MCP (Inteligencia Artificial)

Este proyecto incluye un BackgroundService que actúa como servidor Model Context Protocol (MCP).
Esto permite conectar clientes LLM (como Claude Desktop) directamente a la API de tu gestor de QA.

Herramientas (Tools) expuestas al LLM:

report_bug_to_jira: Permite a la IA interactuar como un analista de QA virtual. Puede analizar logs de errores, estructurar descripciones vagas proporcionadas por usuarios, crear el ticket formal en Jira, guardarlo en el registro histórico de MongoDB y notificar por email, todo en un solo paso orquestado por el Caso de Uso de la API.

☁️ Despliegue en Google Cloud (GCP)

El proyecto está diseñado para ser desplegado utilizando Terraform (IaC). El flujo básico de despliegue es:

El frontend (Angular) se compila y se sirve como archivos estáticos.

El backend (.NET) se dockeriza.

Terraform levanta el servicio de Cloud Run asignando las variables de entorno de forma segura a través de Google Secret Manager.

Nota: Para métricas y observabilidad, el sistema se apoya nativamente en Google Cloud Observability (Logging y Monitoring) facilitando el trabajo de los analistas al detectar patrones de errores.
