public class Espace : Module
{
    public Espace()
{
    Nom = "Espace";
    // On initialise la liste ET on ajoute la première sous-liste (index 0)
    SpriteModule = new List<List<string>> { new List<string>() }; 
    
    for (int i = 0; i <= 15; i++)
    {
        SpriteModule[0].Add("/  /  /  /  /  /  /  /  /  /  /  /  /  /  /  /  ");
    }
}

    }
