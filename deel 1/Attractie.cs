using System;

namespace Program;

public class Attractie
{
    public string Status { get; set; }
    public string Naam { get; set; }

    public async Task<int> AantalWachtenden() {
        await Willekeurig.Pauzeer(1000);
        return Willekeurig.Random.Next(0, 30);
    }

    private async Task VerzendHerstartCommando() {

        Task t = Task.Delay(1200);
        await Willekeurig.Pauzeer(1000);

        
    }

    public async Task Herstart()
    {
        Logger.Write("Opstarten van attractie " + Naam);
        Status = "Opstarten";

        try
        {
            await VerzendHerstartCommando();
            Logger.Write("Attractie " + Naam + " is opgestart");
            Status = "Werkt";
        }
        catch (Exception ex)
        {
            Logger.Write("Fout bij opstarten van attractie " + Naam + ": " + ex.Message);
            Status = "Kapot";
        }
    }
}
