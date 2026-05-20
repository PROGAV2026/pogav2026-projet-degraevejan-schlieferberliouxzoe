using System.IO.Compression;
using Spectre.Console;

public static class InterfaceGraphique
{
    //SQUELETTE DE L INTERFACE
    public static Layout InitialiserLayout()
{
    return new Layout("INTERFACE")
    .SplitRows(
        new Layout("Header").Size(3),
        new Layout("Principal").SplitColumns(
            new Layout("AideEtLegende").Size(40)
            .SplitRows(
                new Layout("Aide"),
                new Layout("Legende")
            ),
            new Layout("ZoneJeu").SplitColumns(
                new Layout("MargeGauche").Size(15),
                new Layout("ZoneJEU").SplitRows(
                    new Layout("MargeHaut").Size(5),
                    new Layout("EcranJeu"),
                    new Layout("MargeBas").Size(2)

                ),
                new Layout("MargeDroite").Size(15)
            ),
            new Layout("InteractionEtCarte").Size(40).SplitRows(
                new Layout("Interaction"),
                new Layout("Carte")
            )
        )
    );
}

    //HEADER
    public static Panel Header(Joueur j, Chrono c)
    {
        string cle = j.ALaCle ? "[green]OUI[/]" : "[red]NON[/]";
        string etage=" ";
        string EtageActuel="";
        if(j.NomEtageCourant=="Lieu de Vie"){
            etage = "[green]Lieu de Vie[/]";
            EtageActuel= $"[green]{j.PositionEtage+1}[/]";
        }
        else if (j.NomEtageCourant=="Poste de pilotage"){
        etage = "[blue]Poste de pilotage[/]";
            EtageActuel= $"[blue]{j.PositionEtage+1}[/]";
        }
        else if(j.NomEtageCourant=="Salle des machines"){
        etage = "[yellow]Salle des machines[/]";
            EtageActuel= $"[yellow]{j.PositionEtage+1}[/]";
        }


        return new Panel(Align.Center(new Markup($"Clé: {cle} | Étage: {EtageActuel} - [[{etage}]] | Temps: [yellow]{c.AffichageChrono()}[/]")))
             .Expand();
    }
    public static Panel Carte(Joueur joueur)
    {
        if (joueur.ALaCarte)
        {
            return new Panel(new Text("Carte non disponible")).Expand();

        }
        else
        {
            string contenu = "\n\n";
            for (int i = 0; i < joueur.vaisseau.ListeEtages.Count;i++)
            {
                 bool visite = joueur.EtageVisite.Contains(i);

                if (visite)
                    contenu += $"{i + 1}.[green] {joueur.vaisseau.ListeEtages[i].Nom}[/]\n";
                else
                    contenu += $"{i + 1}.[red] {joueur.vaisseau.ListeEtages[i].Nom}[/]\n";
                
            }

            contenu += joueur.vaisseau.EtageCleCache.Nom +' ' + joueur.vaisseau.XCle + ' ' + joueur.vaisseau.YCle;
    
            

  
        return new Panel(new Markup(contenu)).Expand().Header("Liste des étages");
    }}
    //AIDE 
    public static Panel Aide()
    {
        return new Panel(new Markup("\n\n[white]Z[/]: Haut\n[white]S[/]: Bas\n[white]Q[/]: Gauche\n[white]D[/]: Droite\n\n[green]A[/]: Action\n[red]ESC[/]: Quitter"))
               .Header("AIDE").BorderColor(Color.Grey).Expand();
    }
    //LEGENDE
    public static Panel Legende()
    {
        return new Panel(new Markup(
    "[red]██[/]: Arrivé du teleporteur\n" +
    "[blue]██[/]: Depart du téléporteur\n" +
    "[cyan]PC[/]: Ecran de controle\n" +
    "[yellow]Ch[/]: Siege du vaisseau\n" +
    "[green]Pi[/]: Poste de pilotage\n" +
    "[orange3]Co[/]: Coffre\n" +
    "[green]Nu[/]: REACTEUR NUCLEAIRE\n" +
    "[grey]En[/]: IDK\n" +
    "[blue]Li[/]: Tu veux faire un gros dodo\n" +
    "[blue]Do[/][grey]Zz[/]: LE DERANGE PAS\n" +
    "[yellow]@@[/]: VOUS"
))
.Header("LEGENDE").BorderColor(Color.Grey).Expand();

    }

    //INTERACTION -
    public static Panel Interaction()
    {
        return new Panel(new Markup(AffichageInteraction.MessageInteraction))
               .Header(AffichageInteraction.NomInteraction)
               .RoundedBorder()
               .Expand();
    }

    //JEU     
    public static Panel Jeu(Jeux j)
    {
        return new Panel(j.joueur.vaisseau.ListeEtages[j.joueur.PositionEtage].ToString()).NoBorder().Expand();
    }
}
