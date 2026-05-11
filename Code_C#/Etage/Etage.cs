public  class Etage
{
    //public int Numero{get;set;}
    public string Nom{get;set;}
    public (string,int) ID{get;set;}
    public List<Module> ListeModules{get;set;}
    public List<List<int>> MatriceEtage{get;set;}
    

    public Etage(List<Module> ListeModules)
    {
        
        //this.Numero = Numero;
        this.ListeModules = ListeModules;
        CreationMatriceEtage();
    }

    public List<Module> CompleterAvecEspaces()
    {
        List<Module> ListeComplete = new List<Module>{};
        //Creation des coins
        Espace EspaceHautDroite = new Espace();
        EspaceHautDroite.CoinHautDroite();
        Espace EspaceHautGauche = new Espace();
        EspaceHautGauche.CoinHautGauche();
        Espace EspaceBasDroite = new Espace();
        EspaceBasDroite.CoinBasDroite();
        Espace EspaceBasGauche = new Espace();
        EspaceBasGauche.CoinBasGauche();

        //Insertion des coins
      ListeComplete.Add(EspaceHautGauche);
      ListeComplete.Add(ListeModules[0]);
      ListeComplete.Add(EspaceHautDroite);
      ListeComplete.Add(ListeModules[1]);
      ListeComplete.Add(ListeModules[2]);
      ListeComplete.Add(ListeModules[3]);
      ListeComplete.Add(EspaceBasGauche);
      ListeComplete.Add(ListeModules[4]);
      ListeComplete.Add(EspaceBasDroite);

      return ListeComplete;
       
    }
 public void CreationMatriceEtage()
{
    List<Module> ListeComplete = CompleterAvecEspaces();

    MatriceEtage = new List<List<int>>();
    for (int i = 0; i < 30; i++)
    {
        List<int> nouvelleLigne = new List<int>();
        for (int j = 0; j < 30; j++)
        {
            nouvelleLigne.Add(0); //Remplissage initial
        }
        MatriceEtage.Add(nouvelleLigne);
    }

    
    for (int m = 0; m < ListeComplete.Count; m++)
    {
        //position du M-ième module dans la grille d'affichage
        int modLigne = m / 3; 
        int modCol = m % 3;

        // Coordonnées d'ou le module doit être affiché
        int departY = modLigne * 10;
        int departX = modCol * 10;

        // Copie de la matrice du module
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                
                MatriceEtage[departY + i][departX + j] = ListeComplete[m].MatriceModule[i][j];
            }
        }
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
public void AfficherMatriceBrute()
{
    
    for (int i = 0; i < MatriceEtage.Count; i++)
    {
        for (int j = 0; j < MatriceEtage[i].Count; j++)
        {
            
            Console.Write(MatriceEtage[i][j].ToString().PadLeft(3));
        }
        Console.WriteLine();
    }
}

    public override string ToString()
    {
        string SpriteFinal = "";
        for (int i = 0; i < 30; i++)
        {
         for (int j = 0; j < 30; j++)
         {
            SpriteFinal += ChiffreVersCaractere(MatriceEtage[i][j]);
         }   
         SpriteFinal += '\n';
        }
        return SpriteFinal;
    }
    
} 