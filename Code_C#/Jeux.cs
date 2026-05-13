using Spectre.Console;
public class Jeux
{
    public Chrono chrono;
    public Joueur joueur;
    public bool modeTest;
    public bool victoire;
    public GestionScore gestion;

    public Vaisseau vaisseau;


    public Jeux()
    {
        this.chrono = new Chrono();
        this.gestion = new GestionScore();
        this.modeTest = false;
        this.joueur = new Joueur(modeTest);
        this.vaisseau = this.joueur.vaisseau;
        this.joueur.InitialiserPosition();
        this.victoire = false;
    
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
                modeTest=true;
                joueur.vaisseau = new Vaisseau(modeTest);
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
        Console.WriteLine(victoire ? "Félicitations, vous avez gagné !" : "Dommage, vous avez perdu !");
        if(victoire)
        this.chrono.ArreterChrono() ;
        this.gestion.EnregistrementScore(joueur.Nom, this.chrono);
        
        this.gestion.AfficherClassement();

       
        
    }
    public void VerifierVictoire()
    {
        if (joueur.ALaCle) 
        {
           victoire=true;
        }
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
        // AnsiConsole.Write(layout);
        // layout["Blanc"].Update(InterfaceGraphique.Blanc());

    AnsiConsole.Live(layout)
    .AutoClear(false)
    .Start(ctx =>
        {
            while (chrono.enCours && chrono.stopwatch.Elapsed.TotalSeconds < chrono.TempsTotal && !victoire)
            {
                if (Console.KeyAvailable) 
            {
                var touche = Console.ReadKey(true).Key;
                joueur.DeplacementDansModule(touche);
            }


                layout["Header"].Update(InterfaceGraphique.Header(joueur, chrono));
                layout["EcranJeu"].Update(InterfaceGraphique.Jeu(this));
                layout["Interaction"].Update(InterfaceGraphique.Intreaction(joueur));
            
                if (Console.KeyAvailable)
                {
                    var touche = Console.ReadKey(true).Key;
                    joueur.DeplacementDansModule(touche);
                }
                VerifierVictoire();
                ctx.Refresh();
                Thread.Sleep(5);
            }
        });
        AnsiConsole.Clear();
    
        FinJeu(victoire);
    }
}

   