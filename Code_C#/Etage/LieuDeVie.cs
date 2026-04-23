public class LieuDeVie : Etage
{
    static int Numero{get;set;} 
    public LieuDeVie() : base("Lieu De Vie")
    {
        Numero += 1;
        ID = (Nom, Numero);
        

    }
    public override string ToString()
    {
        return ID.Item1 + " " + ID.Item2;
    }
}