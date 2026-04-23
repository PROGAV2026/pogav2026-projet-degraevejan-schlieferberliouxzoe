public abstract class Module
{
    public string Nom{get;set;}
    public int Numero{get;set;}
    protected bool ClePresente{get;set;}
    public (string,int) ID{get;set;}
    public List<string> SpriteModule{get;set;}


    public Module()
    {
        
    }
}       