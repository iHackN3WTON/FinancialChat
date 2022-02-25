# FinancialChat

## Introduction

This project is a simple browser-based chat application using .NET.

## Features

User registry and authentication using .NET identity
Multiple Chat Rooms
Create and delete rooms
When enter a room, the last 50 messages shows in a list
Stock consulting using the following command:

    /stock=stock_code
    
Example:

    /stock=APPL.US
    
## Architecture

This project uses MVC structure.

The chat comunications uses SignalR package.

The stock consulting uses RestSharp package.

To the project an Angular version of the chat page it has been added

## Running the project

The project was made in visual studio using c# and asp.net, Visual Studio 2013 and .Net Framework 4.6.1 are the minimum requeriments to run this application, due to unit testing code.

To compile and start the aplication, download the complete code and open the FinancialChat.sln file.

Before run the site or compile you need to follow some steps.

### DataBase

For the database, you will need an MSSQL instance, it could be Local or Remote, create the database with any name. 
In SQL open the file DatabaseStructureScript.sql that is in the path /FinancialChat/FinancialChat/DatabaseStructureScript.sql and run the script.
Now in Visual Studio open the file Web.Config that is in the path /FinancialChat/FinancialChat/Web.Config and modify the following section

    <connectionStrings>
        <add name="DefaultConnection" connectionString="" providerName="System.Data.SqlClient" />
    </connectionStrings>

Add the value needed for the connection following the next structure 

    connectionString="DataSource=your server;Initial Catalog=name of database;Integrated Security=True if no needed user and pass or False if needed user and pass;User ID=if needed;Password=if needed"

### Angular SPA

For the angular part of the project you will need to install nodejs, you can find it in the url: https://nodejs.org/

Download and install NodeJS, after that you will need to install AngularCLI, to do that follow this steps

Open a terminal window or a command prompt windows, move to the path in the project /FinancialChat/FinancialChat/ChatAngular/

Now run the following command to install AngularCLI: 

    npm install -g @angular/cli

After that you will need to download the modules packages for this particular Angular project, run the following command: 

    npm install

Now compile the Angular SPA, run the following command: 

    ng build

The project is compiled in the path /FinancialChat/FinancialChat/Scripts/

The Angular SPA is ready.

### Compile and Run and Excecute

When you have the database and the Angular SPA ready, you can run the Web Application, in Visual Studio press F5 to run the application.

Your web browser should load automaticaly, and you should see the register page.
