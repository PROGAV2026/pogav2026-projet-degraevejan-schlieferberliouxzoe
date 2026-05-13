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


    public Jeux()
    {
        this.chrono = new Chrono();
        this.gestion = new GestionScore();
        // this.vaisseau = new Vaisseau();
        this.joueur = new Joueur();
        this.modeTest = false;
        this.victoire = false;
        this.lieuDeVie = new LieuDeVie();  // Initialiser ici
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
        
        var layout = InterfaceGraphique.InitialiserLayout();
        layout["Aide"].Update(InterfaceGraphique.Aide());
        layout["Legende"].Update(InterfaceGraphique.Legende());
        layout["Header"].Update(InterfaceGraphique.Header(joueur, chrono));
        layout["Interaction"].Update(InterfaceGraphique.Intreaction("Vous explorez le vaisseau..."));
        layout["EcranJeu"].Update(InterfaceGraphique.Jeu(lieuDeVie));

        AnsiConsole.Live(layout).AutoClear(true).Start(ctx =>
        {
            while (chrono.enCours && chrono.stopwatch.Elapsed.TotalSeconds < chrono.TempsTotal && !victoire)
            {
                layout["Header"].Update(InterfaceGraphique.Header(joueur, chrono));
                layout["EcranJeu"].Update(InterfaceGraphique.Jeu(lieuDeVie));
                ctx.Refresh();
                Thread.Sleep(100);
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
