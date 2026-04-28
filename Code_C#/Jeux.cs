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
    public void LancerJeu()//Menu du lancement du jeu 

    {
        Console.WriteLine("============================================"+
                          "\n===========VAISSEAU DES ZINZINS=========== \n"+
                          "============================================\n"+
                            "But du jeu :\n"+
                            "Après l'apocalypse nucléaire, à la suite d'une guerre déclencher apres un attentat sur Donald Trump,"+
                            "Vous decidez de fuire en vaisseau. Ainsi vous voici à la recherche de la clé du vaisseau. \n"+
                            "10 MIN MAX pour trouver la clé ! \n\n"+
                            "Veuillez choisir un numéro !! Vite VITTEE votre vie est en jeu !! \n"+
                            
                          "1. Lancer le jeu\n"+
                          "2. Mode test\n"+
                          "3. Quitter\n");
        string choix = Console.ReadLine();
        switch (choix)
        {
            case "1":
                BoucleJeu();
                break;
            case "2":
                Test();
                break;
            case "3":
                Console.WriteLine("Et oui voici la clé du vaisseau pas besoin de faire 10 minutes de recherche :) !");
                break;
            default:
                Console.WriteLine("Choix invalide, veuillez réessayer.");
                LancerJeu();
                break;
        }
    }
//     public void FinJeu(bool victoire)
//     {
//         this.chrono.ArreterChrono();
//         // Metre truc qui correspond a la fin du jeu
//         console.WriteLine(victoire ? "Félicitations, vous avez gagné !" : "Dommage, vous avez perdu !");
//     }
    public void BoucleJeu(){

        this.joueur.DefinirJoueur();
        this.chrono.LancerChrono();
        while (!victoire && chrono.TempsRestant > 0)
        {
            
        }
    }

//     public void VerifierVictoire()
//     {
//         if (victoire)//si le joueur a mis la clé aux bonnes endroits
//         {
//             FinJeu(true);
//         }
//     }
//     public void EnregistrerScore()
//     {
//         // Metre truc qui correspond a l'enregistrement du score
//     }
}