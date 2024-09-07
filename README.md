# init db Ordering

- add-migration initial -OutputDir Data/Migrations -Project Ordering.Infrastructure -StartupProject Ordering.Api
- docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d
