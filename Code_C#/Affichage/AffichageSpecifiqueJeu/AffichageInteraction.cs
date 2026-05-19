using Spectre.Console;
/// <summary>
/// CLASS QUI GERE : 
///                 Affichage de la partie interaction du jeu               
/// </summary>
public static class AffichageInteraction
{
    public static string NomInteraction = "";
    public static string MessageInteraction = "";

    public static void AfficherElementsInteractifs(int NumeroElement)
    {
        if (NumeroElement == 0)
        {
            NomInteraction = "❌ INTERACTION";
            return;
        }

        string contenu = NumeroElement switch
        {
            3 => "[red]██[/] Téléporteur départ",
            4 => "[blue]██[/] Téléporteur arrivé",
            5 => "[green] ○[/][white]██[/] Lit occupé",
            6 => "[white] ▯[/][white]██[/] Lit vide",
            7 => "[white] ▯[/][white]██[/] Lit vide",
            8 => "[green] ○[/][white]██[/] Lit occupé",
            9 => "[blue] █[/][blue]██[/] Écran de pilotage", // Combiné 9 et 10
            10 => "[blue] █[/][blue]██[/] Écran de pilotage",
            12 => "[grey]▲ [/] Pied écran",
            13 => "[red]¡ [/] Levier de contrôle",
            14 => "[yellow]@@[/] Joueur (Vous)",
            15 => "[bold red]()[/] Noyau réacteur",
            16 => "[grey]██[/] Blindage réacteur",
            17 => "[yellow] ■[/] Débris / Petite caisse",
            18 => "[yellow]██[/] Caisse de matériel",
            19 => "[orange3][[[/][yellow]Ω[/][orange3]]][/] Coffre Ancien", // Combiné 19 et 20
            20 => "[orange3][[[/][yellow]Ω[/][orange3]]][/] Coffre Ancien",
            _ => "[yellow]Élément inconnu[/]"
        };

        MessageInteraction = "\n[grey]Appuyez sur A pour interagir[/]";
        NomInteraction = contenu;
    }
    public static void AfficherTeleportationEchouee()
    {
        AnsiConsole.Clear();
        AnsiConsole.Write(new FigletText(FigletFont.Default, "TELEPORTATION ECHOUE !")
            .Centered()
            .Color(Color.Red));
        AnsiConsole.Write(new Markup("Le portail quantique vous a téléportés dans un autre étage")
            .Centered());
        Thread.Sleep(2500);
        AnsiConsole.Clear();
    }
}