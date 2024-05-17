using DesignPatterns.ChainOfResponsibility.enums;
using DesignPatterns.ChainOfResponsibility.mappers;
using DesignPatterns.ChainOfResponsibility.models;

namespace DesignPatterns.ChainOfResponsibility.datamanagers
{
    internal static class FileManager
    {
        public static List<(Order, List<Ingredient>)> CsvReader(string file)
        {
            var pairs = new List<(Order, List<Ingredient>)>();
            using var reader = new StreamReader(file);
            while(!reader.EndOfStream)
            {
                pairs.Add(OrderMapper.StringToOrder(reader.ReadLine()!)); 
            }
            return (pairs);
        }

        public static bool CsvWriter(string file, List<Receipt> receipts)
        {
            try
            {
                using var writer = new StreamWriter(file, true);
                receipts.ForEach(r => writer.WriteLine($"{r.Id};{r.Order?.Base};{r.Order?.Dough};{string.Join(",", r.Order?.OrderIngredients.Select(oi => (IngredientEnum)oi.IngredientId - 1)!)};{r.Cost}"));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
