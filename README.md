Love Cosmetics

This app is inspired by my favourite  online cosmetic shop. 
The application is still in the process of development. 

To access Love Cosmetic please proceed as described below:

Within the project's production directory create the file appsettings.json (ProjectName.Solution/ProjectName/appsettings.json). 

Please insert the following code in appsettings.json, replacing the uid and pwd values with your own username and password for MySQL. 

{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;database=[YOUR-DB-NAME];uid=[YOUR-USER-HERE];pwd=[YOUR-PASSWORD-HERE];"
  }
}

Please make following replacements:

[YOUR-USER-HERE] with your username
[YOUR-PASSWORD-HERE] with your password
[YOUR-DB-NAME] with the name of your database

P.S. I will update the design of the application as soon as all planned functionality is implemented. Great thanks to PhotoPea for the templates I've used for creating pictures for the categories for the Home page:))
