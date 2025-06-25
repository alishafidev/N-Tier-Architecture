#!/bin/bash
echo "📦 Starting Docker (PostgreSQL + Adminer)..."
docker-compose up -d

echo "🛠️  Running EF Core migration..."
dotnet ef database update \
  --project ../MyApp.DAL \
  --startup-project ./

echo "🚀 Starting API..."
dotnet run
