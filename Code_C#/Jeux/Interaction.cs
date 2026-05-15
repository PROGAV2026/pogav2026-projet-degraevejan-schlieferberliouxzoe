using Spectre.Console;

public class GestionInteraction
{
    public int X { get; set; }
    public int Y { get; set; }

    public GestionInteraction(Joueur joueur)
    {
        X = joueur.X;
        Y = joueur.Y;
    }

    public int VerifierInteractionJeu(Joueur joueur)
    {
        int[] dx = { -1, 1, 0, 0 };
        int[] dy = { 0, 0, -1, 1 };
        for (int i = 0; i < 4; i++)
        {
            int newX = joueur.X + dx[i];
            int newY = joueur.Y + dy[i];
            if (newX >= 0 && newX <= 29 && newY >= 0 && newY < +29)
            {
                int NumeroElement = joueur.EtageCourant.MatriceEtage[newX][newY];
                if (NumeroElement != 0 && NumeroElement != -1 && NumeroElement != 2 && NumeroElement != 1 && NumeroElement != 14)
                {
                    return NumeroElement;
                }
            }

        }
        return 0;

    }
     public void VerifierCle()
    {

    }
    public string InteractionAvecElement(int NumeroElement, Joueur joueur, Layout layout, LiveDisplayContext ctx, Jeux jeux, Chrono chrono)
    {
        switch (NumeroElement)
        {
            case 3:
                int etageCible = MenuTeleportation(joueur.vaisseau, layout, ctx, jeux,joueur,chrono);
                if (etageCible == -1)
                {
                    return "";
                }
                return joueur.DeplacementEtage(etageCible);
            case 4:
                return "Vous venez d'ici ! Allez explorer les alentours";
            case 7: 
            if (!joueur.ALaCle)
                {
                    return "Vous devez trouver la clé avant de venir ici";
                }
            return "";
            default:

                return"";
        }
    }
    public int MenuTeleportation(Vaisseau vaisseau, Layout layout, LiveDisplayContext ctx, Jeux jeux, Joueur joueur, Chrono chrono)
    {
        var etages = vaisseau.ListeEtages;
        int selection = 0;

        while (true)
        {
            string contenu = "[cyan]Choisir destination :[/]\n\n";
            for (int i = 0; i < etages.Count; i++)
            {
                if (i == selection)
                    contenu += $"[yellow]▶ {i + 1}. {etages[i].Nom}[/]\n";
                else
                    contenu += $" {i + 1}. {etages[i].Nom}\n";
            }
            contenu += "Esc : Annuler";


            AffichageInteraction.MessageInteraction = contenu;
            AffichageInteraction.NomInteraction = "TELEPORTEUR";
            layout["Interaction"].Update(InterfaceGraphique.Interaction());
            layout["Header"].Update(InterfaceGraphique.Header(joueur, chrono));
            layout["EcranJeu"].Update(InterfaceGraphique.Jeu(jeux));
            ctx.Refresh();

            var touche = Console.ReadKey(true).Key;
            if (touche == ConsoleKey.UpArrow && selection > 0) selection--;
            else if (touche == ConsoleKey.DownArrow && selection < etages.Count - 1) selection++;
            else if (touche == ConsoleKey.Enter) return selection;
            else if (touche == ConsoleKey.Escape) return -1;
        }
    }

}