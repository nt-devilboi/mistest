var builder = DistributedApplication.CreateBuilder(new DistributedApplicationOptions
{
    AllowUnsecuredTransport = true
});


var db = builder.AddPostgres("database").WithPgAdmin()
    .AddDatabase("misdb");

builder.AddProject<Projects.MIS_Api>("api").WithReference(db).WaitFor(db);

var app = builder.Build();


app.Run();