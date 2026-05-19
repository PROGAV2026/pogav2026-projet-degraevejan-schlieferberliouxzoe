public  class Module
{
    public string Nom { get; set; } = "";
    public int Numero { get; set; }
    protected bool ClePresente { get; set; }
    public (string, int) ID { get; set; }
    public List<List<int>> MatriceModule { get; set; }
    public List<List<string>> SpriteModule { get; set; }
    public Random random = new Random();


    public Module()
    {

        MatriceModule = new List<List<int>> { };
        SpriteModule = new List<List<string>> { };

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
    
}
