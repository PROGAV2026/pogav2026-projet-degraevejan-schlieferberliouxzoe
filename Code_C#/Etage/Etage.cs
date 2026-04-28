public abstract class Etage
{
    //public int Numero{get;set;}
    public string Nom{get;set;}
    public (string,int) ID{get;set;}
    public List<Module> ListeModules{get;set;}
    

    public Etage(string Nom)
    {
        this.Nom = Nom;
        //this.Numero = Numero;
        ListeModules = [];
    }
} 