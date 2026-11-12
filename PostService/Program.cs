using System.Reflection;
using Microsoft.OpenApi;
using PostService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PostingDbContext>();
builder.Services.AddScoped<IPostingRepository, PostingRepository>();
builder.Services.AddScoped<IPostingsService, PostingsService>();

// Реєстрація Swagger та підключення XML-описів для DTO-моделей
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "PostService API",
        Version = "v1",
        Description = "REST API сервіс для обліку поштових відправлень"
    });

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFilename);
    if (File.Exists(xmlPath))
    {
        options.IncludeXmlComments(xmlPath);
    }
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<PostingDbContext>();
    db.Database.EnsureCreated();
}

// Увімкнення Swagger та Swagger UI
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "PostService API v1");
});

app.MapGet("/postings", (IPostingsService service) =>
{
    return Results.Ok(service.GetAll());
})
.WithName("GetAllPostings")
.WithSummary("Отримання списку всіх поштових відправлень")
.WithDescription("Повертає повний список зареєстрованих поштових відправлень у системі. Вхідні параметри відсутні.");

app.MapGet("/postings/{id:int}", (int id, IPostingsService service) =>
{
    var posting = service.GetById(id);
    return posting is null ? Results.NotFound() : Results.Ok(posting);
})
.WithName("GetPostingById")
.WithSummary("Отримання поштового відправлення за ID")
.WithDescription("Повертає детальну інформацію про конкретне поштове відправлення. Вхідний параметр: id (ціле число) — унікальний ідентифікатор поштового відправлення у маршруті запиту.");

app.MapPost("/postings", (PostingPostDto dto, IPostingsService service) =>
{
    var created = service.Create(dto);
    return Results.Created($"/postings/{created.Id}", created);
})
.WithName("CreatePosting")
.WithSummary("Створення нового поштового відправлення")
.WithDescription("Реєструє нове поштове відправлення у базі даних. Вхідний параметр: dto (тіло запиту у форматі JSON, модель PostingPostDto) з даними відправника, отримувача, вагою та описом відправлення.");

app.MapPut("/postings/{id:int}", (int id, PostingPutDto dto, IPostingsService service) =>
{
    var updated = service.Update(id, dto);
    return updated is null ? Results.NotFound() : Results.Ok(updated);
})
.WithName("UpdatePosting")
.WithSummary("Оновлення даних поштового відправлення")
.WithDescription("Оновлює інформацію про існуюче поштове відправлення за його ідентифікатором. Вхідні параметри: id (ціле число в URL) — ідентифікатор запису; dto (тіло запиту JSON, модель PostingPutDto) — оновлені поля відправлення.");

app.MapDelete("/postings/{id:int}", (int id, IPostingsService service) =>
{
    return service.Delete(id) ? Results.NoContent() : Results.NotFound();
})
.WithName("DeletePosting")
.WithSummary("Видалення поштового відправлення")
.WithDescription("Видаляє поштове відправлення з бази даних за його ідентифікатором. Вхідний параметр: id (ціле число в URL) — унікальний ідентифікатор відправлення для видалення.");

app.Run();