public class ModulePilotage : Module
{
    public bool EstValide{get;set;} 
    
    public ModulePilotage() : this(false) { }
    
    // Constructeur avec paramètre de validité
    public ModulePilotage(bool estValide)
    {
        this.EstValide = estValide;
        Nom = "Module de Pilotage";
        int chiffreLevier = EstValide ? 21 : 13;
        InitialiserMatrice();
    }
    public void InitialiserMatrice()
{
    int chiffreLevier = this.EstValide ? 21 : 13; 

    this.MatriceModule = new List<List<int>>
    {
        new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        new List<int> { 9, 10, 11, 9,  10, 11,  9, 10, 11, 0 },
        new List<int> { 0, 12, 0, 0, 12, 0, 0, 12 ,0, 0 }, 
        new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        new List<int> { 0, 0, 0, 0, chiffreLevier, 0, 0, 0, 0, 0 }, // Le levier s'adapte ici
        new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },   
        new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        new List<int> { 0, 17, 0, 0, 0, 0, 0, 0, 0, 0 },
        new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
    };
}
}
