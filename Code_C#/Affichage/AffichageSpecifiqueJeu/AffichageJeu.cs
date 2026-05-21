/// <summary>
/// CLASS QUI GERE : 
///                   Affichage du jeu central ou le joueur se déplace
/// </summary>
public static class AffichageJeu
{
    public static string ChiffreVersCaractere(int chiffre) //Change les chiffre de la matrice en caractère pour l'affichage
    {
        if (chiffre == 0) return "  ";
        if (chiffre == 1) return "[grey]██[/]";
        if (chiffre == 2) return "[grey]██[/]";
        if (chiffre == 3) return "[red]██[/]";       // téléporteur départ
        if (chiffre == 4) return "[blue]██[/]";      // téléporteur arrivé
        if (chiffre == 5) return "[white]██[/]";     //matelas lit occupé
        if (chiffre == 6) return "[white] ▯[/]";  // Tête de lit vide
        if (chiffre == 7) return "[white]██[/]";   // Corps du matelas
        if (chiffre == 8) return "[green] ○[/]";   // Tête de lit occupée
        if (chiffre == 9) return "[Aqua] █[/]";     // gauche ecran
        if (chiffre == 10) return "[Aqua]██[/]";     // reste ecran
        if (chiffre == 12) return "[grey]▲ [/]";     // pied ecran
        if (chiffre == 13) return "[red]¡ [/]";     // levier de controle
        if (chiffre == 14) return "[green]¬⚇[/]";   // joueur
        if (chiffre == 15) return "[bold Red3]()[/]";      //noyaux reacteur
        if (chiffre == 16) return "[Gray15]██[/]";     // mur du reacteur
        if (chiffre == 17) return "[Tan] ■[/]";        // caisse de materiel
        if (chiffre == 18) return "[Yellow4]██[/]";    //mur de reacteur jaune
        if (chiffre == 19) return "[LightSalmon3][[[/][Gold3_1]Ω[/]";    // coffre
        if (chiffre == 20) return "[LightSalmon3]]] [/]";    // coffre
        if (chiffre == 21) return "[red]¡ [/]";
        return "  ";
    }

}