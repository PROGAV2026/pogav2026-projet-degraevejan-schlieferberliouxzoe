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
            5  => "[cyan]PC[/] Écran de controle",
            6  => "[yellow]Ch[/] Siège du vaisseau",
            7  => "[green]Pi[/] Poste de pilotage",
            8  => "[orange3]Co[/] Coffre",
            9  => "[green]Nu[/] Réacteur nucléaire",
            11 => "[blue]Li[/] Lit",
            12 => "[blue]Do[/] Dort — LE DERANGE PAS",
            _  => "[yellow]Élément inconnu[/]"
        };
       
        MessageInteraction = "\n[grey]Appuyez sur A pour interagir[/]";
        NomInteraction = contenu;
    }
    
}