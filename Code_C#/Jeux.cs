using Spectre.Console;
public class Jeux
{
    public Chrono chrono;
    // private GestionScore gestionScores;
    // public vaisseau vaisseau;
    public Joueur joueur;
    public bool modeTest;
    public bool victoire;
    public GestionScore gestion;
    private LieuDeVie lieuDeVie;
    public Vaisseau vaisseau;


    public Jeux()
    {
        this.chrono = new Chrono();
        this.gestion = new GestionScore();
        this.vaisseau = new Vaisseau(true);
        this.joueur = new Joueur();
        this.joueur.vaisseau = this.vaisseau;
        this.modeTest = false;
        this.victoire = false;
        this.lieuDeVie = new LieuDeVie();
    }

    public void Test()
    {
        this.modeTest = true;
        // Metre truc qui correspond au mode test
    }


    public void LancerJeu() //Menu du lancement du jeu 

    {
        MenuPrincipal.AffichageMenuJeu();
        var selection = MenuPrincipal.AffichageMenuSelection();
        switch (selection)
        {
            case "1. Lancer le jeu":
                BoucleJeu();
                break;
            case "2. Mode test":
                BoucleJeu();
                break;
            case "3. Quitter":
                Console.WriteLine("Et oui voici la clé du vaisseau pas besoin de faire 10 minutes de recherche :) !");
                Console.ReadKey();
                break;
        }
    }
        public void FinJeu(bool victoire)
        {
            victoire = true;
            this.chrono.ArreterChrono();
            this.gestion.EnregistrementScore(joueur.Nom, this.chrono);
            // Metre truc qui correspond a la fin du jeu
            Console.WriteLine(victoire ? "Félicitations, vous avez gagné !" : "Dommage, vous avez perdu !");
        }

    public void BoucleJeu()
    {
        this.joueur.DefinirJoueur();
        this.chrono.LancerChrono();
        if (Console.WindowHeight < 35 || Console.WindowWidth < 80)
    {
        AnsiConsole.MarkupLine("[red]Agrandis la fenêtre du terminal avant de jouer ![/]");
        Console.ReadKey();
        return;
    }
        
        var layout = InterfaceGraphique.InitialiserLayout();
        layout["Aide"].Update(InterfaceGraphique.Aide());
        layout["Legende"].Update(InterfaceGraphique.Legende());
        layout["Header"].Update(InterfaceGraphique.Header(joueur, chrono));
        // AnsiConsole.Write(layout);
        layout["Interaction"].Update(InterfaceGraphique.Intreaction("Vous explorez le vaisseau..."));
        layout["EcranJeu"].Update(InterfaceGraphique.Jeu(this));
        // layout["Blanc"].Update(InterfaceGraphique.Blanc());

        AnsiConsole.Live(layout)
    .AutoClear(false)       
    .Start(ctx =>
        {
            while (chrono.enCours && chrono.stopwatch.Elapsed.TotalSeconds < chrono.TempsTotal && !victoire)
            {
                layout["Header"].Update(InterfaceGraphique.Header(joueur, chrono));
                layout["EcranJeu"].Update(InterfaceGraphique.Jeu(this));
                

                ctx.Refresh();
                Thread.Sleep(50);
            }
        });
    }
}    

    //     public void VerifierVictoire()
    //     {
    //         if (victoire)//si le joueur a mis la clé aux bonnes endroits
    //         {
    //             FinJeu(true);
    //         }
    //     }
