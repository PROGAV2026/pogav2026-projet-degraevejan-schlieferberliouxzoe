using Spectre.Console;
/// <summary>
/// CLASS QUI GERE : 
///                 Affichage de la partie interaction du jeu               
/// </summary>
public static class AffichageInteraction
{

    public static string NomInteraction = "";
    public static string MessageInteraction = "";

    public static void AfficherElementsInteractifs(int elementProche)
    {

        switch (elementProche)
        {
            case 3:
                NomInteraction = "[red]██[/] TELEPORTEUR DEPART";
                MessageInteraction = " Appuyez sur A pour utiliser le téléporteur.";
                break;
            case 4:
                NomInteraction = "[blue]██[/] TELEPORTEUR ARRIVE ";
                MessageInteraction = "Bienvenue";
                break;
            case 5:
            case 8:
                NomInteraction = "[green]○[/][white]████[/] LIT OCCUPE";
                MessageInteraction = "Appuyez sur A pour reveiller le zinzin.";
                break;
            case 6:
            case 7:
                NomInteraction = "[white]▯████[/] LIT VIDE";
                MessageInteraction = "Appuyez sur A pour chercher la clé dans le lit.";
                break;
            case 9:
            case 10:
                NomInteraction = "[Aqua]███[/] ECRAN DE PILOTAGE";
                MessageInteraction = "Appuyez sur A pour regarder les actualités sur l'écran.";
                break;
            case 12:
                NomInteraction = "[grey]▲ [/] PIED ECRAN";
                MessageInteraction = "Appuyez sur A pour inspecter ce triangleeee ";
                break;
            case 13:
            case 21:
                NomInteraction = "[red]¡ [/] LEVIER DE CONTROLE";
                MessageInteraction = "Appuyez sur A pour utiliser le levier.";
                break;
            case 16:
                NomInteraction = "[grey]██[/] BLINDAGE REACTEUR";
                MessageInteraction = "Appuyez sur A pour inspecter le reacteur.";
                break;
            case 17:
                NomInteraction = "[yellow] ■[/] DEBRIS";
                MessageInteraction = "Appuyez sur A pour inspecter les débris.";
                break;
            case 18:
                NomInteraction = "[yellow]██[/] CAISSE DE MATERIEL";
                MessageInteraction = "Appuyez sur A pour ouvrir la caisse.";
                break;
            case 19:
            case 20:
                NomInteraction = "[orange3][[[/][yellow]Ω[/][orange3]]][/] COFFRE ANCIEN";
                MessageInteraction = "Appuyez sur A pour ouvrir le coffre.";
                break;
            default:
                NomInteraction = "❌ INTERACTION";
                MessageInteraction = "Aucune interaction possible.";
                break;
        }
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