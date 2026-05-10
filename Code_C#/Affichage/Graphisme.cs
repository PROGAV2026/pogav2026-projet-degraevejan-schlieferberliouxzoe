public class Graphisme
{
    List<List<Module>> Grille { get; set; }

    public Graphisme(List<Module> listeDesModules)
    {

        Grille = new List<List<Module>> { };
        for (int i = 0; i < 3; i++)
        {
            List<Module> nouvelleLigne = new List<Module> { };
            Grille.Add(nouvelleLigne);
            for (int j = 0; j < 3; j++)
            {
                nouvelleLigne.Add(new Espace());
            }
        }
        if (listeDesModules.Count > 0)
        {
            Grille[0][1] = listeDesModules[0];
        }
        if (listeDesModules.Count > 1) Grille[1][0] = listeDesModules[1];
        if (listeDesModules.Count > 2) Grille[1][2] = listeDesModules[2];
        if (listeDesModules.Count > 3) Grille[2][1] = listeDesModules[3];






    }

    public List<List<string>> ConcatenerModuleHorizontal(List<List<string>> spriteModule1, List<List<string>> spriteModule2)
    {
        List<List<string>> SpriteFinal = new List<List<string>> { };

        for (int i = 0; i < spriteModule1.Count; i++)
        {
            List<string> Ligne = new List<string> { };
            for (int j = 0; j < spriteModule1[i].Count; j++)
            {
                Ligne.Add(spriteModule1[i][j]);
            }
            for (int j = 0; j < spriteModule2[i].Count; j++)
            {
                Ligne.Add(spriteModule2[i][j]);
            }
            SpriteFinal.Add(Ligne);
        }
        return SpriteFinal;
    }


    public override string ToString()
    {

        string resultatFinal = "";

        foreach (List<Module> ligneModule in Grille)
        {
            List<List<string>> lignesDeString = ConcatenerModuleHorizontal(ConcatenerModuleHorizontal(ligneModule[0].SpriteModule, ligneModule[1].SpriteModule), ligneModule[2].SpriteModule);

            foreach (List<string> ligneDeCaracteres in lignesDeString)
            {
                string ligneAffichable = string.Concat(ligneDeCaracteres);
                resultatFinal += ligneAffichable + "\n";
            }
        }

        return resultatFinal;

    }

}
