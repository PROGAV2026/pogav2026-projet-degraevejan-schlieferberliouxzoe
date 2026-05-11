using Spectre.Console;

/// <summary>
/// CLASS QUI GERE : 
///                    Definission du joueur 
///                    Deplacement module / etage
///                    Capacité de récupérer la clé
/// </summary>
public class Joueur
{
    public string Nom { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public int PositionEtage { get; set; }
    public bool ALaCle { get; set; }
    public Random random = new Random();


    public Joueur()
    {
        ALaCle = false;
    }
    public void DefinirJoueur()
    {
        AnsiConsole.Clear();
        var panel = new Panel("RENSEIGNEMENT POUR LA MISSION")
        .BorderColor(Color.Green)
        .RoundedBorder();
        panel.Border = BoxBorder.Double;
        AnsiConsole.Write(panel);
        Console.WriteLine("Quel est votre nom?  \n");
        Nom = Console.ReadLine();
        PositionEtage = AnsiConsole.Prompt(
        new SelectionPrompt<int>()
            .Title("\nQuel étage voulait vous être ? \n")
            .PageSize(10)
            .AddChoices(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 })
            .HighlightStyle(new Style(Color.Green))
    );
        AnsiConsole.Clear();
        AnsiConsole.Progress()
        .Start(ctx =>
        {
            var task = ctx.AddTask("LANCEMENT DE LA MISSION", maxValue: 125);

            while (!ctx.IsFinished)
            {
                task.Increment(1);
                Thread.Sleep(20);
            }
        });
        Thread.Sleep(600);
        AnsiConsole.Clear();
    }
    public void DeplacementModule()
    {

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