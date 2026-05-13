public class PosteDePilotage : Etage
{
    static int Numero{get;set;} 
    public PosteDePilotage() : base()
    {
        
        Numero += 1;
        Nom = "Poste de pilotage" ;
        ID = (Nom, Numero);
        ModulePilotage pilotage =  new ModulePilotage(true);
        ModuleMoteur moteur = new ModuleMoteur();
        ListeModulePotentiels.Add(pilotage);
        ListeModulePotentiels.Add(moteur);
        CreationMatriceEtage();

    }

}