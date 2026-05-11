using System.Runtime.InteropServices;
using Spectre.Console;
public class Jeux
{
    public Chrono chrono;
    // private GestionScore gestionScores;
    // public vaisseau vaisseau;
    public Joueur joueur;
    public bool modeTest;
    public bool victoire;

    public Jeux()
    {
        this.chrono = new Chrono();
        // this.gestionScores = new GestionScore();
        // this.vaisseau = new Vaisseau();
        this.joueur = new Joueur();
        this.modeTest = false;
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
                Test();
                break;
            case "3. Quitter":
                Console.WriteLine("Et oui voici la clé du vaisseau pas besoin de faire 10 minutes de recherche :) !");
                Console.ReadKey();
                break;
        }
    }
    //     public void FinJeu(bool victoire)
    //     {
    //         this.chrono.ArreterChrono();
    //         // Metre truc qui correspond a la fin du jeu
    //         console.WriteLine(victoire ? "Félicitations, vous avez gagné !" : "Dommage, vous avez perdu !");
    //     }
    
    public void BoucleJeu()
    {

        this.joueur.DefinirJoueur();
        this.chrono.LancerChrono();
        var layout = InterfaceGraphique.InitialiserLayout();
        layout["Aide"].Update(InterfaceGraphique.Aide());
        layout["Legende"].Update(InterfaceGraphique.Legende());

        AnsiConsole.Live(layout).Start(ctx =>
        {
            while (chrono.enCours && chrono.stopwatch.Elapsed.TotalSeconds < chrono.TempsTotal)
            {
                layout["Header"].Update(InterfaceGraphique.Header(joueur,chrono));
                // layout["EcranJeu"].Update(GenererAffichageJeu());
                layout["Footer"].Update(InterfaceGraphique.Footer("Vous explorez le vaisseau..."));
                ctx.Refresh();
                if (Console.KeyAvailable)
                {
                    var touche = Console.ReadKey(true).Key;
                    if(touche==ConsoleKey.Escape)break;
                    //GererDeplacement(touche);
                }
                Thread.Sleep(50);
            }
        });

    }
    public void GenererAffichageJeu()
    {
        
    }

    //     public void VerifierVictoire()
    //     {
    //         if (victoire)//si le joueur a mis la clé aux bonnes endroits
    //         {
    //             FinJeu(true);
    //         }
    //     }
    public void EnregistrerScore()
    {
        // Metre truc qui correspond a l'enregistrement du score
    }
}