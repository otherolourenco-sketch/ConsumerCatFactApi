using System.Net.Http.Json;

const string endpoint = "https://catfact.ninja/fact";

using HttpClient httpClient = new();

try
{
    CatFact? catFact = await httpClient.GetFromJsonAsync<CatFact>(endpoint);

    if (catFact is null)
    {
        Console.WriteLine("Não foi possível obter o fato sobre gatos.");
        return;
    }

    Console.WriteLine("Fato sobre Gatos:");
    Console.WriteLine(catFact.Fact);
}
catch (HttpRequestException ex)
{
    Console.WriteLine("Erro ao acessar a API.");
    Console.WriteLine($"Detalhes: {ex.Message}");
}
catch (Exception ex)
{
    Console.WriteLine("Ocorreu um erro inesperado.");
    Console.WriteLine($"Detalhes: {ex.Message}");
}

public class CatFact
{
    public string? Fact { get; set; }
    public int Length { get; set; }
}