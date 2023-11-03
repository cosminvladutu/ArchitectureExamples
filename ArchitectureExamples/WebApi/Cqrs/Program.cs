using Cqrs;
using Microsoft.AspNetCore.OpenApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IPORepository, PORepository>();

builder.Services.AddSingleton<IProjectRepository, ProjectRepository>();

builder.AddAssingProjectToPOUseCase();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/", () => "Hello World!");

app.MapPost("/{id}/assing/{po}", async (Guid id,
                                                     Guid po,
                                                     AssignProjectToPoCommandHandler handler) =>
{

    Console.WriteLine($"{id} - {po}");
    var value = await handler.Handle(new AssignProjectToPoCommand()
    {
        ProjectId = id,
        PurchaseOrderId = po
    });

    return value;

}).WithOpenApi();


// create PO post

// some kind of query 

app.Run();
