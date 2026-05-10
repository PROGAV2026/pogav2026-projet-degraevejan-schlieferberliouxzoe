/// <summary>
/// CLASS QUI GERE : 
///                   Enregistrement des scores
///                   Lecture des scores 
///                   Affichage Classement joueur
/// </summary>

public class GestionScore
{
    public class EntreeScore
    {
        public string nom { get; set; }
        public int temps { get; set; }
    }

    public string CheminFichier = "resultat.csv";

    public GestionScore()
    {
        
    }

    public void EnregistrementScore(string nom, Chrono temps)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(CheminFichier, append: true))
            {
                writer.WriteLine($"{nom};{temps.TempsTotal - temps.TempsRestant}");
            }
            Console.WriteLine("Score enregistré");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur lors de l'enregistrement du score : {ex.Message}");
        }
    }
    // public List<EntreeScore> lireScore()
    // {
    //     // Code pour lire les scores depuis un fichier
    // // }
    // public void AfficherClassement()
    // {
    //     var scores = lireScore();
    //     Console.WriteLine("MEILLEURS TEMPS ;) : ");
    //     for (int i = 0; i < Math.Min(10, scores.Count); i++)
    //     {
    //         Console.WriteLine($"{i + 1} - {scores[i].nom}-{scores[i].temps}");
    //     }
    // }
}