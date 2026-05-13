public  class Module
{
    public string Nom { get; set; }
    public int Numero { get; set; }
    protected bool ClePresente { get; set; }
    public (string, int) ID { get; set; }
    public List<List<int>> MatriceModule { get; set; }
    public List<List<string>> SpriteModule { get; set; } 


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
    if (chiffre == 0) return "  ";
    if (chiffre == -1) return "  ";
    if (chiffre == 1) return "| ";
    if (chiffre == 2) return "――";
    if (chiffre == 3) return "🔴";
    if (chiffre == 4) return "🔵";
    if (chiffre == 5) return "🖥️ ";
    if (chiffre == 6) return "💺";
    if (chiffre == 7) return "🕹️ ";
    if (chiffre == 8) return "📦";
    if (chiffre == 9) return "☢️ ";
    if (chiffre == 10) return "⚙️ ";
    if (chiffre == 11) return "🛏️ "; 
    if (chiffre == 12) return "🛌"; 
    if (chiffre == 13) return "💤";
    if (chiffre == 14) return "👨‍🚀";
    return "";
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
        this.SpriteModule = ConstructionSprite();
    }
    public void Transpose()
    {
        
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
    
}
