#region V1 simple API
//using AutoFixture;
//using ExampleDomain.Classes.Entities;

//var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var app = builder.Build();

//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.MapGet("/project", () =>
//{
//    var fixture = new Fixture();

//    return fixture.CreateMany<Project>(2);
//});

//app.MapGet("/project/{id:guid}", (Guid id) =>
//{
//    var fixture = new Fixture();

//    return fixture.Create<Project>();
//});

//app.MapPost("projects/", (HttpRequest request, Project p) =>
//{
//    var scheme = request.Scheme;
//    var host = request.Host;
//    var location = new Uri($"{scheme}{Uri.SchemeDelimiter}{host}/projects/{p.Id}");
//    return Results.Created(location, p);
//})
//    .Accepts<Project>("application/json")
//    .Produces<Project>(201);

//app.MapPatch("projects/changename/{id:guid}", (Guid id, string name) =>
//{
//    var fixture = new Fixture();

//    var project = fixture.Create<Project>();

//    project.Id = id;
//    project.Name = name;
//    return Results.NoContent();
//})
//    .Accepts<Project>("application/json")
//    .Produces<Project>(204)
//    .Produces<Project>(400);

//app.MapDelete("projects/{id:guid}", (Guid id) =>
//{
//    return Results.Ok();
//})
//    .Accepts<Project>("application/json")
//    .Produces<Project>(200)
//    .Produces<Project>(400);

//app.Run();
#endregion

#region V2 simple with service
//using ExampleDomain.Classes.Entities;
//using MinimalApiCRUD.Services;

//var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
//builder.Services.AddScoped<IProjectService, ProjectService>();

//var app = builder.Build();

//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.MapGet("/projects", (IProjectService projectService) =>
//{
//    return projectService.GetAll();
//});

//app.MapGet("/project/{id:guid}", (Guid id, IProjectService projectService) =>
//{
//    return projectService.GetById(id);
//});

//app.MapPost("projects/", async (HttpRequest request, Project p, IProjectService projectService) =>
//{
//    var scheme = request.Scheme;
//    var host = request.Host;
//    var location = new Uri($"{scheme}{Uri.SchemeDelimiter}{host}/projects/{p.Id}");
//    await projectService.Save(p);
//    return Results.Created(location, p);
//})
//    .Accepts<Project>("application/json")
//    .Produces<Project>(201);

//app.MapPatch("projects/changename/{id:guid}", async (Guid id, string name, IProjectService projectService) =>
//{
//    await projectService.ChangeName(id, name);

//    return Results.NoContent();
//})
//    .Accepts<Project>("application/json")
//    .Produces<Project>(204)
//    .Produces<Project>(400);

//app.MapDelete("projects/{id:guid}", async (Guid id, IProjectService projectService) =>
//{
//    await projectService.Delete(id);

//    return Results.Ok();
//})
//    .Accepts<Project>("application/json")
//    .Produces<Project>(200)
//    .Produces<Project>(400);

//app.Run();
#endregion

#region V3 simple service - cleanUp
//using ExampleDomain.Classes.Entities;
//using MinimalApiCRUD.Services;

//var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
//builder.Services.AddScoped<IProjectService, ProjectService>();

//var app = builder.Build();

//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.MapGet("/project", GetAll);

//app.MapGet("/project/{id:guid}", Get);

//app.MapPost("projects/", Save)
//    .Accepts<Project>("application/json")
//    .Produces<Project>(201);

//app.MapPatch("projects/changename/{id:guid}", ChangeName)
//    .Accepts<Project>("application/json")
//    .Produces<Project>(204)
//    .Produces<Project>(400);

//app.MapDelete("projects/{id:guid}", Delete)
//    .Accepts<Project>("application/json")
//    .Produces<Project>(200)
//    .Produces<Project>(400);

//async Task<IEnumerable<Project>> GetAll(IProjectService projectService) => await projectService.GetAll();

//Task<Project> Get(Guid id, IProjectService projectService) => projectService.GetById(id);

//async Task<IResult> Save(HttpRequest request, Project p, IProjectService projectService)
//{
//    var scheme = request.Scheme;
//    var host = request.Host;
//    var location = new Uri($"{scheme}{Uri.SchemeDelimiter}{host}/projects/{p.Id}");
//    await projectService.Save(p);
//    return Results.Created(location, p);
//}

//async Task<IResult> ChangeName(Guid id, string name, IProjectService projectService)
//{
//    await projectService.ChangeName(id, name);

//    return Results.NoContent();
//}

//async Task<IResult> Delete(Guid id, IProjectService projectService)
//{
//    await projectService.Delete(id);

//    return Results.Ok();
//}

//app.Run();
#endregion

#region V4 add groups
//using ExampleDomain.Classes.Entities;
//using MinimalApiCRUD.Services;

//var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
//builder.Services.AddScoped<IProjectService, ProjectService>();

//var app = builder.Build();

//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//var projectEndpoints = app.MapGroup("/projects");

//projectEndpoints.MapGet("/", GetAll);

//projectEndpoints.MapGet("/project/{id:guid}", Get);

//projectEndpoints.MapPost("/", Save)
//    .Accepts<Project>("application/json")
//    .Produces<Project>(201);

//projectEndpoints.MapPatch("/changename/{id:guid}", ChangeName)
//    .Accepts<Project>("application/json")
//    .Produces<Project>(204)
//    .Produces<Project>(400);

//projectEndpoints.MapDelete("/{id:guid}", Delete)
//    .Accepts<Project>("application/json")
//    .Produces<Project>(200)
//    .Produces<Project>(400);

//async Task<IEnumerable<Project>> GetAll(IProjectService projectService) => await projectService.GetAll();

//Task<Project> Get(Guid id, IProjectService projectService) => projectService.GetById(id);

//async Task<IResult> Save(HttpRequest request, Project p, IProjectService projectService)
//{
//    var scheme = request.Scheme;
//    var host = request.Host;
//    var location = new Uri($"{scheme}{Uri.SchemeDelimiter}{host}/projects/{p.Id}");
//    await projectService.Save(p);
//    return Results.Created(location, p);
//}

//async Task<IResult> ChangeName(Guid id, string name, IProjectService projectService)
//{
//    await projectService.ChangeName(id, name);

//    return Results.NoContent();
//}

//async Task<IResult> Delete(Guid id, IProjectService projectService)
//{
//    await projectService.Delete(id);

//    return Results.Ok();
//}

//app.Run();
#endregion

#region V5 add Repos
using ExampleDomain.Classes.Entities;
using Microsoft.EntityFrameworkCore;
using MinimalApiCRUD.Repos;
using MinimalApiCRUD.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<IRepo, Repo>();

builder.Services.AddDbContext<Context>(opt=>opt.UseInMemoryDatabase("ContextInMemory"));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var projectEndpoints = app.MapGroup("/projects");

projectEndpoints.MapGet("/", GetAll);

projectEndpoints.MapGet("/project/{id:guid}", Get);

projectEndpoints.MapPost("/", Save)
    .Accepts<Project>("application/json")
    .Produces<Project>(201);

projectEndpoints.MapPatch("/changename/{id:guid}", ChangeName)
    .Accepts<Project>("application/json")
    .Produces<Project>(204)
    .Produces<Project>(400);

projectEndpoints.MapDelete("/{id:guid}", Delete)
    .Accepts<Project>("application/json")
    .Produces<Project>(200)
    .Produces<Project>(400);

async Task<IEnumerable<Project>> GetAll(IProjectService projectService) => await projectService.GetAll();

Task<Project> Get(Guid id, IProjectService projectService) => projectService.GetById(id);

async Task<IResult> Save(HttpRequest request, Project p, IProjectService projectService)
{
    var scheme = request.Scheme;
    var host = request.Host;
    var location = new Uri($"{scheme}{Uri.SchemeDelimiter}{host}/projects/{p.Id}");
    await projectService.Save(p);
    return Results.Created(location, p);
}

async Task<IResult> ChangeName(Guid id, string name, IProjectService projectService)
{
    await projectService.ChangeName(id, name);

    return Results.NoContent();
}

async Task<IResult> Delete(Guid id, IProjectService projectService)
{
    await projectService.Delete(id);

    return Results.Ok();
}

app.Run();
#endregion


