using Spectre.Console;

public class GestionInteraction
{
    public int X { get; set; }
    public int Y { get; set; }
    public bool teleportationEchouee = false;
    public int XInteraction{get;set;}
    public int YInteraction {get;set;}


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
    public void VerifierCle()
    {

    }
    public string InteractionAvecElement(int NumeroElement, Joueur joueur, Layout layout, LiveDisplayContext ctx, Jeux jeux, Chrono chrono)
    {
        int Xcle = joueur.vaisseau.XCle;
        int Ycle = joueur.vaisseau.YCle;
        bool conditionRecuperationCLe = (joueur.EtageCourant == joueur.vaisseau.EtageCleCache) &&(XInteraction == Xcle) && (YInteraction == Ycle);
        if (conditionRecuperationCLe)
        {
            joueur.ALaCle = true;
            return "Bravo ! La clé était cachée ici, maintenant ramenez la au bon poste de pilotage";
        }
        else {
        switch (NumeroElement)
        {
            case 3:
                int etageCible = MenuTeleportation(joueur.vaisseau, layout, ctx, jeux, joueur, chrono);
                bool resultat = joueur.DeplacementEtage(etageCible);
                if (!resultat)
                {
                    teleportationEchouee = true;
                }
                return "";

            case 4:
                return "Vous venez d'ici ! Allez explorer les alentours";
            case 13: 
            if (!joueur.ALaCle)
                {
                    return "Vous devez trouver la clé avant de venir ici";
                }
            else return "La clé ne va pas dans ce levier, dommage !";
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


            string contenu = "[cyan]Choisir destination :[/]\n\n";
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
            AffichageInteraction.NomInteraction = "TELEPORTEUR";
            layout["Interaction"].Update(InterfaceGraphiqueJeu.Interaction());
            layout["Header"].Update(InterfaceGraphiqueJeu.Header(joueur, chrono));
            layout["EcranJeu"].Update(InterfaceGraphiqueJeu.Jeu(jeux));
            ctx.Refresh();

            var touche = Console.ReadKey(true).Key;
            if (touche == ConsoleKey.UpArrow && selection > 0) selection--;
            else if (touche == ConsoleKey.DownArrow && selection < etages.Count - 1) selection++;
            else if (touche == ConsoleKey.Enter) return selection;
            else if (touche == ConsoleKey.Escape) return -1;
        }
    }

}