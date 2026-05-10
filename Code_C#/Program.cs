public class Program
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
}