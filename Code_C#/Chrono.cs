using System;
using System.Diagnostics; 
//JE PEUX PEUT ETRE FAIRE PLUS SIMPLE A REGARDER 
public class Chrono
{    
    private Stopwatch stopwatch;
    private bool enCours;
    public int TempsTotal =600; // Temps total en secondes (10 minutes)
    public int TempsRestant => TempsTotal - (int)stopwatch.Elapsed.TotalSeconds;

    public Chrono()
    {    
        stopwatch = new Stopwatch(); // Fonction de chrono trouvé sur internet
        enCours = false;
    }

    public void LancerChrono()
    {
        enCours = true;
        stopwatch.Restart(); // Démarre ou redémarre le chrono

        while (enCours && stopwatch.Elapsed.TotalSeconds < TempsTotal)
        {
            int tempsRestant = TempsRestant;
            int minutes = tempsRestant / 60;
            int secondes = tempsRestant % 60;

            Console.WriteLine($"Temps restant : {minutes} minutes et {secondes} secondes.");
            System.Threading.Thread.Sleep(1000); // Attendre 1 seconde
        }

        if (stopwatch.Elapsed.TotalSeconds >= TempsTotal)
        {
            Console.WriteLine("Temps écoulé !");
        }

        stopwatch.Stop(); // Arrête le chrono
    }

    public void ArreterChrono()
    {
        enCours = false;
        stopwatch.Stop(); // Arrête le chrono
        int tempsRestant = TempsRestant;
        int minutes = tempsRestant / 60;
        int secondes = tempsRestant % 60;
        Console.WriteLine($"Chrono arrêté. Vous avez mis : {minutes} minutes et {secondes} secondes.");

    }
    public static bool operator <<(Chrono ChronoGauche, Chrono ChronoDroit)
    {
        return ChronoGauche.TempsRestant < ChronoDroit.TempsRestant;
    }
}