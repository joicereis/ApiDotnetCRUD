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
    policy.AllowAnyOrigin(); //permitir acesso à todas as origens
    policy.AllowAnyMethod(); //permitir acesso à todas as método
    policy.AllowAnyHeader(); //permitir acesso à todas as cabeçalho
    }));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();
app.UseCors(); //definido o uso da política criada acima
app.MapPessoaRotas();

app.Run();

