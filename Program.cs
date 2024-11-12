using ApiDotnetCRUD.Rotas;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Definir quais politicas podem ser acessadas pelo Angular
builder.Services.AddCors(option =>
    option.AddDefaultPolicy(policy =>
    {
    policy.AllowAnyOrigin(); //permitir acesso � todas as origens
    policy.AllowAnyMethod(); //permitir acesso � todas as m�todo
    policy.AllowAnyHeader(); //permitir acesso � todas as cabe�alho
    }));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();
app.UseCors(); //definido o uso da pol�tica criada acima
app.MapPessoaRotas();

app.Run();

