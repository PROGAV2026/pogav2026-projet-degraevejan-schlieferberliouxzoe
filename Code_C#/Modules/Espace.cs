public class Espace : Module
{
    public Espace()
{
    Nom = "Espace";
    // On initialise la liste ET on ajoute la première sous-liste (index 0)
    this.RemplirTotalement(-1);
    SpriteModule = ConstructionSprite();
    
} 
}


