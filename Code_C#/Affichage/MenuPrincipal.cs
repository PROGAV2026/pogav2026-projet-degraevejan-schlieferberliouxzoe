using Spectre.Console;

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
        AnsiConsole.Write(new Rule("[red]CONTEXTE[/]").RuleStyle("grey").Centered());
        AnsiConsole.WriteLine();
        AnsiConsole.MarkupLine("Après l'apocalypse nucléaire, à la suite d'une guerre déclenchée après un attentat sur Donald Trump. Vous décidez de fuir en vaisseau. Ainsi vous voici à la recherche de la clé du vaisseau.");
        AnsiConsole.WriteLine();

        AnsiConsole.Write(
            new Text("[BUT DU JEU]", new Style(Color.Green)).Centered()
        );
        AnsiConsole.WriteLine();

        AnsiConsole.Write(new Markup("[italic]Retrouver la clé et regagner le bon poste de pilotage en moins de 10 minutes.[/]").Centered());
        AnsiConsole.WriteLine();
        AnsiConsole.WriteLine();
    }

    public static string AffichageMenuSelection()
    {
        return AnsiConsole.Prompt(new SelectionPrompt<string>()
         .Title("Veuillez choisir un mode !! Vite [bold red]VITTEE[/] votre vie est en jeu !!")
         .AddChoices("1. Lancer le jeu", "2. Mode test", "3. Quitter")
         .HighlightStyle(new Style(Color.Green, Color.Black)));
    }
}