using CQRSMediatR.Context;
using CQRSMediatR.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
#region Resources
//https://blog.christian-schou.dk/how-to-implement-cqrs-with-mediatr-in-asp-net/
//https://www.gencayyildiz.com/blog/cqrs-pattern-nedir-mediatr-kutuphanesi-ile-nasil-uygulanir/
//https://medium.com/@mustafa.alkan/net-5-mediatr-k%C3%BCt%C3%BCphanesi-i%CC%87le-cqrs-implementasyonu-136ac9938bf6
#endregion


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDbSettings"));
builder.Services.AddScoped<IMongoDbContext, MongoDbContext>();
builder.Services.AddScoped<IBookReadRepository, BookReadRepository>();
builder.Services.AddScoped<IBookWriteRepository, BookWriteRepository>();


#region MediatR-Register
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Program>());
//builder.Services.AddMediatR(cfg =>
//{
//    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
//});
#endregion


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
