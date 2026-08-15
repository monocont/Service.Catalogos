# Service.Catalogos

Microservicio de catálogos contables, tablas maestras SUNAT y consulta/web scraping de tipo de cambio oficial (SUNAT / SBS) para la plataforma **Monocont**.

---

## 📌 Características
- Catálogos tributarios SUNAT (Tipos de Comprobante, Monedas, Tipos de Documento, etc.).
- Plan Contable General Empresarial (PCGE).
- Consulta y sincronización masiva de **Tipo de Cambio Oficial (SUNAT/SBS)** mediante **Playwright** (scraping headless).
- Almacenamiento y caché de tipos de cambio históricos.
- Arquitectura Limpia (**Clean Architecture**) con CQRS y **MediatR**.
- Persistencia en **PostgreSQL** con **Entity Framework Core**.

---

## 🏗 Arquitectura y Estructura
```
Service.Catalogos/
├── Service.Catalogos.API/            # Controladores REST, Endpoints y Program.cs
├── Service.Catalogos.Application/    # Commands, Queries, DTOs e Interfaces
├── Service.Catalogos.Domain/         # Entidades de Catálogos, TipoCambio y Enums
└── Service.Catalogos.Infrastructure/ # DbContext, Scrapers (Playwright), Repositorios y Scripts SQL
```

---

## ⚙️ Configuración y Variables de Entorno

Archivo: `appsettings.json`

```json
{
  "ConnectionStrings": {
    "CatalogosDb": "Host=localhost;Port=5432;Database=monocont_catalogos;Username=postgres;Password=postgres"
  },
  "Cors": {
    "AllowedOrigins": [
      "http://localhost:4200",
      "https://localhost:4200"
    ]
  }
}
```

---

## 🌐 Dependencia de Playwright (Web Scraping de Tipo de Cambio)

Para que el servicio de extracción de tipo de cambio funcione en entornos locales o desarrollo, es necesario instalar el navegador de Playwright:

```powershell
# En Windows (desde la carpeta de salida o API)
powershell -ExecutionPolicy Bypass -File .\bin\Debug\net10.0\playwright.ps1 install firefox
```

---

## 🚀 Ejecución

### Puerto por defecto: `5002`

```bash
cd Service.Catalogos.API
dotnet run
```
- **Swagger UI:** `http://localhost:5002/swagger`

---

## 🗄 Base de Datos
Ejecutar los scripts SQL ubicados en `Service.Catalogos.Infrastructure/Script/` en la base de datos `monocont_catalogos`.
