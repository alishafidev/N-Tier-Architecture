# N-Tier-Architecture
This is a layered .NET 6+ API project following N-Tier architecture with PostgreSQL and Entity Framework Core.

## 🧱 Layers

- `APP.API` – API Layer
- `APP.BLL` – Business Logic Layer
- `APP.DAL` – Data Access Layer (DbContext, Models, EF Migrations)

---

## 🐘 PostgreSQL with Docker

Start PostgreSQL and pgAdmin using Docker:

```bash
docker-compose up -d
```

```txt
PostgreSQL: localhost:5432
pgAdmin: http://localhost:8080
Default DB: appdb
Username: postgres
Password: yourpassword
```

## ⚙️ Configuration
Update appsettings.json in APP.API:

```json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Database=appdb;Username=postgres;Password=yourpassword"
}
```

## 🔧 Apply EF Migrations
Install EF tool if not already:

```bash
dotnet tool install --global dotnet-ef
```

Then:

```bash
dotnet ef migrations add InitialCreate --project APP.DAL --startup-project APP.API
dotnet ef database update --project APP.DAL --startup-project APP.API
```

## ▶️ Run the API

```bash
dotnet run --project APP.API
```

## 📦 Folder Structure

```txt
APP.API       → Controllers and Program.cs
APP.BLL       → Services, Interfaces
APP.DAL       → EF DbContext, Models, Migrations
```

## 🚀 One-liner Setup
```bash
docker-compose up -d \
&& dotnet ef database update --project APP.DAL --startup-project APP.API \
&& dotnet run --project APP.API
```

## 🛠 Tech Stack

- .NET 6+
- PostgreSQL
- Entity Framework Core
- Docker + pgAdmin

## 📬 Contributions

Pull requests are welcome. Stick to the architecture and keep things modular.

```css

Let me know if you want this saved to a file or want the `docker-compose.yml` content added too.

```