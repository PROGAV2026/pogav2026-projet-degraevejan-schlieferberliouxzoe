using Spectre.Console;
/// <summary>
/// CLASS QUI GERE : 
///                    Definission du joueur 
///                    Deplacement module / etage
///                    Capacité de récupérer la clé
/// </summary>
public class Joueur
{
    public string Nom { get; set; } = "";
    public int X { get; set; }
    public int Y { get; set; }
    public int PositionEtage { get; set; }
    public bool ALaCle { get; set; }
    public Vaisseau vaisseau { get; set; } //provisoire
    public Random random = new Random();
    public string NomEtageCourant { get; set; } = "";
    public Etage? EtageCourant { get; set; }

    public Joueur(bool modetest)
    {
        vaisseau = new Vaisseau(modetest);
        ALaCle = false;
        X = 14;
        Y = 13;
        InitialiserPosition();
    }
    public int ChoisirEtage(string titre)
    {
        var choix = new List<string>();
        for (int i = 0; i < vaisseau.ListeEtages.Count; i++)
        {
            choix.Add($"{i + 1}. {vaisseau.ListeEtages[i].Nom}");
        }
        choix.Add($"{vaisseau.ListeEtages.Count + 1}. Annuler");

        string selection = AnsiConsole.Prompt(new SelectionPrompt<string>()
            .Title(titre)
            .PageSize(10)
            .AddChoices(choix)
            .HighlightStyle(new Style(Color.Cyan))
        );

        int etageChoisi = int.Parse(selection.Split('.')[0]) - 1;

        if (etageChoisi >= vaisseau.ListeEtages.Count)
            return -1;

        return etageChoisi;
    }

    public void InitialiserPosition()
    {
        if (vaisseau.ListeEtages.Count > PositionEtage)
        {
            X = 14;
            Y = 13;
            EtageCourant = vaisseau.ListeEtages[PositionEtage];
            EtageCourant.MatriceEtage[X][Y] = 14;
            NomEtageCourant = EtageCourant.Nom;
        }
    }
    public void DefinirJoueur(Joueur j)
    {
        AnsiConsole.Clear();
        var panel = new Panel("RENSEIGNEMENT POUR LA MISSION")
        .BorderColor(Color.Green)
        .RoundedBorder();
        panel.Border = BoxBorder.Double;
        AnsiConsole.Write(panel);

        while (Nom == "")
        {
            Console.WriteLine("Quel est votre nom?  \n");

            Nom = Console.ReadLine() ?? "";
            if (Nom == "")
            {
                Console.WriteLine("Veuillez entrer un nom ;) \n");

            }
        }

        int etageNumero = ChoisirEtage("\nQuel étage voulez-vous être ?\n");
        if (etageNumero == -1) return;    
        DeplacementEtage(etageNumero);
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
        AnsiConsole.Clear();

    }
    public void VerifierCle()
    {



    }

    public void DeplacementDansModule(ConsoleKey key)
    {
        if (EtageCourant == null) return;

        switch (key)
        {
            case ConsoleKey.LeftArrow:
                if (Y - 1 >= 0 && EtageCourant.MatriceEtage[X][Y - 1] == 0)
                {
                    EtageCourant.MatriceEtage[X][Y] = 0;
                    Y = Y - 1;
                    EtageCourant.MatriceEtage[X][Y] = 14;
                }
                break;
            case ConsoleKey.DownArrow:
                if (X + 1 <= 29 && EtageCourant.MatriceEtage[X + 1][Y] == 0)
                {
                    EtageCourant.MatriceEtage[X][Y] = 0;
                    X = X + 1;
                    EtageCourant.MatriceEtage[X][Y] = 14;
                }
                break;
            case ConsoleKey.UpArrow:
                if (X - 1 >= 0 && EtageCourant.MatriceEtage[X - 1][Y] == 0)
                {
                    EtageCourant.MatriceEtage[X][Y] = 0;
                    X = X - 1;
                    EtageCourant.MatriceEtage[X][Y] = 14;
                }
                break;
            case ConsoleKey.RightArrow:
                if (Y + 1 <= 29 && EtageCourant.MatriceEtage[X][Y + 1] == 0)
                {
                    EtageCourant.MatriceEtage[X][Y] = 0;
                    Y = Y + 1;
                    EtageCourant.MatriceEtage[X][Y] = 14;
                }
                break;
        }
    }
    public void DeplacementEtage(int NumeroEtage)
    {
        if (EtageCourant == null) return;
        EtageCourant.MatriceEtage[X][Y] = 0;

        int ChanceBonneEtage = random.Next(0, 100);
        PositionEtage = ChanceBonneEtage > 20 
        ? NumeroEtage : random.Next(0, vaisseau.ListeEtages.Count > 0 ? vaisseau.ListeEtages.Count : 1);
        InitialiserPosition();
    }


    // public void RecupereCle()
    // {
    //     if( && ALaCle)
    //     {

    //     }
    // }

}