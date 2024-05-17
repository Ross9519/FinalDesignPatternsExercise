using DesignPatterns.ChainOfResponsibility.datamanagers;
using DesignPatterns.ChainOfResponsibility.handlers;
using DesignPatterns.ChainOfResponsibility.hosts;
using Microsoft.Extensions.DependencyInjection;


try
{
    var host = Container.CreateHostBuilder();

    var pairs = FileManager.CsvReader("csvOrders.txt");

    var receipts = ClientHandler.ControlChain(pairs);

    var dbManager = host.Services.GetRequiredService<DbManager>();

    var correctlySaved = await dbManager.SaveAllOrdersAndReceiptsAsync(pairs, receipts);

    if(correctlySaved)
        FileManager.CsvWriter("csvReceipts.txt", receipts);
}
catch (Exception e)
{
    Console.WriteLine($"Problem: {e.Message}");
}

// prova
//pairs.Select(p => p.Item1)
//    .Zip(receipts, (o, r) => (o, r))
//    .ToList()
//    .ForEach((x) => Console.WriteLine($"Order: {x.o}\nReceipt: {x.r}"));