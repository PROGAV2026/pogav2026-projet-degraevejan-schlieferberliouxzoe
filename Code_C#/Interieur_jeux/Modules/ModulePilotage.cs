public class ModulePilotage : Module
{
    public bool EstValide{get;set;}=true;
    
    public ModulePilotage() : this(true) { }
    
    // Constructeur avec paramètre de validité
    public ModulePilotage(bool estValide)
    {
        this.EstValide = estValide;
        Nom = "Module de Pilotage";
        MatriceModule = new List<List<int>>
        {

   new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
    new List<int> { 9, 10, 11, 9,  10, 11,  9, 10, 11, 0 }, // Écran (9)
        new List<int> { 0, 12, 0, 0, 12, 0, 0, 12 ,0, 0 }, 
        new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        new List<int> { 0, 0, 0, 0, 13, 0, 0, 0, 0, 0 },
          // Pied (10)
        new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },    // Levier (11)
        new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        new List<int> { 0, 17, 0, 0, 0, 0, 0, 0, 0, 0 },
        new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
};
   
    }
}
