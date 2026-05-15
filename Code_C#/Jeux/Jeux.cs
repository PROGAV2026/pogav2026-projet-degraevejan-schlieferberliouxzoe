using Spectre.Console;
/// <summary>
/// CLASS QUI GERE : 
///                    Structure du jeu avec lancement /boucle/ verification victoire et fin jeu
/// </summary>
public class Jeux
{
    public Chrono chrono;
    public Joueur joueur;
    public bool modeTest = false;
    public bool victoire;
    public GestionScore gestion;
    public Vaisseau vaisseau;
    public GestionInteraction Interaction;
    public bool quitter = false;


    public Jeux()
    {
        this.chrono = new Chrono();
        this.gestion = new GestionScore(this.modeTest);
        this.modeTest = false;
        this.joueur = new Joueur(modeTest);
        this.Interaction = new GestionInteraction(joueur);
        this.vaisseau = this.joueur.vaisseau;
        this.joueur.InitialiserPosition();
        this.victoire = false;
    }

    public void LancerJeu() //Menu du lancement du jeu 

    {
         while (Console.WindowHeight < 50 || Console.WindowWidth < 80)
        {
            AnsiConsole.MarkupLine("Mettez la fenetre en pleine écran en ouvrant un nouveau terminal avec : [green]Ctrl+ Shift + Alt + ù[/] puis [green]F11[/]!");
            Console.ReadKey();
        }
        MenuPrincipal.AffichageMenuJeu();
        var selection = MenuPrincipal.AffichageMenuSelection();
        switch (selection)
        {
            case "1. Lancer le jeu":

                BoucleJeu();
                break;
            case "2. Mode test":
                modeTest = true;
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
        if (quitter)
        {
            Console.WriteLine("N'hesite pas à revenir tu nous manques déjà ;)");
        }
        else
        {
            Console.WriteLine(victoire ? "Félicitations, vous avez gagné !" : "Dommage, vous avez perdu !");
            if (victoire)
            {
                this.chrono.ArreterChrono();
                this.gestion.EnregistrementScore(joueur.Nom, this.chrono);
            }
            this.gestion.AfficherClassement();
        }
    }
    public void VerifierVictoire()
    {
        if (joueur.ALaCle)
        {
            victoire = true;
        }
    }

    public void BoucleJeu()
    {
        this.gestion = new GestionScore(this.modeTest);
        this.joueur.vaisseau = new Vaisseau(this.modeTest);
        this.vaisseau = this.joueur.vaisseau;

       bool joueurPret= CreationJoueur.DefinirJoueur(joueur);
       if (!joueurPret){
            LancerJeu();
            return;
        };
        this.chrono.LancerChrono();
        var layout = InterfaceGraphique.InitialiserLayout();
        layout["Aide"].Update(InterfaceGraphique.Aide());
        layout["Legende"].Update(InterfaceGraphique.Legende());
        layout["MargeGauche"].Update(new Panel("").NoBorder());
        layout["MargeDroite"].Update(new Panel("").NoBorder());
        layout["MargeHaut"].Update(new Panel("").NoBorder());
        layout["MargeBas"].Update(new Panel("").NoBorder());

        AnsiConsole.Live(layout)
        .AutoClear(false)
        .Start(ctx =>
            {
                while (chrono.enCours && chrono.stopwatch.Elapsed.TotalSeconds < chrono.TempsTotal && !victoire)
                {
                    layout["Header"].Update(InterfaceGraphique.Header(joueur, chrono));
                    layout["EcranJeu"].Update(InterfaceGraphique.Jeu(this));
                    layout["Carte"].Update(InterfaceGraphique.Carte(joueur));


                    int elementProche = Interaction.VerifierInteractionJeu(joueur);

                    AffichageInteraction.AfficherElementsInteractifs(elementProche);
                    layout["Interaction"].Update(InterfaceGraphique.Interaction());

                    if (Console.KeyAvailable)
                    {
                        var touche = Console.ReadKey(true).Key;
                        if (touche == ConsoleKey.Escape)
                        {
                            victoire = false;
                            chrono.enCours = false;
                            quitter = true;
                            break;
                        }
                        else if (touche == ConsoleKey.A)
                        {
                            string message = Interaction.InteractionAvecElement(elementProche, joueur, layout, ctx, this,chrono);
                            if (message != "")
                            {
                                AffichageInteraction.MessageInteraction = message;
                                layout["Interaction"].Update(InterfaceGraphique.Interaction());
                                layout["Header"].Update(InterfaceGraphique.Header(joueur, chrono));
                                layout["EcranJeu"].Update(InterfaceGraphique.Jeu(this));
                                ctx.Refresh();
                                Thread.Sleep(1000); 
                            }
                        }
                        ;
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

