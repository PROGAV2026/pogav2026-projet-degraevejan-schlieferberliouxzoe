public class Module
{
    public List<List<int>> MatriceModule { get; set; }
    public Module()
    {
        MatriceModule = new List<List<int>> { };

        for (int i = 0; i < 10; i++)
        {
            List<int> nouvelleLigne = new List<int> { };
            MatriceModule.Add(nouvelleLigne);
            for (int j = 0; j < 10; j++)
            {
                nouvelleLigne.Add(0);
            }
        }
    }

}
