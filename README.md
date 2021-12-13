### About
- Basic photo upload application with .Net and VueJS.


### Tech Stack

- C#, .Net 5.0, Entity Framework Core, Code First, MSSQL,  JavaScript, VueJS 3 , Swagger

### Requirements

- .Net 5.0 and Sql Server must be installed on your machine.

### For starter

-   Before you get started please change the connection string in the following directory;
ProductManagement.DataAccess -> Context -> ApplicationDbContext

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           //change here.
		   optionsBuilder.UseSqlServer(@"Server=MSI\MSSQLSERVER14;Database=ProductPhotoUploadDb;Trusted_Connection=True;");  
        }

- The database and the tables would be created on application start and all the tables would seeded with datas (Color, fabric, product etc.)

