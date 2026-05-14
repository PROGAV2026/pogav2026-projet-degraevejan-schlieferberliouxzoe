public class ModuleCouchage : Module
{
    public ModuleCouchage()
    {
        Nom="Module Couchage";
        MatriceModule = new List<List<int>>
      {
    new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
    new List<int> { 0, 11, 0, 0, 0, 0, 0, 0, 11, 0 }, // Lits vides en haut
    new List<int> { 0, 0, 0, 0, 13, 0, 0, 0, 0, 0 }, // RONFLEMENTS (13)
    new List<int> { 0, 0, 0, 0, 12, 0, 0, 0, 0, 0 }, // LIT OCCUPÉ (12)
    new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
    new List<int> { 0, 11, 0, 0, 0, 0, 0, 0, 11, 0 }, // Lits vides au milieu
    new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
    new List<int> { 0, 11, 0, 0, 0, 0, 0, 0, 11, 0 }, // Lits vides en bas
    new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
    new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
};
    SpriteModule = this.ConstructionSprite();
    }
}