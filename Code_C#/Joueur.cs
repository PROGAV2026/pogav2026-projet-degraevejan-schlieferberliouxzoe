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
        Console.WriteLine("Quel est votre nom \n");
        Nom = Console.ReadLine();
        Console.WriteLine("Quel étage voulait vous être ? \n");
        try
        {
            PositionEtage = int.Parse(Console.ReadLine());
        }
        catch
        {
            Console.WriteLine(" Mauvaise entrée. L'étage sera défini à 0 pour le départ.");
            PositionEtage = 0;
        }
        
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