using Aspire.Hosting;
using Aspire.Hosting.ApplicationModel;


var builder = DistributedApplication.CreateBuilder(args);

var password = builder.AddParameter("mysql-password", "fiap", secret: true);

var mysql = builder.AddMySql("mysql", password)
    .WithLifetime(ContainerLifetime.Persistent)
    .WithDataVolume("projetogs-mysql-data")
    .AddDatabase("projetogsdb");

var api = builder.AddProject<Projects.ProjetoGS_ApiService>("apiservice")
    .WithReference(mysql);

builder.AddProject<Projects.ProjetoGS_Web>("web")
    .WithReference(api);

builder.Build().Run();