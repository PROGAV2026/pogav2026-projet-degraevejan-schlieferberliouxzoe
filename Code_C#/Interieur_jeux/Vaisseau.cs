using System.Runtime.InteropServices;
/// <summary>
/// CLASS QUI GERE : 
///                    Creation des etages + remplissage dans le vaisseau 
///                    Cacher la clé
/// </summary>
public class Vaisseau
{
    // public string NomVaisseau = "ZINZIN";
    public List<Etage> ListeEtages { get; set; } = new List<Etage> { };
    public List<string> ListeEtagesPotentiels { get; set; } = new List<string> { };
    public Random random = new Random();
    public int nombreLieuDevie = 0;
    public int nombrePilotage = 0;
    public int nombreMachine = 0;
    public int XClé;
    public int YClé;
    public List<int> Cachettes;
    public Vaisseau(bool modeTest)
    {
        ListeEtagesPotentiels.Add("lieuDeVie");
        ListeEtagesPotentiels.Add("posteDePilotage");
        ListeEtagesPotentiels.Add("salleMachine");
        if (modeTest) RemplirListeEtage(3); else RemplirListeEtage(10);
        Cachettes = new List<int>{6,7,17,20};
        CacherLaCle();
    }
    public void CacherLaCle()
    {
        bool CleCaché = false;
        int EtageCaché = random.Next(0, ListeEtages.Count());
       
        while (!CleCaché)
        {           
                XClé = random.Next(0, 30);
                YClé = random.Next(0, 30);
                int tentative = ListeEtages[EtageCaché].MatriceEtage[XClé][YClé];
                foreach (int element in Cachettes)
                {
                    if(tentative == element)
                {
                    CleCaché = true;
                    break;
                }
                }
            
        }
    }


    public Etage CreationEtage(string nometage)
    {
        switch (nometage)
        {
            case "lieuDeVie":
                LieuDeVie lieuDeVie = new LieuDeVie();
                nombreLieuDevie += 1;
                return lieuDeVie;
            case "posteDePilotage":
                PosteDePilotage posteDePilotage = new PosteDePilotage();
                nombrePilotage += 1;
                return posteDePilotage;
            case "salleMachine":
                SalleMachine salleMachine = new SalleMachine();
                nombreMachine += 1;
                return salleMachine;
            default:
                LieuDeVie lieuDeVie2 = new LieuDeVie();
                return lieuDeVie2;
        }

    }
    public void RemplirListeEtage(int nombreEtages)
    {
            while (ListeEtages.Count() < nombreEtages - 3)
            {
                int indiceAleatoire = random.Next(0, ListeEtagesPotentiels.Count());
                ListeEtages.Add(CreationEtage(ListeEtagesPotentiels[indiceAleatoire]));
            }
            foreach (string nometage in ListeEtagesPotentiels)
            {
                int indiceAleatoire2 = random.Next(0, ListeEtages.Count);
                ListeEtages.Insert(indiceAleatoire2, CreationEtage(nometage));
            }
    }
}   

