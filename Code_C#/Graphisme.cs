public class Graphisme
{
    Module[][] Grille{get;set;}

    public List<string> ConcatenerModuleHorizontal(Module module1, Module module2)
    {   
        List<string> SpriteFinal = new List<string>{};    
       for (int i = 0; i < 16; i++)
       {
        SpriteFinal.Add(module1.SpriteModule[0][i] + module2.SpriteModule[0][i]);
       }
    return SpriteFinal;
    }


    public List<string> LierGrille()
    {
        List<string> grilleLiee = new List<string>{};
        foreach (Module[] ligne in Grille)
        {
            grilleLiee.Add(ConcatenerModuleHorizontal(ConcatenerModuleHorizontal(ligne[0],ligne[1]),ligne[2])
        }
    }
}
