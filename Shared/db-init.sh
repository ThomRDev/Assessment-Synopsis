# Wait for the SQL Server to come up
sleep 20s

echo "Running script setup..."
# Run the setup script to create the DB and the schema in the DB
/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P Admin@123 -d master -i db-init.sql