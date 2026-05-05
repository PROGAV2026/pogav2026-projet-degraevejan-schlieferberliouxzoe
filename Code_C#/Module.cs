public   class Module
{
    public string Nom{get;set;}
    public int Numero{get;set;}
    protected bool ClePresente{get;set;}
    public (string,int) ID{get;set;}
    public List<List<string>> SpriteModule{get;set;} //on fait une liste pour avoir les différentes versions d'un même sprite, qui contient une liste qui contient chaque ligne du sprite


    public Module()
    {
        SpriteModule = new List<List<string>>{};
        List<string> v1 = new List<string>();
        SpriteModule.Add(v1);
        for (int i = 0; i <=15;i++){
            
        SpriteModule[0].Add(".  .  .  .  .  .  .  .  .  .  .  .  .  .  .  .  ");
    }
    }

    public override string ToString()
    {
        return string.Concat(SpriteModule[0]);
    }
}
