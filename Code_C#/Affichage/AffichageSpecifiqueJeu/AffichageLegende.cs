using Spectre.Console;
/// <summary>
/// CLASS QUI GERE : 
///                   Affichage de la légende
/// </summary>
public static class AffichageLegende
{
    public static string AfficherLegende()
    {
        return "[red]██[/]: Téléporteur départ\n" +
    "[blue]██[/]: Téléporteur arrivé\n" +
    "[green]○[/][white]████[/]: Lit occupé \n" +
    "[white]▯████[/]: Lit vide \n" +
    "[aqua]███[/]: Écran de pilotage\n" +
    "[grey] ▲ [/]: Pied écran\n" +
    "[red]¡ [/]: Levier de contrôle\n" +
    "[bold red]()[/]: Noyau réacteur\n" +
    "[grey]██[/] et [yellow]██[/] : Blindage réacteur\n" +
    "[yellow]■[/]: Petite caisse\n" +
    "[orange3][[[/][yellow]Ω[/][orange3]]][/]: Coffre Ancien\n" +
    "[green]¬⚇[/]: Joueur (VOUS)\n";
    }
}

