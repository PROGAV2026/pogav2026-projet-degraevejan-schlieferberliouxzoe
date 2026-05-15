public class LieuDeVie : Etage
{
    static int Numero{get;set;} 

    public LieuDeVie() : base()
    {
        
        Numero += 1;
        Nom = "Lieu de Vie";
        ID = (Nom, Numero);
        ModuleCouchage couchage = new ModuleCouchage();
        ModuleCoffre coffre = new ModuleCoffre();
        ListeModulePotentiels.Add(coffre);
        
        ListeModulePotentiels.Add(couchage);
        CreationMatriceEtage();

    }
    
}