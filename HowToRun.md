In order too run the project yo have to do only two things
- Modify the connection strings to point to your server int the web.config
    <add name="SMSDb" connectionString="Data Source=.\SQL16;Initial Catalog=SMSDb;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False" providerName="System.Data.SqlClient" />
    <add name="InsuranceDb" providerName="System.Data.SqlClient" connectionString="Data Source=.\sql16;Initial Catalog=Insurance;Integrated Security=True;" />
- Change the provider and set it default to "snailabroad". On save you should get "Save Success!
Your available credits are:1000"

## Notes
- When you run the very first time the database is being populate with a lot of random data and takes some time, around 2-3 minutes. Be patient
- When you create give a range on issue date a past month of 2017
