public class SalleMachine : Etage
{
    static int Numero{get;set;} 
    public SalleMachine()
    {
        Numero += 1;
        Nom = "Salle des machines" ;
        ID = (Nom, Numero);
        ModuleMoteur moteur = new ModuleMoteur();
        ListeModulePotentiels.Add(moteur);
        CreationMatriceEtage();

    }
}