/// <summary>
/// CLASS QUI GERE : 
///                   La matrice du module moteur
/// </summary>
public class ModuleMoteur : Module
{
    public ModuleMoteur()
    {
        MatriceModule = new List<List<int>>
        {
    new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
    new List<int> { 0, 17, 0, 0, 0, 0, 0, 0, 0, 0 },
    new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        new List<int> { 0, 0, 0, 16, 18, 16, 0, 0, 0, 0 },
        new List<int> { 0, 0, 0, 18, 15, 18, 0, 0, 17,0 },
        new List<int> { 0, 0, 0, 16, 18, 16, 0, 0, 0, 0 },
        new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
};

    }
}