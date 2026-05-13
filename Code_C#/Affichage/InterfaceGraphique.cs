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
            new Layout("AideEtLegende").Size(40).SplitRows(
                new Layout("Aide"),
                new Layout("Legende")
            ),
            new Layout("Interaction"),
            new Layout("EcranJeu")
            
        )
    );
    }

    //HEADER
    public static Panel Header(Joueur j, Chrono c)
    {
        string cle = j.ALaCle ? "[green]OUI[/]" : "[red]NON[/]";

        return new Panel(Align.Center(new Markup($"Clé: {cle} | Étage: [cyan]{j.PositionEtage}[/] | Temps: [yellow]{c.AffichageChrono()}[/]")))
               .RoundedBorder();
    }

    //AIDE 
    public static Panel Aide()
    {
        return new Panel(new Markup("\n\n[white]Z[/]: Haut\n[white]S[/]: Bas\n[white]Q[/]: Gauche\n[white]D[/]: Droite\n\n[green]A[/]: Action\n[red]ESC[/]: Quitter"))
               .Header("AIDE").BorderColor(Color.Grey)
               .Expand();
    }
    //LEGENDE
    public static Panel Legende()
    {
        return new Panel(new Markup("🔴: Arrivé du teleporteur \n🔵: Depart du téléporteur \n🖥️:Ecran de controle \n💺: Siege du vaisseau \n🕹️:Poste de pilotage \n📦:Coffre\n☢️: REACTEUR NUCLEAIRE\n⚙️:IDK\n🛏️:Tu veux faire un gros dodo\n🛌💤:LE DERANGE PAS\n👨‍🚀: VOUS"))
        .Expand()
        .Header("LEGENDE").BorderColor(Color.Grey)
        ;
   
    }
    //FOOTER
    public static Panel Footer(string message)
    {
        return new Panel(new Text(message, new Style(Color.Grey)).Centered())
               .BorderColor(Color.Yellow).RoundedBorder()
               .Expand();
    }

    //JEU 
    public static Panel Jeu()
{   
    Jeux jeux = new Jeux();

    Console.WriteLine(jeux.joueur.vaisseau.ListeEtages[jeux.joueur.PositionEtage].ToString());
    Console.WriteLine("blabalabl");
    return new Panel(jeux.joueur.vaisseau.ListeEtages[jeux.joueur.PositionEtage].ToString()).Expand().NoBorder();
}
}
