/// <summary>
/// CLASS QUI GERE : 
///                   La salle des machines avec les listes de modules potentiels et la matrice d'étage
/// </summary>
public class SalleMachine : Etage
{
    public SalleMachine()
    {
        Nom = "Salle des machines";
        ModuleMoteur moteur = new ModuleMoteur();
        ListeModulePotentiels.Add(moteur);
        CreationMatriceEtage();

    }
}