var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddAppServices(builder.Configuration);

//Docker HTTP
builder.WebHost.UseUrls("http://*:5009");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSwagger();
app.UseSwaggerUI();

// Enable routing (important for mapping endpoints)
app.UseRouting();

// Map endpoints to controllers (this executes the API controllers)
app.MapControllers();

//app.UseHttpsRedirection();

app.Run();