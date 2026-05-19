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
    public List<int> EtageVisite{get;set;}= new List<int>();
    public bool ALaCle { get; set; }
    public bool ALaCarte {get;set;}
    public Vaisseau vaisseau { get; set; } //provisoire
    public Random random = new Random();
    public string NomEtageCourant { get; set; } = "";
    public Etage? EtageCourant { get; set; }
    public bool ABienMisLaCle {get;set;}

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
            EtageCourant = vaisseau.ListeEtages[PositionEtage];
            EtageCourant.MatriceEtage[X][Y] = 14;
            NomEtageCourant = EtageCourant.Nom;
        }
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
    public string DeplacementEtage(int NumeroEtage)
    {
        if (EtageCourant == null) return "";
        EtageCourant.MatriceEtage[X][Y] = 0;

        int ChanceBonneEtage = random.Next(0, 100);
        PositionEtage = ChanceBonneEtage > 20 
        ? NumeroEtage : random.Next(0, vaisseau.ListeEtages.Count > 0 ? vaisseau.ListeEtages.Count : 1);
        InitialiserPosition();
       if (!EtageVisite.Contains(PositionEtage))
       {
            EtageVisite.Add(PositionEtage);
       }

        if (NumeroEtage != PositionEtage)
        {
            return "[red]TELEPORTATION ECHOUE[/] : le portail quantique vous a téléportez dans un autre étage";
        }
        else{
            return "[green]TELEPORTATION REUSSIT[/]";
        }
    }
   


    // public void RecupereCle()
    // {
    //     if( && ALaCle)
    //     {

    //     }
    // }

}