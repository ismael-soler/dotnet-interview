#!/bin/bash

echo "Runnin initial API app setup"
cd /app
echo "--- Restoring tools..."
dotnet tool restore
echo "--- Setting up HTTPS certificate..."
dotnet dev-certs https
echo "--- Building project..."
dotnet build
echo "--- Running database migrations..."
dotnet ef database update --project TodoApi

# echo "Initializing API..."
# dotnet watch --project /app/TodoApi