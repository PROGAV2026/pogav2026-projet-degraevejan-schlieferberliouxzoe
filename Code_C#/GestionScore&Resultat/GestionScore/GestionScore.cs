using System.ComponentModel.DataAnnotations;
using Spectre.Console;

/// <summary>
/// CLASS QUI GERE : 
///                   Enregistrement des scores
///                   Lecture des scores 
///                   Affichage Classement joueur
/// </summary>
public class GestionScore
{

    public string CheminFichier = "";
    public int cleCesar;
    public string alphabetMaj = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    public string alphabetMin;
     public Random r = new Random();
    public class EntreeScore
    {   
        
        public string Nom { get; set; } = "";
        public int Temps { get; set; }
        
    }


    public GestionScore(bool modeTest)
    {
        cleCesar = 23;
        alphabetMin = alphabetMaj.ToLower();
        if (modeTest)
        {
            CheminFichier = "GestionScore&Resultat/GestionScore/resultatTest.csv";
        }
        else
        {
            CheminFichier = "GestionScore&Resultat/GestionScore/resultatVrai.csv";
        }
    }

    public void EnregistrementScore(string nom, Chrono temps)
    {
        string nomCrypte = CryptageCesar(cleCesar,nom);
        using (StreamWriter writer = new StreamWriter(CheminFichier, append: true))
        {
            writer.WriteLine($"\n{nomCrypte};{temps.TempsTotal - temps.TempsRestant}");
        }
    }

    public List<EntreeScore> LireScore()
    {
        var liste = new List<EntreeScore>();

        foreach (var line in File.ReadAllLines(CheminFichier))
        {
            if (string.IsNullOrWhiteSpace(line)) continue;
            var parts = line.Split(';');
            if (!int.TryParse(parts[1], out int t)) continue;
            liste.Add(new EntreeScore { Nom = parts[0], Temps = t });
        }

        return liste.OrderBy(s => s.Temps).ToList();
    }

    public void AfficherClassement(bool modeTest)
    {
        var scores = LireScore();
        var table = new Table()
        .Border(TableBorder.Rounded)
        .BorderColor(Color.Grey)
        .AddColumn(new TableColumn("[grey][/]").Centered())
        .AddColumn(new TableColumn("[bold]Joueur[/]"))
        .AddColumn(new TableColumn("[bold]Temps ( s )[/]").RightAligned());

        var medals = new[] { "[gold1]1er[/]", "[silver]2nd[/]", "[red]3eme[/]" };

        for (int i = 0; i < Math.Min(10, scores.Count); i++)
        {
            var rang = i < 3 ? medals[i] : $"[grey]{i + 1}eme[/]";
            string nomDecrypte = DecryptageCesar(cleCesar,scores[i].Nom);
            var nom = i < 3 ? $"[bold]{nomDecrypte}[/]" : $"[white]{nomDecrypte}[/]";
            var temps = $"[dim]{scores[i].Temps}[/]";
            table.AddRow(rang, nom, temps);
        }
        AnsiConsole.Write(new Rule($"[bold yellow] Meilleurs temps du mode {(modeTest ? "Test" : "Normal")}  [/]").RuleStyle("grey"));
        AnsiConsole.Write(table);
    }


    public string CryptageCesar(int cle,string nom)
    {
        cle = ((cle % 26) + 26) % 26;
        string cryptee = "";
        foreach (char lettre in nom)
        {
            if(alphabetMaj.Contains(lettre)) cryptee+= alphabetMaj[(alphabetMaj.IndexOf(lettre) + cle)%26]; 
            else if(alphabetMin.Contains(lettre)) cryptee+= alphabetMin[(alphabetMin.IndexOf(lettre) + cle)%26];
            else cryptee += lettre;
        } 
        return cryptee;
    }

    public string DecryptageCesar(int cle, string nom)
    {
        return CryptageCesar(-cle, nom );
    }

}

