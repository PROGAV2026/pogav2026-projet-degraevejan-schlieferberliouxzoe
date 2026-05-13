using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Spectre.Console;

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
        public string Nom { get; set; } = "";
        public int Temps { get; set; }
    }

    public string CheminFichier = "GestionScore/resultat.csv";

    public GestionScore()
    {

    }

    public void EnregistrementScore(string nom, Chrono temps)
    {
      
            using (StreamWriter writer = new StreamWriter(CheminFichier, append: true))
            {
                writer.WriteLine($"\n{nom};{temps.TempsTotal - temps.TempsRestant}");
            }
        }    
    
    public List<EntreeScore> LireScore()
    {
        var liste = new List<EntreeScore>();

        foreach (var line in File.ReadAllLines(CheminFichier))
        {
            if (string.IsNullOrWhiteSpace(line)) continue;
            var parts = line.Split(';');
            // if (parts.Length < 2) continue;
            if (!int.TryParse(parts[1], out int t)) continue;
            liste.Add(new EntreeScore { Nom = parts[0], Temps = t });
        }

        return liste.OrderBy(s => s.Temps).ToList();
    }
   
    public void AfficherClassement(int tempsIndividuel)
    {
        Console.Clear();
        Console.WriteLine("$Vous avez fait un temps de {tempsIndividuel}!");
        var scores = LireScore();
        var table = new Table()
        .Border(TableBorder.Rounded)
        .BorderColor(Color.Grey)
        .AddColumn(new TableColumn("[grey][/]").Centered())
        .AddColumn(new TableColumn("[bold]Joueur[/]"))
        .AddColumn(new TableColumn("[bold]Temps[/]").RightAligned());

    var medals = new[] { "[gold1]1st[/]", "[silver]2nd[/]", "[red]3rd[/]" };

        for (int i = 0; i < Math.Min(10, scores.Count); i++)
        {
            var rang = i<3 ? medals[i]:$"[grey]{i + 1}[/]";
            var nom = i<3? $"[bold]{scores[i].Nom}[/]": $"[white]{scores[i].Nom}[/]";
            var temps = $"[dim]{scores[i].Temps}[/]";
            table.AddRow(rang,nom,temps);
        }
        AnsiConsole.Write(new Rule("[bold yellow] Meilleurs temps [/]").RuleStyle("grey"));
        AnsiConsole.Write(table);
    }
}