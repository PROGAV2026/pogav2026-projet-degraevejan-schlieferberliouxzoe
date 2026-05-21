/// <summary>
/// CLASS QUI GERE : 
///                   Les lieux de vie avec les listes de modules potentiels et la matrice d'étage
/// </summary>
public class LieuDeVie : Etage
{
    public LieuDeVie() : base()
    {
        Nom = "Lieu de Vie";
        ModuleCouchage couchage = new ModuleCouchage();
        ModuleCoffre coffre = new ModuleCoffre();
        ListeModulePotentiels.Add(coffre);
        ListeModulePotentiels.Add(couchage);
        CreationMatriceEtage();

    }

}