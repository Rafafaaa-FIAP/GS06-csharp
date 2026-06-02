var builder = DistributedApplication.CreateBuilder(args);

var mysql = builder.AddMySql("mysql")
    .AddDatabase("projetogsdb");

var api = builder.AddProject<Projects.ProjetoGS_ApiService>("apiservice")
    .WithReference(mysql);

builder.AddProject<Projects.ProjetoGS_Web>("web")
    .WithReference(api);

builder.Build().Run();