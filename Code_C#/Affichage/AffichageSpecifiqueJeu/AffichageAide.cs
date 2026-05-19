using Spectre.Console;
/// <summary>
/// CLASS QUI GERE : 
///                   Affichage de l'aide
/// </summary>
public static class AffichageAide
{
    public static string AfficherAide()
    {
        return "\n\n[bold]FLECHE[/] :\n\n    +[white]↑ [/]: Haut\n    [white]↓[/]: Bas\n    [white]←[/]: Gauche\n    [white]→[/]: Droite\n\n[green]A[/]: Action\n[red]ESC[/]: Quitter";
    }
}