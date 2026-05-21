/// <summary>
/// CLASS QUI GERE : 
///                   La classe abstraite module qui contient la matrice de chaque module enfant et qui est utilisée pour la création de la matrice d'étage
///                   Chaque module enfant hérite de cette classe et remplit sa matrice dans son constructeur
/// </summary>
public abstract class Module
{
    public List<List<int>> MatriceModule { get; set; }
    public Module()
    {
        MatriceModule = new List<List<int>> { };

        for (int i = 0; i < 10; i++)
        {
            List<int> nouvelleLigne = new List<int> { };
            MatriceModule.Add(nouvelleLigne);
            for (int j = 0; j < 10; j++)
            {
                nouvelleLigne.Add(0);
            }
        }
    }

}
