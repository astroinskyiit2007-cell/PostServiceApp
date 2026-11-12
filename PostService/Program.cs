using PostService;
using PostService.Dtos;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PostingDbContext>();
builder.Services.AddScoped<IPostingRepository, PostingRepository>();
builder.Services.AddScoped<IPostingsService, PostingsService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<PostingDbContext>();
    db.Database.EnsureCreated();
}

app.MapGet("/postings", (IPostingsService service) =>
{
    return Results.Ok(service.GetAll());
});

app.MapGet("/postings/{id:int}", (int id, IPostingsService service) =>
{
    var posting = service.GetById(id);
    return posting is null ? Results.NotFound() : Results.Ok(posting);
});

app.MapPost("/postings", (PostingPostDto dto, IPostingsService service) =>
{
    var created = service.Create(dto);
    return Results.Created($"/postings/{created.Id}", created);
});

app.MapPut("/postings/{id:int}", (int id, PostingPutDto dto, IPostingsService service) =>
{
    var updated = service.Update(id, dto);
    return updated is null ? Results.NotFound() : Results.Ok(updated);
});

app.MapDelete("/postings/{id:int}", (int id, IPostingsService service) =>
{
    return service.Delete(id) ? Results.NoContent() : Results.NotFound();
});

app.Run();