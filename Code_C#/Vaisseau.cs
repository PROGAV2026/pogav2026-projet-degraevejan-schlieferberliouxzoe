 public class Vaisseau
{
        public string NomVaisseau = "ZINZIN";
        public List<Etage> ListeEtages{get;set;} = new List<Etage>{};
        public Vaisseau(bool modeTest)
    {
        
    }
    public void CacherLaCle()
    {
        
    }

    public void RemplirListeEtage(int nombreEtages)
    {
        if(nombreEtages <= 3)
        {
            Console.WriteLine("3 Etages minimum");
            RemplirListeEtage(3);
        }
        else
        {
            
        }

    }
}

