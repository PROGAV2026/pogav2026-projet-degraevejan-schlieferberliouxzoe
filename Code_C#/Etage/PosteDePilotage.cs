public class PosteDePilotage : Etage
{
    static int Numero{get;set;} 
    public PosteDePilotage() : base("Poste de pilotage")
    {
        Numero += 1;
        ID = (Nom, Numero);
        

    }
    public override string ToString()
    {
        return ID.Item1 + " " + ID.Item2;
    }
}