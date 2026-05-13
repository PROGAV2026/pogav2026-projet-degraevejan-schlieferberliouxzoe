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
                        // new Layout("Jeu").SplitColumns(
                            // new Layout("Blanc").Size(30),
            new Layout("EcranJeu"),
                        

            new Layout("Interaction").Size(40)
        
    ));
    }

    //HEADER
    public static Panel Header(Joueur j, Chrono c)
    {
        string cle = j.ALaCle ? "[green]OUI[/]" : "[red]NON[/]";

        return new Panel(Align.Center(new Markup($"Clé: {cle} | Étage: [cyan]{j.PositionEtage}[/] | Temps: [yellow]{c.AffichageChrono()}[/]")))
             .Expand();
    }
    public static Panel Blanc()
    {
        return new Panel(new Text(" ")).NoBorder();
    }
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
    //Interaction
    public static Panel Intreaction(string message)
    {
        return new Panel(new Text(message, new Style(Color.Grey)).Centered())
               .RoundedBorder().Expand()
;
    }

    //JEU 
    public static Panel Jeu(Jeux j)
    {
        if (j?.joueur?.vaisseau?.ListeEtages == null || j.joueur.vaisseau.ListeEtages.Count == 0 || 
            j.joueur.PositionEtage < 0 || j.joueur.PositionEtage >= j.joueur.vaisseau.ListeEtages.Count)
        {
            return new Panel("Étage indisponible").NoBorder().Expand();
        }
        return new Panel(j.joueur.vaisseau.ListeEtages[j.joueur.PositionEtage].ToString()).NoBorder().Expand();
    }
}
