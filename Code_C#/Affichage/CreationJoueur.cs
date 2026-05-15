using Spectre.Console;

public static class CreationJoueur
{
    public static bool DefinirJoueur(Joueur j)
    {
        AnsiConsole.Clear();
        var panel = new Panel("RENSEIGNEMENT POUR LA MISSION")
            .BorderColor(Color.Green)
            .RoundedBorder();
        panel.Border = BoxBorder.Double;
        AnsiConsole.Write(panel);

        while (j.Nom == "")
        {
            Console.WriteLine("Quel est votre nom?  \n");
            j.Nom = Console.ReadLine() ?? "";
            if (j.Nom == "")
            {
                Console.WriteLine("Veuillez entrer un nom ;) \n");
            }
        }

        int etageNumero = ChoisirEtage(j, "\nQuel étage voulez-vous être ?\n");
        if (etageNumero == -1)
        {
return false;        }
        string MessageTeleportation = j.DeplacementEtage(etageNumero);

        AnsiConsole.Clear();
        AnsiConsole.Progress()
            .Start(ctx =>
            {
                var task = ctx.AddTask("LANCEMENT DE LA MISSION", maxValue: 125);
                while (!ctx.IsFinished)
                {
                    task.Increment(1);
                    Thread.Sleep(2);
                }
            });
        Thread.Sleep(600);
        AnsiConsole.Write(MessageTeleportation);
        Thread.Sleep(100);
        AnsiConsole.Clear();
        return true;
    }

    public static int ChoisirEtage(Joueur j, string titre)
    {
        var choix = new List<string>();
        for (int i = 0; i < j.vaisseau.ListeEtages.Count; i++)
        {
            choix.Add($"{i + 1}. {j.vaisseau.ListeEtages[i].Nom}");
        }
        choix.Add($"{j.vaisseau.ListeEtages.Count + 1}. Annuler");

        string selection = AnsiConsole.Prompt(new SelectionPrompt<string>()
            .Title(titre)
            .PageSize(11)
            .AddChoices(choix)
            .HighlightStyle(new Style(Color.Cyan))
        );

        int etageChoisi = int.Parse(selection.Split('.')[0]) - 1;
        if (etageChoisi >= j.vaisseau.ListeEtages.Count)
            return -1;
        return etageChoisi;
    }
}
