
public class ModuleTeleportationArrivee : Module
{
    
    public ModuleTeleportationArrivee()
    {
        Nom = "Module de Teleportation d'arrivée";
        MatriceModule = new List<List<int>>{
    new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
    new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
    new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
    new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
    new List<int> { 0, 0, 0, 0, 3, 3, 0, 0, 0, 0 }, 
    new List<int> { 0, 0, 0, 0, 3, 3, 0, 0, 0, 0 }, 
    new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
    new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
    new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
    new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
};
    SpriteModule = this.ConstructionSprite();
    }
}

public class ModuleTeleportationDepart : Module
{
    public ModuleTeleportationDepart()
    
    {
        Nom = "Module de Teleportation Départ";
        MatriceModule = new List<List<int>>{
    new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
    new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
    new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
    new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
    new List<int> { 0, 0, 0, 0, 4, 4, 0, 0, 0, 0 }, 
    new List<int> { 0, 0, 0, 0, 4, 4, 0, 0, 0, 0 }, 
    new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
    new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
    new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
    new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
};
    SpriteModule = this.ConstructionSprite();
    }
    
}