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
    public Vaisseau vaisseau{get;set;} = new Vaisseau(true); //provisoire
    public string NomEtageCourant{get;set;}
    public Etage EtageCourant{get;set;}
    public Random random = new Random();


    public Joueur()
    {
        ALaCle = false;
        X = 13;
        Y = 13;
        
        vaisseau.ListeEtages[PositionEtage].MatriceEtage[X][Y] = 14;
        EtageCourant = vaisseau.ListeEtages[PositionEtage];
        NomEtageCourant = EtageCourant.Nom;
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
        int PositionEtageChoisi = AnsiConsole.Prompt(
        new SelectionPrompt<int>()
            .Title("\nQuel étage voulait vous être ? \n")
            .PageSize(10)
            .AddChoices(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 })
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

            case ConsoleKey.UpArrow:
                if (EtageCourant.MatriceEtage[X][Y-1] == 0) { Y = Math.Max(0, Y - 1);
                EtageCourant.MatriceEtage[X][Y-1] =14;
                EtageCourant.MatriceEtage[X][Y] =0;
                 }
                break;//Permet de mettre une limite
            case ConsoleKey.RightArrow:
                if (EtageCourant.MatriceEtage[X+1][Y] == 0) { X = Math.Min(29, X + 1);
                EtageCourant.MatriceEtage[X+1][Y] =14;
                EtageCourant.MatriceEtage[X][Y] =0; }
                break;
            case ConsoleKey.LeftArrow:
                if (EtageCourant.MatriceEtage[X-1][Y]== 0) { X = Math.Max(0, X - 1); 
                EtageCourant.MatriceEtage[X-1][Y] =14;
                EtageCourant.MatriceEtage[X][Y] =0;}
                break;
            case ConsoleKey.DownArrow:
                if (EtageCourant.MatriceEtage[X][Y+1]  == 0) { Y = Math.Min(29, Y + 1); 
                EtageCourant.MatriceEtage[X][Y+1] =14;
                EtageCourant.MatriceEtage[X][Y] =0;}
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