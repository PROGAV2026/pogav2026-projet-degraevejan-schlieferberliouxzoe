public class Program
{
    static void Main()
    {
        var test = new List<Module> { };
       
        Module testModule2 = new Module();
       
        test.Add(testModule2);
        Module testModule3 = new Module();
        Module testModule4 = new Module();
        test.Add(testModule3);
        test.Add(testModule4);
        var testEspace = new Espace();
        Graphisme test0 = new Graphisme(test);
        Console.Write(test0);
      
    }
}