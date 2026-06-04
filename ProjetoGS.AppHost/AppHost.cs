var builder = DistributedApplication.CreateBuilder(args);

var api = builder.AddProject<Projects.ProjetoGS_ApiService>("apiservice");

builder.AddProject<Projects.ProjetoGS_Web>("web")
    .WithReference(api);

builder.Build().Run();