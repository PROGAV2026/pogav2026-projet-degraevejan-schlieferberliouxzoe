using Spectre.Console;
/// <summary>
/// CLASS QUI GERE : 
///                   Affichage du header
/// </summary>
public static class AffichageHeader
{
    public static string AfficherHeader(Joueur j, Chrono c)
    {
        string cle = j.ALaCle ? "[green]OUI[/]" : "[red]NON[/]";
        string etage = "";
        string etageActuel = "";
        if (j.NomEtageCourant == "Lieu de Vie")
        {
            etage = "[green]Lieu de Vie[/]";
            etageActuel = $"[green]{j.PositionEtage + 1}[/]";
        }
        else if (j.NomEtageCourant == "Poste de pilotage")
        {
            etage = "[blue]Poste de pilotage[/]";
            etageActuel = $"[blue]{j.PositionEtage + 1}[/]";
        }
        else if (j.NomEtageCourant == "Salle des machines")
        {
            etage = "[yellow]Salle des machines[/]";
            etageActuel = $"[yellow]{j.PositionEtage + 1}[/]";
        }
        if(j.modeTest) return $"Clé: {cle} | Étage: {etageActuel} - [[{etage}]] | Temps: [yellow]{c.AffichageChrono()}[/] | La clé est dans : {j.vaisseau.EtageCleCache.Nom}, dans {j.vaisseau.EtageCleCache.ChiffreVersCaractere(j.vaisseau.EtageCleCache.MatriceEtage[j.vaisseau.XCle][j.vaisseau.YCle])}";
    
        return $"Clé: {cle} | Étage: {etageActuel} - [[{etage}]] | Temps: [yellow]{c.AffichageChrono()}[/]";
    }

}