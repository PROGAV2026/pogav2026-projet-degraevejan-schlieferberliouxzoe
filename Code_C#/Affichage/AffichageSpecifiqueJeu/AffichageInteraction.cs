using Spectre.Console;
/// <summary>
/// CLASS QUI GERE : 
///                 Affichage de la partie interaction du jeu                
/// </summary>
//TODO : Afficher les éléments interactifs possibles en fonction de la position du joueur
public static class AffichageInteraction
{
    public static string NomInteraction = "INTERACTION";
    public static string MessageInteraction = "Aucune interaction possible";

    public static void AfficherElementsInteractifs(int numeroElement)
    {
        if (numeroElement == 0)
        {
            NomInteraction = "❌ INTERACTION";
            return;
        }
        else
        {
            switch (numeroElement)
            {
                case 1:
                    NomInteraction = "PORTE";
                    MessageInteraction = "Appuyez sur [green]A[/] pour ouvrir la porte.";
                    break;
                case 2:
                    NomInteraction = "CLE";
                    MessageInteraction = "Appuyez sur [green]A[/] pour ramasser la clé.";
                    break;
                case 3:
                    NomInteraction = "TELEPORTEUR";
                    MessageInteraction = "Appuyez sur [green]A[/] pour utiliser le téléporteur.";
                    break;
                case 4:
                    NomInteraction = "ASCENSEUR";
                    MessageInteraction = "Appuyez sur [green]A[/] pour utiliser l'ascenseur.";
                    break;
                default:
                    NomInteraction = "INTERACTION";
                    MessageInteraction = "Aucune interaction possible";
                    break;
            }
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