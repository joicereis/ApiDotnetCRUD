using ApiDotnetCRUD.Models;

namespace ApiDotnetCRUD.Rotas
{
    public static class PessoaRotas
    {
        public static List<Pessoa> Pessoas = new List<Pessoa>()
        {
            new Pessoa(Guid.NewGuid(), "Margarida"),
            new Pessoa(Guid.NewGuid(), "Giovana"),
            new Pessoa(Guid.NewGuid(), "Estela")
        };
        public static void MapPessoaRotas(this WebApplication app)
        {
            app.MapGet("/pessoas", () => Pessoas);

            app.MapGet("/pessoas/{nome}", (string nome) => Pessoas.Find(x => x.Nome == nome));

            app.MapPost("/pessoas", (Pessoa pessoa) =>
            {
                Pessoas.Add(pessoa);
                return pessoa;
            });

            app.MapPut("/pessoas/{id:guid}", (Guid id, Pessoa pessoa) =>
            {
                var encontrado = Pessoas.Find(x => x.Id == id);

                if (encontrado == null)
                    return Results.NotFound();
                else
                {
                    encontrado.Nome = pessoa.Nome;
                    return Results.Ok(encontrado);
                }
            });
            app.MapDelete("/pessoas/{id:guid}" , (Guid id) =>
            {
                var encontrado = Pessoas.Find(x => x.Id == id);

                if (encontrado == null)
                    return Results.NotFound();
                else
                {
                    Pessoas.Remove(encontrado);
                    return Results.Ok(encontrado);
                }
            });
        }
    }
}