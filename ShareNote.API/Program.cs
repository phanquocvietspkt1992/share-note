using ShareNote.Infrasstructure;
using ShareNote.Application.Services.Elasticsearchs;
using MongoDB.Driver;
using ShareNote.Infrasstructure.Seeds;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
// Add services to the container
var configuration = builder.Configuration;
var dbProvider = configuration["DatabaseProvider"];

if (dbProvider == "MongoDB")
{
    var client = new MongoClient(configuration.GetConnectionString("MongoConnection"));
    var database = client.GetDatabase("MyDB");
    database.CreateCollection("note-collection");
    builder.Services.AddSingleton<IMongoDatabase>(database);
    builder.Services.AddScoped<INoteRepository, MongoNoteRepository>();
}
else if (dbProvider == "SqlServer")
{
    // builder.Services.AddDbContext<ApiDbContext>(options =>
    //     options.UseSqlServer(configuration.GetConnectionString("SqlServerConnection")));
    // builder.Services.AddScoped<IApiObjectRepository, SqlApiObjectRepository>();
}
else if (dbProvider == "PostgreSQL")
{
    // builder.Services.AddDbContext<ApiDbContext>(options =>
    //     options.UseNpgsql(configuration.GetConnectionString("PostgreSqlConnection")));
    // builder.Services.AddScoped<IApiObjectRepository, SqlApiObjectRepository>();
};
builder.Services.AddCors(options =>
  {
      options.AddPolicy("AllowAngularApp", builder =>
      {
          builder.WithOrigins("http://localhost:4200") // Allow Angular frontend
                 .AllowAnyMethod()                 // Allow any HTTP methods (GET, POST, etc.)
                 .AllowAnyHeader();                // Allow any headers
      });
  });
// Register services
builder.Services.AddSingleton<ElasticClientProvider>();
builder.Services.AddScoped<ElasticsearchService>();
builder.Services.AddScoped<ElasticsearchDataSeeder>();
builder.Services.AddScoped<NoteDataSeeder>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();
// Enable CORS using the configured policy
app.UseCors("AllowAngularApp");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
