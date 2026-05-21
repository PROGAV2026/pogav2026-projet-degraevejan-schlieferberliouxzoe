using Spectre.Console;
/// <summary>
/// CLASS QUI GERE : 
///                    Structure du jeu avec lancement /boucle/ verification victoire et fin jeu
/// </summary>
public class Jeux
{
    public Chrono Chrono;
    public Joueur Joueur;
    public bool ModeTest = false;
    public bool Victoire;
    public GestionScore Gestion;
    public GestionInteraction Interaction;
    public bool Quitter = false;//TODO VERIFIER SI C EST UTILE


    public Jeux()
    {
        this.Chrono = new Chrono();
        this.Gestion = new GestionScore(this.ModeTest);
        this.Joueur = new Joueur(ModeTest);
        this.Interaction = new GestionInteraction(Joueur);
        this.Joueur.InitialiserPosition();
        this.Victoire = false;
    }

    public void LancerJeu() //Menu du lancement du jeu 

    {
        //  while (Console.WindowHeight < 35 || Console.WindowWidth < 60)
        // {
        //     AnsiConsole.MarkupLine("Mettez la fenetre en pleine écran en ouvrant un nouveau terminal avec : [green]Ctrl+ Shift + Alt + ù[/] puis [green]F11[/]!");
        //     Console.ReadKey();
        // }
        MenuPrincipal.AffichageMenuJeu();
        var selection = MenuPrincipal.AffichageMenuSelection();
        switch (selection)
        {
            case "1. Lancer le jeu":

                BoucleJeu();
                break;
            case "2. Mode test":
                Joueur.ModeTest = true;
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
        if (Quitter)
        {
            Console.WriteLine("N'hesite pas à revenir tu nous manques déjà ;)");
        }
        else
        {
            Console.WriteLine(victoire ? "Félicitations, vous avez gagné !" : "Dommage, vous avez perdu !");
            if (victoire)
            {
                this.Chrono.ArreterChrono();
                this.Gestion.EnregistrementScore(Joueur.Nom, this.Chrono);
            }
            this.Gestion.AfficherClassement();
        }
    }
    public void VerifierVictoire()
    {
        if (Joueur.ALaCle && Joueur.ABienMisLaCle)
        {
            Victoire = true;
        }
    }

    public void BoucleJeu()
    {
        this.Gestion = new GestionScore(this.ModeTest);
        this.Joueur.Vaisseau = new Vaisseau(this.ModeTest);

        bool joueurPret = CreationJoueur.DefinirJoueur(Joueur);
        if (!joueurPret)
        {
            LancerJeu();
            return;
        }
        ;
        this.Chrono.LancerChrono();
        var layout = InterfaceGraphiqueJeu.InitialiserLayout();
        layout["Aide"].Update(InterfaceGraphiqueJeu.Aide());
        layout["Legende"].Update(InterfaceGraphiqueJeu.Legende());
        layout["MargeGauche"].Update(new Panel("").NoBorder());
        layout["MargeDroite"].Update(new Panel("").NoBorder());
        layout["MargeHaut"].Update(new Panel("").NoBorder());
        layout["MargeBas"].Update(new Panel("").NoBorder());


        while (Chrono.EnCours && Chrono.Stopwatch.Elapsed.TotalSeconds < Chrono.TempsTotal && !Victoire)
        {
            Interaction.TeleportationEchouee = false;

            AnsiConsole.Live(layout)
            .AutoClear(false)
            .Start(ctx =>
            {
                while (Chrono.EnCours && Chrono.Stopwatch.Elapsed.TotalSeconds < Chrono.TempsTotal && !Victoire)
                {
                    int elementProche = Interaction.VerifierInteractionJeu(Joueur);

                    AffichageInteraction.AfficherElementsInteractifs(elementProche);
                    MiseAJourLayout(layout, ctx, Joueur, Chrono, this);

                    if (Console.KeyAvailable)
                    {
                        var touche = Console.ReadKey(true).Key;
                        if (touche == ConsoleKey.Escape)
                        {
                            Victoire = false;
                            Chrono.EnCours = false;
                            Quitter = true;
                            break;
                        }
                        else if (touche == ConsoleKey.A)
                        {
                            string message = Interaction.InteractionAvecElement(elementProche, Joueur, layout, ctx, this, Chrono);
                            if (Interaction.TeleportationEchouee)// Permet d 'afficher l'erreur de téléportation
                            {
                                break;
                            }
                            if (message != "")
                            {
                                AffichageInteraction.MessageInteraction = message;
                                MiseAJourLayout(layout, ctx, Joueur, Chrono, this);
                                Thread.Sleep(1000);
                            }
                        }
                        ;
                        Joueur.DeplacementDansModule(touche);
                    }
                    VerifierVictoire();
                    ctx.Refresh();

                }
            });
            if (Interaction.TeleportationEchouee) // Affichage du message d'erreur 
            {
                AffichageInteraction.AfficherTeleportationEchouee();
            }
            else
            {
                break;

            }


        }
        AnsiConsole.Clear();

        FinJeu(Victoire);
    }
    public static void MiseAJourLayout(Layout layout, LiveDisplayContext ctx, Joueur joueur, Chrono chrono, Jeux jeux)
    {
        layout["Interaction"].Update(InterfaceGraphiqueJeu.Interaction());
        layout["Header"].Update(InterfaceGraphiqueJeu.Header(joueur, chrono));
        layout["EcranJeu"].Update(InterfaceGraphiqueJeu.Jeu(jeux));
        layout["Carte"].Update(InterfaceGraphiqueJeu.Carte(joueur));
        ctx.Refresh();

    }
    public static void IntialisationInterface()
    {

    }
}

