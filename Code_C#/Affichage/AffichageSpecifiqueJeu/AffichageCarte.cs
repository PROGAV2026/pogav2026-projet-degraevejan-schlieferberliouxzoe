using Spectre.Console;
/// <summary>
/// CLASS QUI GERE : 
///                   Affichage de la carte
/// </summary>
public static class AffichageCarte
{
    public static string AfficherCarte(Joueur joueur)
    {
        string contenu = "\n\n";
        for (int i = 0; i < joueur.Vaisseau.ListeEtages.Count; i++)
        {
            bool visite = joueur.EtageVisite.Contains(i);

            if (visite)
                contenu += $"{i + 1}.[green] {joueur.Vaisseau.ListeEtages[i].Nom}[/]\n";
            else
                contenu += $"{i + 1}.[red] ???[/]\n";
        }
        return contenu;
    }

}


