using Spectre.Console;
/// <summary>
/// CLASS QUI GERE : 
///                    Structure du jeu avec lancement /boucle/ verification victoire et fin jeu
/// </summary>
public class Jeux
{
    public Chrono Chrono;
    public Joueur Joueur;
    public bool Victoire;
    public GestionScore Gestion;
    public GestionInteraction Interaction;
    public bool Quitter = false;
    public bool ModeTest = false;

    public Jeux()
    {
        this.Chrono = new Chrono();
        this.Joueur = new Joueur(this.ModeTest);
        this.Gestion = new GestionScore(this.ModeTest);
        this.Interaction = new GestionInteraction(this.Joueur);
        this.Joueur.InitialiserPosition();
        this.Victoire = false;
    }

    public void LancerJeu() //Menu du lancement du jeu 

    {
        while (Console.WindowHeight < 50 || Console.WindowWidth < 140)
        {
            AnsiConsole.MarkupLine("Mettez la fenetre en pleine écran en ouvrant un nouveau terminal avec : [green]Ctrl+ Shift + Alt + ù[/] puis [green]F11[/]!");
            AnsiConsole.MarkupLine($"Dimensions actuelles : [red]{Console.WindowWidth}x{Console.WindowHeight}[/] | Minimum requis : [green]140x50[/]");
            Console.ReadKey();
        }
        MenuPrincipal.AffichageMenuJeu();
        var selection = MenuPrincipal.AffichageMenuSelection();
        switch (selection)
        {
            case "1. Mode normal":
                BoucleJeu();
                break;
            case "2. Mode test":
                this.ModeTest = true;
                Joueur.ModeTest = true;
                BoucleJeu();
                break;
            case "3. Afficher classement":
                this.Gestion = new GestionScore(true);
                this.Gestion.AfficherClassement(true);
                this.Gestion = new GestionScore(false);
                this.Gestion.AfficherClassement(false);
                Console.WriteLine("Appuyez sur une touche pour revenir au menu principal.");
                Console.ReadKey();
                LancerJeu();
                break;
            case "4. Quitter":
                Console.WriteLine("Et oui voici la clé du vaisseau pas besoin de faire 10 minutes de recherche :) !");
                Console.ReadKey();
                break;
        }
    }

    public void BoucleJeu()
    {
        var layout = InterfaceGraphiqueJeu.InitialiserLayout();
        IntialisationInterface(layout);
        while (Chrono.EnCours && Chrono.Stopwatch.Elapsed.TotalSeconds < Chrono.TempsTotal && !Victoire)
        {
            Interaction.TeleportationEchouee = false;

            AnsiConsole.Live(layout)
            .AutoClear(false)
            .Start(ctx =>
            {
                while (Chrono.EnCours && Chrono.Stopwatch.Elapsed.TotalSeconds < Chrono.TempsTotal && !Victoire && !Interaction.TeleportationEchouee)
                {
                    int elementProche = Interaction.VerifierInteractionJeu(Joueur);
                    AffichageInteraction.AfficherElementsInteractifs(elementProche);
                    MiseAJourLayout(layout, ctx, Joueur, Chrono, this);
                    InteractionClavierJoueur(layout, ctx, elementProche);
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
            this.Gestion.AfficherClassement(this.ModeTest);
        }
    }
    public void VerifierVictoire()
    {
        if (Joueur.ALaCle && Joueur.ABienMisLaCle)
        {
            Victoire = true;
        }
    }


    public static void MiseAJourLayout(Layout layout, LiveDisplayContext ctx, Joueur joueur, Chrono chrono, Jeux jeux)
    {
        layout["Interaction"].Update(InterfaceGraphiqueJeu.Interaction());
        layout["Header"].Update(InterfaceGraphiqueJeu.Header(joueur, chrono));
        layout["EcranJeu"].Update(InterfaceGraphiqueJeu.Jeu(jeux));
        layout["Carte"].Update(InterfaceGraphiqueJeu.Carte(joueur));
        ctx.Refresh();

    }
    public void InteractionClavierJoueur(Layout layout, LiveDisplayContext ctx, int elementProche)
    {
        if (Console.KeyAvailable)
        {
            var touche = Console.ReadKey(true).Key;
            if (touche == ConsoleKey.Escape)
            {
                Victoire = false;
                Chrono.EnCours = false;
                Quitter = true;
                return;
            }
            else if (touche == ConsoleKey.A)
            {
                string message = Interaction.InteractionAvecElement(elementProche, Joueur, layout, ctx, this, Chrono);
                if (Interaction.TeleportationEchouee)// Permet d 'afficher l'erreur de téléportation
                {
                    return;
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
    }

    public void IntialisationInterface(Layout layout)
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
        layout["Aide"].Update(InterfaceGraphiqueJeu.Aide());
        layout["Legende"].Update(InterfaceGraphiqueJeu.Legende());
        layout["MargeGauche"].Update(new Panel("").NoBorder());
        layout["MargeDroite"].Update(new Panel("").NoBorder());
        layout["MargeHaut"].Update(new Panel("").NoBorder());
        layout["MargeBas"].Update(new Panel("").NoBorder());

    }
}

