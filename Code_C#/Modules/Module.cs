public  class Module
{
    public string Nom { get; set; }
    public int Numero { get; set; }
    protected bool ClePresente { get; set; }
    public (string, int) ID { get; set; }
    public List<List<int>> MatriceModule { get; set; }
    public List<List<string>> SpriteModule { get; set; } //on fait une liste pour avoir les différentes versions d'un même sprite, qui contient une liste qui contient chaque ligne du sprite


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
        SpriteModule = ConstructionSprite();
    }
    public override string ToString()
    {
        string affichage = "";
        foreach (List<string> ligne in SpriteModule)
        {
            affichage += string.Concat(ligne) +"\n";
        }

        return affichage;
    }
    public string Rotation(int nombreDeRota)
    {
        return this.ToString();
    }
    public void AfficheMatrice()
    {

        foreach (var ligne in MatriceModule)
        {
            Console.WriteLine(string.Join(" ", ligne));
        }
    }

    public string ChiffreVersCaractere(int chiffre) //Change les chiffre de la matrice en caractère pour l'affichage
    {
        if (chiffre == 0)
        {
            return ". ";
        }
        if (chiffre == -1)
        {
            return "/ ";
        }
        else
        {
            return "  ";
        }
    }
    public List<List<string>> ConstructionSprite()
    {
        List<List<string>> sprite = new List<List<string>> { };
        for (int i = 0; i < 10; i++)
        {
            List<string> ligne = new List<string> { };
            for (int j = 0; j < 10; j++)
            {
                ligne.Add(ChiffreVersCaractere(MatriceModule[i][j]));
            }
            sprite.Add(ligne);
        }
        return sprite;
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
    
}
