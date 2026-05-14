public class GestionInteraction
{
    public int X { get; set; }
    public int Y { get; set; }

    public GestionInteraction(Joueur joueur)
    {
        X = joueur.X;
        Y = joueur.Y;
    }

    public int VerifierInteractionJeu(Joueur joueur)
    {
        int[] dx = { -1, 1, 0, 0 };
        int[] dy = { 0, 0, -1, 1 };
        for (int i = 0; i < 4; i++)
        {
            int newX = X + dx[i];
            int newY = Y + dy[i];
            if (newX >= 0 && newX <= 29 && newY >= 0 && newY < +29)
            {
                int NumeroElement = joueur.EtageCourant.MatriceEtage[newX][newY];
                if (NumeroElement != 0 && NumeroElement != -1 && NumeroElement != 2 && NumeroElement != 1 && NumeroElement != 14)
                {
                    return NumeroElement;

                }
            }

        }
        return 0;

    }
    // public void InteractionAvecElement(int NumeroElement){
    //     switch(NumeroElement){
    //         case 3: //Téléporteur arrivée
    //         case 4: 
    //         int etageCible = InterfaceGraphique.AfficherMenuTeleportation(vaisseau);
    //     }
    // }



}