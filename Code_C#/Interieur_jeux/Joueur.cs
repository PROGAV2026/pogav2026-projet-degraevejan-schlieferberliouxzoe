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
    public List<int> EtageVisite { get; set; } = new List<int>();
    public bool ALaCle { get; set; }
    public Vaisseau Vaisseau { get; set; }
    public Random Random = new Random();
    public string NomEtageCourant { get; set; } = "";
    public Etage? EtageCourant { get; set; }
    public bool ABienMisLaCle { get; set; }
    public bool ModeTest;

    public Joueur(bool modeTest)
    {
        ModeTest = modeTest;
        Vaisseau = new Vaisseau(modeTest);
        ALaCle = false;
        InitialiserPosition();
    }

    public void InitialiserPosition()
    {
        if (Vaisseau.ListeEtages.Count > PositionEtage)
        {
            X = 14;
            Y = 13;
            EtageCourant = Vaisseau.ListeEtages[PositionEtage];
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
    public bool DeplacementEtage(int NumeroEtage)
    {
        if (EtageCourant == null) return false;

        EtageCourant.MatriceEtage[X][Y] = 0;

        int ChanceBonneEtage = Random.Next(0, 100);
        PositionEtage = ChanceBonneEtage > 40
        ? NumeroEtage : Random.Next(0, Vaisseau.ListeEtages.Count > 0 ? Vaisseau.ListeEtages.Count : 1);
        InitialiserPosition();
        if (!EtageVisite.Contains(PositionEtage))
        {
            EtageVisite.Add(PositionEtage);
        }
        else{
            return false;
        }

        return true;
    }

}