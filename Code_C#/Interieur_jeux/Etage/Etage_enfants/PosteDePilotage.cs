/// <summary>
/// CLASS QUI GERE : 
///                   Le poste de pilotage avec les listes de modules potentiels et la matrice d'étage
/// </summary>
public class PosteDePilotage : Etage
{
    public PosteDePilotage() : base()
    {
        Nom = "Poste de pilotage";
        ModulePilotage pilotage = new ModulePilotage();
        ModuleMoteur moteur = new ModuleMoteur();
        ListeModules.Add(pilotage);
        ListeModulePotentiels.Add(moteur);
        CreationMatriceEtage();

    }

}