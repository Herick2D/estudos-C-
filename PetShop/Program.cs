using PetShop.Services; // Importa o namespace do servi�o de pets
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSingleton<IPetService, PetService>(); // build para adicionar o servi�o de pets https://refactoring.guru/pt-br/design-patterns/singleton
builder.Services.AddSwaggerGen();
builder.Services.AddControllers(); // build para adicionar o servi�o de controllers

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers(); // build para mapear os controllers

app.Run();
