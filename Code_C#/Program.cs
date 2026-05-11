using System;
using System.Diagnostics; // Nécessaire pour Process

class Program
{
    static void Main()
    {
        var test = new List<Module> { };
       
        ModuleTeleportationDepart testModule2 = new ModuleTeleportationDepart();

        test.Add(testModule2);
        ModulePilotage testModule3 = new ModulePilotage(true);
        ModuleMoteur testModule4 = new ModuleMoteur();
        test.Add(testModule3);
        test.Add(testModule4);
        ModuleTeleportationArrivee testArrivee = new ModuleTeleportationArrivee();
        ModuleCouchage testModule1 = new ModuleCouchage();
        test.Add(testModule1);
        test.Add(testArrivee);
        var testEspace = new Espace();

        Graphisme test0 = new Graphisme(test);
        Console.Write(test0);
      
    }
    static void Main(string[] args)
    {
        // PLUS SIMPLE POUR VOIR LES RENDUS 
        if (args.Length == 0 || args[0] != "--fenetre-jeu")
        {
            string? currentPath = Process.GetCurrentProcess().MainModule?.FileName;

            if (currentPath != null)
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = currentPath,
                    Arguments = "--fenetre-jeu",
                    UseShellExecute = true,
                    CreateNoWindow = false
                };

                Process.Start(startInfo);
            }
            return; 
        }

        // --- TON CODE DE JEU ICI ---
        Console.Title = "Mon Jeu Isolé";
        Jeux jeux = new Jeux();
        jeux.LancerJeu();
       
    }
}