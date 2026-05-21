using System.Diagnostics;
/// <summary>
/// CLASS QUI GERE : 
///                 Lancement du chrono 
///                 Affichage du chrono pour la boucle du jeu
///                 Arret du chrono
///                 Comparaison de chrono entre eux
/// </summary>
public class Chrono
{
    public Stopwatch Stopwatch;
    public bool EnCours; // 
    public int TempsTotal = 600; // Temps total en secondes (10 minutes)
    public int TempsRestant => TempsTotal - (int)Stopwatch.Elapsed.TotalSeconds;

    public Chrono()
    {
        Stopwatch = new Stopwatch(); // Fonction de chrono trouvé sur internet
        EnCours = false;
    }

    public void LancerChrono()
    {
        EnCours = true;
        this.Stopwatch.Restart();
    }
    public string AffichageChrono()
    {
        int tempsRestant = TempsRestant;
        int minutes = tempsRestant / 60;
        int secondes = tempsRestant % 60;
        return $"{minutes:D2}:{secondes:D2}"; //D2 permet d'avoir 2 chiffres donc quand des numeros de 0 à 10 affiche quand meme 01..
    }
    public void ArreterChrono()
    {
        EnCours = false;
        Stopwatch.Stop();
        int tempsRestant = TempsRestant;
        int minutes = tempsRestant / 60;
        int secondes = tempsRestant % 60;
        Console.WriteLine($"Chrono arrêté. Vous avez mis : {10 - minutes} minutes et {60 - secondes} secondes.");

    }
    //Creation d opérations de comparaison pour pouvoir les utiliser dans le reste du code
    public static bool operator <<(Chrono chronoGauche, Chrono chronoDroit)
    {
        return chronoGauche.TempsRestant < chronoDroit.TempsRestant;
    }

    public static bool operator >>(Chrono chronoGauche, Chrono chronoDroit)
    {
        return chronoGauche.TempsRestant > chronoDroit.TempsRestant;
    }
}