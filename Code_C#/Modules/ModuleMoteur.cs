public class ModuleMoteur : Module
{
    public ModuleMoteur()
    {
        Nom="Module Moteur";
        MatriceModule = new List<List<int>>
        {
    new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
    new List<int> { 0, 8, 0, 0, 0, 0, 0, 0, 8, 0 }, 
    new List<int> { 0, 0, 0, 0, 10, 0, 0, 0, 0, 0 },
    new List<int> { 0, 0, 0, 10, 9, 10, 0, 0, 0, 0 }, 
    new List<int> { 0, 0, 0, 0, 10, 0, 0, 0, 0, 0 },
    new List<int> { 0, 0, 0, 0, 0, 0, 0, 8, 0, 0 }, 
    new List<int> { 0, 0, 8, 8, 0, 0, 0, 0, 0, 0 }, 
    new List<int> { 0, 0, 0, 0, 0, 0, 0, 8, 0, 0 },
    new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
    new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
};
    SpriteModule = this.ConstructionSprite();
    }
}