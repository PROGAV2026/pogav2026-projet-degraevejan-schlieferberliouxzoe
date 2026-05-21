/// <summary>
/// CLASS QUI GERE : 
///                   Les espaces vides dans le rendu final dans les quatres coin du vaisseau
/// </summary>
public class Espace : Module
{
    public Espace()
    {
        // On initialise la liste ET on ajoute la première sous-liste (index 0)
        this.RemplirTotalement(0);
    }

    public void RemplirTotalement(int chiffre)
    {
        for (int i = 0; i < 10; i++)
        {

            for (int j = 0; j < 10; j++)
            {
                MatriceModule[i][j] = chiffre;
            }

        }

    }

    public void MurVertical(int colonne)
    {
        for (int i = 0; i < 10; i++)
        {
            MatriceModule[i][colonne] = 1;
        }
    }
    public void MurHorizontal(int ligne)
    {
        for (int i = 0; i < 10; i++)
        {
            MatriceModule[ligne][i] = 2;
        }
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


