/// <summary>
/// CLASS QUI GERE : 
///                   La gestion des interactions du joueur : que fait le jeu lorsque le joueur appuie sur la touche d'action. 
/// </summary>
using Spectre.Console;

public class GestionInteraction
{
    public bool TeleportationEchouee = false;
    public int XInteraction { get; set; }
    public int YInteraction { get; set; }

    public GestionInteraction(Joueur joueur)
    {
    }

    public int VerifierInteractionJeu(Joueur joueur)
    {
        int[] dx = { -1, 1, 0, 0 };
        int[] dy = { 0, 0, -1, 1 };
        for (int i = 0; i < 4; i++)
        {
            if (joueur.EtageCourant == null) return 0;

            int newX = joueur.X + dx[i];
            int newY = joueur.Y + dy[i];
            if (newX >= 0 && newX <= 29 && newY >= 0 && newY < +29)
            {
                int NumeroElement = joueur.EtageCourant.MatriceEtage[newX][newY];
                if (NumeroElement != 0 && NumeroElement != 2 && NumeroElement != 1 && NumeroElement != 14)
                {
                    XInteraction = newX;
                    YInteraction = newY;
                    return NumeroElement;
                }
            }

        }
        return 0;

    }
    public string InteractionAvecElement(int NumeroElement, Joueur joueur, Layout layout, LiveDisplayContext ctx, Jeux jeux, Chrono chrono)
    {
        int Xcle = joueur.Vaisseau.XCle;
        int Ycle = joueur.Vaisseau.YCle;
        bool conditionRecuperationCLe = !joueur.ALaCle && (joueur.EtageCourant == joueur.Vaisseau.EtageCleCache) && (XInteraction == Xcle) && (YInteraction == Ycle);

        if (NumeroElement == 19)
        {
            conditionRecuperationCLe = !joueur.ALaCle && (joueur.EtageCourant == joueur.Vaisseau.EtageCleCache) && (XInteraction == Xcle) && ((YInteraction == Ycle) || (YInteraction == Ycle - 1));

        }
        if (NumeroElement == 20)
        {
            conditionRecuperationCLe = !joueur.ALaCle && (joueur.EtageCourant == joueur.Vaisseau.EtageCleCache) && (XInteraction == Xcle) && ((YInteraction == Ycle) || (YInteraction == Ycle + 1));

        }
        if (conditionRecuperationCLe)
        {
            joueur.ALaCle = true;
            return "Bravo ! La clé était cachée ici, maintenant ramenez la au bon poste de pilotage";
        }
        else
        {
            switch (NumeroElement)
            {
                case 3:
                    int etageCible = MenuTeleportation(joueur.Vaisseau, layout, ctx, jeux, joueur, chrono);
                    bool resultat = joueur.DeplacementEtage(etageCible);
                    if (!resultat)
                    {
                        TeleportationEchouee = true;
                    }
                    return "";

                case 4:
                    return "Vous venez d'ici ! Allez explorer les alentours";

                case 6:
                case 7:
                    return "Il n'y as rien sous la couette";
                case 5:
                case 8:
                    return "Ce zinzin dort à point fermé, ne le dérangez pas !";
                case 9:
                case 10:
                    return "Rha, c est juste un écran de contrôle du vaisseau, rien ne peux être caché ici";
                case 12:
                    return "Ce qui soutient l'écran, pas de cachette possible";
                case 13:
                    if (!joueur.ALaCle)
                    {
                        return "Vous devez trouver la clé avant de venir ici";
                    }
                    else return "La clé ne va pas dans ce levier, dommage !";
                case 16:
                case 18:
                    return "Le mur du réacteur, attention c'est dangereux !";
                case 17:
                    return "Cette caisse est vide";
                case 19:
                case 20:
                    return "Ce coffre est vide";
                case 21:
                    if (!joueur.ALaCle)
                    {
                        return "Vous devez trouver la clé avant de venir ici";
                    }
                    else
                    {
                        joueur.ABienMisLaCle = true;
                        return "BRAVOOOOOOOOOOO!!!!";
                    }

                default:

                    return "";
            }
        }
    }
    public int MenuTeleportation(Vaisseau vaisseau, Layout layout, LiveDisplayContext ctx, Jeux jeux, Joueur joueur, Chrono chrono)
    {
        var etages = vaisseau.ListeEtages;
        int selection = 0;

        while (true)
        {

            string contenu = "[red]Choisir destination :[/]\n\n";
            for (int i = 0; i < etages.Count; i++)
            {
                bool visite = joueur.EtageVisite.Contains(i);
                string texte = (visite) ? etages[i].Nom : "";

                if (i == selection)
                    contenu += $"[yellow]▶ {i + 1}. {texte}[/]\n";
                else
                    contenu += $"{i + 1}. {texte}\n";
            }
            contenu += "Esc : Annuler";

            AffichageInteraction.MessageInteraction = contenu;
            Jeux.MiseAJourLayout(layout, ctx, joueur, chrono, jeux);
            var touche = Console.ReadKey(true).Key;
            if (touche == ConsoleKey.UpArrow && selection > 0) selection--;
            else if (touche == ConsoleKey.DownArrow && selection < etages.Count - 1) selection++;
            else if (touche == ConsoleKey.Enter) return selection;
            else if (touche == ConsoleKey.Escape) return -1;
        }
    }

}