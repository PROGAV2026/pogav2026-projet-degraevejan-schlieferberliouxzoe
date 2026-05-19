using System.IO.Compression;
using Spectre.Console;
/// <summary>
/// CLASS QUI GERE : 
///                   Appel des affichages 
/// </summary>
//TODO : METTRE LES BONNES DIMENSIONS POUR CENTRER LE JEU
public static class InterfaceGraphiqueJeu
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
        return new Panel(Align.Center(new Markup(AffichageHeader.AfficherHeader(j, c))))
             .Expand();
    }

    //PANEL CARTE 
    public static Panel Carte(Joueur joueur)
    {
        return new Panel(new Markup(AffichageCarte.AfficherCarte(joueur)))
        .Expand()
        .Header("CARTE")
        .BorderColor(Color.Grey);
    }

    //PANEL AIDE 
    public static Panel Aide()
    {
        return new Panel(new Markup(AffichageAide.AfficherAide()))
            .Header("AIDE")
            .BorderColor(Color.Grey)
            .Expand();
    }

    //PANEL LEGENDE
    public static Panel Legende()
    {
        return new Panel(new Markup(AffichageLegende.AfficherLegende()))
            .Header("LEGENDE")
            .BorderColor(Color.Grey)
            .Expand();
    }

    //PANEL INTERACTION 
    public static Panel Interaction()
    {
        return new Panel(new Markup(AffichageInteraction.MessageInteraction))
            .Header(AffichageInteraction.NomInteraction)
            .RoundedBorder()
            .Expand()
            .BorderColor(Color.Grey);
    }

    //PANEL JEU     
    public static Panel Jeu(Jeux j)
    {
        return new Panel(j.joueur.vaisseau.ListeEtages[j.joueur.PositionEtage]
        .ToString())
        .NoBorder()
        .Expand();
    }
}
