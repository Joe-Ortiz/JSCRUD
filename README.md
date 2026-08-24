# JSCRUD

## Getting started (Visual Studio 2026)

Use these steps to create the local database and apply the `Product` seed data.

1. Open `JSCRUD.slnx` in **Visual Studio 2026**.
2. Build the solution once (**Build > Build Solution**).
3. Open **Tools > NuGet Package Manager > Package Manager Console**.
4. In **Default project**, select `JSCRUD`.
5. Run:

```powershell
Update-Database
```

`Update-Database` creates the database (if it does not exist), applies migrations, and inserts the 20 seeded `Product` rows from `ApplicationDbContext`.

## Running the app

1. Press **F5** (or **Ctrl+F5**) to run.
2. Navigate to the Products page to confirm seeded records are present.
