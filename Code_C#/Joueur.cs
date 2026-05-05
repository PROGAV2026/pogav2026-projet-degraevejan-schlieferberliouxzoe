public class Joueur {
    public string Nom { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public string PositionEtage { get; set; }
    public bool ALaCle { get; set; }

    public Joueur()
    {
        ALaCle = false;
    } 
    public void DefinirJoueur(){
        Console.WriteLine("Quel est votre nom \n");
        Nom = Console.ReadLine();
       Console.WriteLine("Quel étage voulait vous être ? \n");
        PositionEtage = Console.ReadLine();
    }
}