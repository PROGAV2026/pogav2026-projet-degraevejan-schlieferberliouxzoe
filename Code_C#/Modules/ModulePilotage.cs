public class ModulePilotage : Module
{
    private bool EstValide{get;set;}
    public ModulePilotage(bool EstValide)
    {
        this.EstValide = EstValide;   
        Nom = "Module de Pilotage";
        MatriceModule = new List<List<int>>
        {

    new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
    new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
    new List<int> { 0, 0, 5, 5, 5, 5, 5, 0, 0, 0 }, // Large bande d'écrans
    new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
    new List<int> { 0, 0, 0, 0, 7, 0, 0, 0, 0, 0 }, // UN SEUL LEVIER (Centré)
    new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
    new List<int> { 0, 0, 0, 0, 6, 0, 0, 0, 0, 0 }, // UN SEUL FAUTEUIL (Centré)
    new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
    new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
    new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
};
    SpriteModule = this.ConstructionSprite();
    }
}
