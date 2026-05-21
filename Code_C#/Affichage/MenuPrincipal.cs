using Spectre.Console;
/// <summary>
/// CLASS QUI GERE : 
///                   Affichage du menu principal
/// </summary>

public static class MenuPrincipal
{
    public static void AffichageMenuJeu()
    {
        AnsiConsole.Clear();
        AnsiConsole.Write(
              new FigletText("ZINZINS").Centered().Color(Color.Green)
          );
        AnsiConsole.Write(
            new Text("--- LE VAISSEAU AVEC LA CLÉ PERDUE ---", new Style(Color.Grey))
                .Centered()
        );
        AnsiConsole.WriteLine();
        AnsiConsole.WriteLine();
        AnsiConsole.Write(new Rule("[red][[CONTEXTE]][/]").RuleStyle("grey").Centered());
        AnsiConsole.WriteLine();
        AnsiConsole.MarkupLine("La moitié de la population a disparu en un [red]claquement de doigt[/], vous avez été téléporté dans un vaisseau. Mais aucun moyen de le démarrer. ");
        AnsiConsole.WriteLine();

        AnsiConsole.Write(
            new Text("[BUT DU JEU]", new Style(Color.Green)).Centered()
        );
        AnsiConsole.WriteLine();
        AnsiConsole.Write(new Markup("[italic]Retrouver la [green]clé[/] et regagner le bon poste de pilotage en moins de 10 minutes.[/]").Centered());
        AnsiConsole.WriteLine();
        AnsiConsole.WriteLine();
    }

    public static string AffichageMenuSelection()
    {
        return AnsiConsole.Prompt(new SelectionPrompt<string>()
        .Title("Veuillez choisir un mode !! Vite [bold red]VITTEE[/] votre vie est en jeu !!\n\n[grey]^ v Naviguer[/]     [grey][[ENTER]] Sélectionner[/] ")
        .AddChoices("1. Lancer le jeu", "2. Mode test", "3. Quitter")
        .HighlightStyle(new Style(Color.Green, Color.Black)));
    }

}

