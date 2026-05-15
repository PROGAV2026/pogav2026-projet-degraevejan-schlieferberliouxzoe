public static class AffichageInteraction
{
    public static string NomInteraction = "";
    public static string MessageInteraction="";

    public static void AfficherElementsInteractifs(int NumeroElement)
    {
        if (NumeroElement== 0)
        {
            NomInteraction = "❌ INTERACTION";
            return;
        }

        string contenu = NumeroElement switch 
       {
        
        3  => "[red]██[/] Téléporteur départ",
        4  => "[blue]██[/] Téléporteur arrivé",
        5  => "[green] ○[/][white]██[/] Lit occupé",
        6  => "[white] ▯[/][white]██[/] Lit vide",
        7 => "[white] ▯[/][white]██[/] Lit vide",
        8  => "[green] ○[/][white]██[/] Lit occupé",
        9  => "[blue] █[/][blue]██[/] Écran de pilotage", // Combiné 9 et 10
        10 => "[blue] █[/][blue]██[/] Écran de pilotage",
        12 => "[grey]▲ [/] Pied écran",
        13 => "[red]¡ [/] Levier de contrôle",
        14 => "[yellow]@@[/] Joueur (Vous)",
        15 => "[bold red]()[/] Noyau réacteur",
        16 => "[grey]██[/] Blindage réacteur",
        17 => "[grey] ■[/] Débris / Petite caisse",
        18 => "[yellow]██[/] Caisse de matériel",
        19 => "[orange3][[[/][yellow]Ω[/][orange3]]][/] Coffre Ancien", // Combiné 19 et 20
        20 => "[orange3][[[/][yellow]Ω[/][orange3]]][/] Coffre Ancien",
        _  => "[yellow]Élément inconnu[/]"
        };
       
        MessageInteraction = "\n[grey]Appuyez sur A pour interagir[/]";
        NomInteraction = contenu;
    }
    
}