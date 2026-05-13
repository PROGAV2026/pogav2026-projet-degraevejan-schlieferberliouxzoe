public  class Etage
{
    //public int Numero{get;set;}
    public string Nom{get;set;} = "Etage";
    public (string,int) ID{get;set;} = ("Etage", 0);
    public List<Module> ListeModulePotentiels{get;set;} = new List<Module>{};
    public List<Module> ListeModules{get;set;} =  new List<Module>{};
    public List<List<int>> MatriceEtage{get;set;} = new List<List<int>>{};
    public Random random = new Random();
    

    public Etage()
    {
        ModuleTeleportationDepart TpDepart = new ModuleTeleportationDepart();
        ModuleTeleportationArrivee TpArrivee = new ModuleTeleportationArrivee();
        ListeModules.Add(TpArrivee);
        ListeModules.Add(TpDepart);
        //this.Numero = Numero;
        

        
    }

    public void CompleterAvecModulesPotentiels(){
        
        while(ListeModules.Count()<5){
        int indiceAleatoire = random.Next(0,ListeModulePotentiels.Count());
        ListeModules.Add(ListeModulePotentiels[indiceAleatoire]);
            
        }
    }
    public void CompleterListeModuleEspace(){
        Espace espace = new Espace();
        while(ListeModules.Count() <5){
            ListeModules.Add(espace);
        }
    }
    public List<Module> CompleterAvecEspaces()
    {
        List<Module> ListeComplete = new List<Module>{};
        if (ListeModulePotentiels.Count() ==0){
            CompleterListeModuleEspace();
        }
        else{
            CompleterAvecModulesPotentiels();
        }
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
      ListeComplete.Add(ListeModules[2]);
      ListeComplete.Add(ListeModules[1]);
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
if (chiffre == 1) return "[white]| [/]";
if (chiffre == 2) return "[white]――[/]";
if (chiffre == 3) return "[red]██[/]";       // téléporteur arrivée
if (chiffre == 4) return "[blue]██[/]";      // téléporteur départ
if (chiffre == 5) return "[cyan]PC[/]";      // écran de controle
if (chiffre == 6) return "[yellow]Ch[/]";    // siège
if (chiffre == 7) return "[green]Pi[/]";     // poste de pilotage
if (chiffre == 8) return "[orange3]Co[/]";   // coffre
if (chiffre == 9) return "[green]Nu[/]";     // réacteur nucléaire
if (chiffre == 10) return "[grey]En[/]";     // IDK
if (chiffre == 11) return "[blue]Li[/]";     // lit
if (chiffre == 12) return "[blue]Do[/]";     // dort
if (chiffre == 13) return "[grey]Zz[/]";     // zzz
if (chiffre == 14) return "[yellow]JJ[/]";   // joueur
return "  ";
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