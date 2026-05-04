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
    var usuario = usuarios.FirstOrDefault(u => u.Id == id);
    
    if (usuario == null){
        return Results.NotFound();
        
    }
    return Results.Ok(usuario);
});

app.MapPost("/usuarios", (CriarUsuario criarUsuario) => 
{   
    var id = usuarios.Count + 1;
    
    var usuario = new Usuario(id, criarUsuario.Nome);
    
    usuarios.Add(usuario);
    return $"Usuário {usuario.Nome} criado com sucesso";
});

app.Run();

record Usuario(int Id, string Nome);

record CriarUsuario(string Nome);



