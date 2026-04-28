public class jeux
{
    public chrono chrono;
    private gestionScores gestionScores;
    public vaisseau vaisseau;
    public joueur joueur;
    public bool modeTest;
    public bool victoire; 

    public jeux()
    {
        this.chrono = new Chrono();
        this.gestionScores = new GestionScore();
        this.vaisseau = new Vaisseau();
        this.joueur = new Joueur();
        this.modeTest = false;
        this.victoire = false;
    }
    public void Test()
    {
        this.modeTest = true;
        // Metre truc qui correspond au mode test
    }
    public void LancerJeu()
    {
        // Metre truc qui correspond au lancement du jeu affichage debut 

    }
    public void FinJeu(victoire)
    {
        this.chrono.ArreterChrono();
        // Metre truc qui correspond a la fin du jeu
        console.WriteLine(victoire ? "Félicitations, vous avez gagné !" : "Dommage, vous avez perdu !");
    }
    public void BoucleJeu(){

        this.chrono.LancerChrono();
        while (!victoire && chrono.TempsRestant > 0)
        {
            
        }
    }

    public void VerifierVictoire()
    {
        if (victoire)//si le joueur a mis la clé aux bonnes endroits
        {
            FinJeu(true);
        }
    }
    public void EnregistrerScore()
    {
        // Metre truc qui correspond a l'enregistrement du score
    }
}