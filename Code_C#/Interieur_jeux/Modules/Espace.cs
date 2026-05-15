public class Espace : Module
{
    public Espace()
{
    Nom = "Espace";
    // On initialise la liste ET on ajoute la première sous-liste (index 0)
    this.RemplirTotalement(0);
    

    
} 
public void CoinHautGauche()
    {
    MurHorizontal(9);
    MurVertical(9);
    }
    public void CoinHautDroite()
    {
    MurHorizontal(9);
    MurVertical(0);
    }
    public void CoinBasGauche()
    {
    MurHorizontal(0);
    MurVertical(9);
    }
    public void CoinBasDroite()
    {
    MurHorizontal(0);
    MurVertical(0);
    }

}


