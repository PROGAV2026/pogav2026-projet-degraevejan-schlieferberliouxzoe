public class Graphisme
{
    List<List<Module>> Grille{get;set;}

    public Graphisme(List<Module> listeDesModules)
    {

       Grille = new List<List<Module>>{};
       for(int i = 0; i < 3;i++)
        {   
            List<Module> nouvelleLigne = new List<Module>{};
            Grille.Add(nouvelleLigne);
            for (int j = 0; j < 3; j++)
        {
            nouvelleLigne.Add(new Espace()); 
        }
        }
        if(listeDesModules.Count > 0)
        {
            Grille[0][1] = listeDesModules[0];
        }
        if(listeDesModules.Count > 1) Grille[1][0] =  listeDesModules[1];
        if(listeDesModules.Count > 2) Grille[1][2] =  listeDesModules[2];
        if(listeDesModules.Count > 3) Grille[2][1] =  listeDesModules[3];
        
        
     
        
        

    }

    public List<string> ConcatenerModuleHorizontal(List<string> spriteModule1 ,List<string> spriteModule2 )
    {   
        List<string> SpriteFinal = new List<string>{};    
       for (int i = 0; i < 16; i++)
       {
        SpriteFinal.Add(spriteModule1[i] + spriteModule2[i]);
       }
    return SpriteFinal;
    }


    public override string ToString()
    {
      
        string grille = "";
        List<List<string>> grilleLiee = new List<List<string>>{};

        foreach (List<Module> ligne in Grille)
        {
            grilleLiee.Add(ConcatenerModuleHorizontal(ConcatenerModuleHorizontal(ligne[0].SpriteModule[0],ligne[1].SpriteModule[0]),ligne[2].SpriteModule[0]));
        
        }
        foreach(List<string> ligneListeString in grilleLiee)
        {
            for(int i = 0; i<ligneListeString.Count;i++)
            {
                ligneListeString[i] += "\n";
            }
            grille += string.Concat(ligneListeString);
        }
    return grille;
    }
    
}
