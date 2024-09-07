# FenXs
FenXs created by Patryk 'UltiPro' Wójtowicz using ASP.NET Core Razor Pages.

FenXs is a website for managing data on a server that was originally intended to host Minecraft servers and FenXs Game. Originally, the project was supposed to be a replacement for the "Nerdownia" project written in PHP, but due to studies and lack of time, the project was abandoned.

Warning:

> This application is my first major project in college, so there is a lot of ugly code. Additionally, instead of using EF Core and Identity, stored procedures and sessions were used. Everything was written from scratch without the use of scaffolding.

# Dependencies and Usage

Dependencies:

<ul>
  <li>BCrypt.Net-Next 4.0.3</li>
  <li>System.Data.SqlClient 4.8.6</li>
</ul>

Before running or publishing the application:

> On the database server (Microsoft SQL Server), execute the script creating the database (./FenXs/FenXsDAL/Database/Create.sql) and then provide the appropriate connection string to the database in the "appsettings.json" file (in ./FenXs/FenXs folder).

Running the app:

> cd "/FenXs/FenXs"

> dotnet run

Publishing the app:

> cd "/FenXs/FenXs"

> dotnet publish

> cd "/bin/Debug/net8.0/publish"

# Preview

![Index Page 1 Preview](/screenshots/IndexPage1.png)

![Index Page 2 Preview](/screenshots/IndexPage2.png)

![Index Page 3 Preview](/screenshots/IndexPage3.png)

![Main Page Preview](/screenshots/MainPage.png)

![settings Page Preview](/screenshots/SettingsPage.png)

![Admin Page 1 Preview](/screenshots/AdminPage1.png)

![Admin Page 2 Preview](/screenshots/AdminPage2.png)

![Admin Page 3 Preview](/screenshots/AdminPage3.png)

![Admin Page 4 Preview](/screenshots/AdminPage4.png)

![Admin Page 5 Preview](/screenshots/AdminPage5.png)

![NotFound Page Preview](/screenshots/NotFoundPage.png)
