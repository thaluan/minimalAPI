using System.Collections.Generic;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/teste", () =>
{
    const string usuario = "THALUAN";
    const string mensagem = $"BEM VINDO {usuario}.";
    return mensagem;
});

app.MapGet("/priorityQueue", () =>
{
    var retorno = "";
    var prioritizedAgents = new PriorityQueue<Product,int>();

    prioritizedAgents.Enqueue(new Product() { Name = "Pao" }, 44);
    prioritizedAgents.Enqueue(new Product() { Name = "Bolo" }, 32);
    prioritizedAgents.Enqueue(new Product() { Name = "Biscoito" }, 50);
    prioritizedAgents.Enqueue(new Product() { Name = "Pao Doce" }, 34);
    prioritizedAgents.Enqueue(new Product() { Name = "Pao cachorro quente" }, 27);

    while (prioritizedAgents.TryDequeue(out var product, out var age))
    {
       retorno += ($"\n{product.Name}, prioridade {age}");
    }

    return retorno;
});

app.MapGet("/getProducts", () =>
{
    List<Product> productList = new List<Product>();
    var produto = new Product
    {
        Name = "Pao Frances",
        Description = "pao frances feito diretamento na franca e importado para o brasil",
        Price = 0.40,
        Link = "https://trello.com/1/cards/62dabead95b853603396e12e/attachments/62e17b2c0c37d75035f9e0d3/previews/62e17b2d0c37d75035f9e0e8/download/Captura_de_tela_2022-07-25_092000.png"
    };

    //codigo nao compila por ser um record init
    //produto.Price = 0.50;

    var produtoModificado = produto with { Price = 0.50,Link= "https://trello.com/1/cards/62dabead95b853603396e12e/attachments/62e17b22ca4274233a7ea8ee/download/Captura_de_tela_2022-07-25_091925.png" };
    productList.Add(produto);
    productList.Add(produtoModificado);
    return productList;
});



app.Run();

public record Product
{
    public string Name { get; init; }
    public double Price { get; init; }
    public string Description { get; init; }
    public string Link { get; init; }
}
