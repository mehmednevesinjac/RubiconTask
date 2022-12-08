
# Rubicon task

Standalone Startup

At first, you need to have up and running MySQL and MsSQL database servers on localhost with.

Then the application (API) can be started by dotnet
run command executed in the RubiconTask\RubiconTask
directory. By default it will be available under "https://localhost:7135" or "http://localhost:5209"
and swagger will be on https://localhost:7135/swagger/index.html if you get SSL error 
go to http://localhost:5209/swagger/index.html
You will need to provide your own connection string to your local database 
"DefaultConnection": "Server=localhost;Database=rubiconTask;User Id=YOUR USERNAME;Password=YOUR PASSWORD;TrustServerCertificate=True;Encrypt=False;"

Docker Startup 

Just run "docker-compose up -d" command in the root directory and after 
successful start of services visit http://localhost:5000/swagger/index.html. 
Both the API and the SQL database will start up at the same time

When the application starts up it will automaticaly update database with migrations and
will seed some initial data. 

One of the error that can happen is that your ports are taken so go into docker-compose.yaml
and change the web api port from 5000 to something else. By doing that you will also have to
go to a different port in your browser. 

If the API container keeps crashing give up and got with 
Standalone Startup.