public class ModuleCouchage : Module
{
    public ModuleCouchage()
    {
        Nom="Module Couchage";
        MatriceModule = new List<List<int>>
      {
   // Format 10x10 | Structure d'un lit : [Tête, Matelas, Matelas]// Rangée 1
        new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 
        new List<int> { 6, 7, 7, 0, 0, 0, 0, 6, 7, 7 }, 
        new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 
         // Rangée 2 (OCCUPÉ)
        new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 
        new List<int> { 8, 7, 7, 0, 0, 0, 0, 6, 7, 7 },
        new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },  // Rangée 3
        new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 
        new List<int> { 6, 7, 7, 0, 0, 0, 0, 6, 7, 7 },
        new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
};
    SpriteModule = this.ConstructionSprite();
    }
}