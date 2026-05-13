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
    public Stopwatch stopwatch;
    public bool enCours; // 
    public int TempsTotal = 600; // Temps total en secondes (10 minutes)
    public int TempsRestant => TempsTotal - (int)stopwatch.Elapsed.TotalSeconds;

    public Chrono()
    {
        stopwatch = new Stopwatch(); // Fonction de chrono trouvé sur internet
        enCours = false;
    }

    public void LancerChrono()
    {
        enCours = true;
        this.stopwatch.Restart();
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
        enCours = false;
        stopwatch.Stop();
        int tempsRestant = TempsRestant;
        int minutes = tempsRestant / 60;
        int secondes = tempsRestant % 60;
        Console.WriteLine($"Chrono arrêté. Vous avez mis : {minutes} minutes et {secondes} secondes.");

    }
    public static bool operator <<(Chrono ChronoGauche, Chrono ChronoDroit)
    {
        return ChronoGauche.TempsRestant < ChronoDroit.TempsRestant;
    }

    public static bool operator >>(Chrono chronoGauche, Chrono chronoDroit)
    {
        return chronoGauche.TempsRestant > chronoDroit.TempsRestant;
    }
}