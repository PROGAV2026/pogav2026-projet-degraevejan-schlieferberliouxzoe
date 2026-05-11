public class SalleMachine : Etage
{
    static int Numero{get;set;} 
    public SalleMachine(List<Module> ListeModule) : base(ListeModule)
    {
        Numero += 1;
        ID = (Nom, Numero);
        

    }
    public override string ToString()
    {
        return ID.Item1 + " " + ID.Item2;
    }
}