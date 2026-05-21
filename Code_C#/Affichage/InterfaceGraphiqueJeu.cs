using System.IO.Compression;
using Spectre.Console;
/// <summary>
/// CLASS QUI GERE : 
///                   Appel des affichages 
/// </summary>
public static class InterfaceGraphiqueJeu
{
    //SQUELETTE DE L INTERFACE
    public static Layout InitialiserLayout()
    {
        return new Layout("INTERFACE")
        .SplitRows(
            new Layout("Header").Size(3),
            new Layout("Principal").SplitColumns(
                new Layout("AideEtLegende").Size(35)
                .SplitRows(
                    new Layout("Aide"),
                    new Layout("Legende")
                ),
                new Layout("MargeGauche"),
                new Layout("ZoneJeu").Size(70).SplitRows(
                    new Layout("MargeHaut"),
                    new Layout("EcranJeu").Size(30),
                    new Layout("MargeBas")
                ),
                new Layout("MargeDroite"),
                new Layout("InteractionEtCarte").Size(35).SplitRows(
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
        return new Panel(j.Joueur.Vaisseau.ListeEtages[j.Joueur.PositionEtage]
        .ToString())
        .NoBorder()
        .Expand();
    }
}
