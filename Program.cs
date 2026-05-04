var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};



var usuarios = new List<Usuario>();

app.MapGet("/usuarios", () => 
{
    return usuarios;

});

app.MapGet("/usuarios/{id}", (int id) =>
{
    return "Usuário " + id;
});

app.MapPost("/usuarios", (Usuario usuario) => 
{
    usuarios.Add(usuario);
    return $"Usuário {usuario.Nome} criado com sucesso";
});

app.Run();

record Usuario(string Nome);

