using System.Diagnostics; // Nécessaire pour Process pour ouvrir une  nouvelle fenetre
class Program
{
    static void Main(string[] args)
    // static void Main(string[] args)

    {
        // PLUS SIMPLE POUR VOIR LES RENDUS 
        // if (args.Length == 0 || args[0] != "--fenetre-jeu")
        // {
        //     string? currentPath = Process.GetCurrentProcess().MainModule?.FileName;

        //     if (currentPath != null)
        //     {
        //         ProcessStartInfo startInfo = new ProcessStartInfo
        //         {
        //             FileName = currentPath,
        //             Arguments = "--fenetre-jeu",
        //             UseShellExecute = true,
        //             CreateNoWindow = false
        //         };

        //         Process.Start(startInfo);
        //     }
        //     return; 

        // --- TON CODE DE JEU ICI ---
        // Jeux jeux = new Jeux();
        // jeux.LancerJeu();
           // exemple
    LieuDeVie testLieuDeVie = new LieuDeVie();
    Console.WriteLine(testLieuDeVie);
    }
}
