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
    var paofrances = new Product
    {
        Id = 1,
        Name = "Pao Frances",
        Description = "pao frances feito diretamento na franca e importado para o brasil",
        Price = 0.40,
        Link = "https://amopaocaseiro.com.br/wp-content/uploads/2020/04/receita-de-pao-frances-caseiro-IMG_4360.jpg"
    };

    var paoSuico = new Product
    {
        Id = 2,
        Name = "paoSuico",
        Description = "pao suico feito diretamento na franca e importado para o brasil",
        Price = 0.40,
        Link = "https://superprix.vteximg.com.br/arquivos/ids/206758-292-292/_MG_0246.png?v=637805520499300000"
    };

    var paoCachorroQuente = new Product
    {
        Id = 3,
        Name = "paoCachorroQuente",
        Description = "pao feito diretamento na franca e importado para o brasil",
        Price = 0.40,
        Link = "https://i.ytimg.com/vi/3uAg7zHEg7A/maxresdefault.jpg"
    };

    var paoDoce = new Product
    {
        Id = 4,
        Name = "paoDoce",
        Description = "pao doce feito diretamento na franca e importado para o brasil",
        Price = 0.40,
        Link = "https://trello.com/1/cards/62dabead95b853603396e12e/attachments/62e17b2c0c37d75035f9e0d3/previews/62e17b2d0c37d75035f9e0e8/download/Captura_de_tela_2022-07-25_092000.png"
    };

    var paoErvaDoce = new Product
    {
        Id = 5,
        Name = "paoErvaDoce",
        Description = "pao feito diretamento na franca e importado para o brasil",
        Price = 0.40,
        Link = "https://trello.com/1/cards/62dabead95b853603396e12e/attachments/62e17b2bc805e717ff38dde2/previews/62e17b2bc805e717ff38de05/download/Captura_de_tela_2022-07-25_091952.png"
    };

    var paoDoceFrutas = new Product
    {
        Id = 6,
        Name = "paoDoceFrutas",
        Description = "pao feito diretamento na franca e importado para o brasil",
        Price = 0.40,
        Link = "https://trello.com/1/cards/62dabead95b853603396e12e/attachments/62e17b236287366a1ee6fc6a/download/Captura_de_tela_2022-07-25_091943.png"
    };

    var BoloChocolate = new Product
    {
        Id = 7,
        Name = "Bolo de chocolate",
        Description = "bolo feito diretamento na franca e importado para o brasil",
        Price = 0.40,
        Link = "https://trello.com/1/cards/62dabead95b853603396e12e/attachments/62e17b1e21b8680ec751b409/download/Captura_de_tela_2022-07-25_091709.png"
    };

    var BoloCenoura = new Product
    {
        Id = 8,
        Name = "Bolo de Cenoura",
        Description = "bolo feito diretamento na franca e importado para o brasil",
        Price = 0.40,
        Link = "https://trello.com/1/cards/62dabead95b853603396e12e/attachments/62e17b20feb6288551b24f1d/download/Captura_de_tela_2022-07-25_091856.png"
    };

    var BoloChantilly = new Product
    {
        Id = 9,
        Name = "Bolo chantilly",
        Description = "bolofeito diretamento na franca e importado para o brasil",
        Price = 0.40,
        Link = "https://trello.com/1/cards/62dabead95b853603396e12e/attachments/62e17b1f2539705ce811b0c8/previews/preview/download/Captura_de_tela_2022-07-25_091757.png"
    };

    //codigo nao compila por ser um record init
    //produto.Price = 0.50;

    
    productList.Add(paofrances);
    productList.Add(paoSuico);
    productList.Add(paoCachorroQuente);
    productList.Add(paoDoce);
    productList.Add(paoErvaDoce);
    productList.Add(paoDoceFrutas);
    productList.Add(BoloChocolate);
    productList.Add(BoloCenoura);
    productList.Add(BoloChantilly);

    return productList;
});



app.Run();

public record Product
{
    public long Id { get; init; }
    public string Name { get; init; }
    public double Price { get; init; }
    public string Description { get; init; }
    public string Link { get; init; }
}
