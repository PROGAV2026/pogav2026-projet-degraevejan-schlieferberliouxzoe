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
        X = 13;
        Y = 13;
        InitialiserPosition();
    }
    
    public void InitialiserPosition()
    {
        if (vaisseau.ListeEtages.Count > PositionEtage)
        {
            X = 14;
            Y = 13;
            vaisseau.ListeEtages[PositionEtage].MatriceEtage[X][Y] = 14;

            EtageCourant = vaisseau.ListeEtages[PositionEtage];
            NomEtageCourant = EtageCourant.Nom;
        }
    }
    public void DefinirJoueur()
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
        List<int>NombreEtage=new List<int>{};
        for (int i = 0; i < vaisseau.ListeEtages.Count(); i++)
        {
            NombreEtage.Add(i+1);
        }
        int PositionEtageChoisi = AnsiConsole.Prompt(
        new SelectionPrompt<int>()
            .Title("\nQuel étage voulait vous être ? \n")
            .PageSize(10)
            .AddChoices(NombreEtage)
            .HighlightStyle(new Style(Color.Green))
    );
        DeplacementEtage(PositionEtageChoisi);
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
   public void DeplacementDansModule(ConsoleKey key)
    {

        switch (key)
        {
            case ConsoleKey.LeftArrow:
                if (Y - 1 >= 0 && EtageCourant.MatriceEtage[X][Y-1] == 0)
                {
                    EtageCourant.MatriceEtage[X][Y] = 0;
                    Y = Y - 1;
                    EtageCourant.MatriceEtage[X][Y] = 14;
                }
                break;
            case ConsoleKey.DownArrow:
                if (X + 1 <= 29 && EtageCourant.MatriceEtage[X+1][Y] == 0)
                {
                    EtageCourant.MatriceEtage[X][Y] = 0;
                    X = X + 1;
                    EtageCourant.MatriceEtage[X][Y] = 14;
                }
                break;
            case ConsoleKey.UpArrow:
                if (X - 1 >= 0  && EtageCourant.MatriceEtage[X-1][Y] == 0)
                {
                    EtageCourant.MatriceEtage[X][Y] = 0;
                    X = X - 1;
                    EtageCourant.MatriceEtage[X][Y] = 14;
                }
                break;
            case ConsoleKey.RightArrow:
                if (Y + 1 <= 29 && EtageCourant.MatriceEtage[X][Y+1] == 0)
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
        EtageCourant.MatriceEtage[X][Y] = 0;

        int ChanceBonneEtage = random.Next(0, 100);
        int maxIndex = Math.Max(0, vaisseau.ListeEtages.Count - 1);

        if (ChanceBonneEtage > 20)
        {
            PositionEtage = NumeroEtage;
            EtageCourant = vaisseau.ListeEtages[PositionEtage];
            EtageCourant.MatriceEtage[X][Y] = 14;

        }
        else
        {
            PositionEtage = random.Next(0, vaisseau.ListeEtages.Count > 0 ? vaisseau.ListeEtages.Count : 1);
            EtageCourant = vaisseau.ListeEtages[PositionEtage];
            EtageCourant.MatriceEtage[X][Y] = 14;
        }
         InitialiserPosition();
    }
    
    // public void DeplacementEtage(int NumeroEtage)
    // {
    //     int ChanceBonneEtage = random.Next(0,100);

    //     if (ChangeBonneEtage < 20)
    //     {
    //         PositionEtage =NumeroEtage;
    //     }
    //     else {
    //     NumeroNewEtage = random.Next(0,10);
    //     PositionEtage = NumeroNewEtage;

    //     }
    // }
    // public void RecupereCle()
    // {
    //     if( && ALaCle)
    //     {

    //     }
    // }

}