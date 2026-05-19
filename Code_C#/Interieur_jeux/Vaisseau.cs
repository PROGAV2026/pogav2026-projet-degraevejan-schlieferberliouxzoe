using System.Runtime.InteropServices;
using Spectre.Console.Rendering;
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
    public int XCle;
    public int YCle;
    public Etage EtageCleCache { get; set; }
    public List<int> Cachettes;
    public Vaisseau(bool modeTest)
    {
        ListeEtagesPotentiels.Add("lieuDeVie");
        ListeEtagesPotentiels.Add("posteDePilotage");
        ListeEtagesPotentiels.Add("salleMachine");
        if (modeTest) RemplirListeEtage(3); else RemplirListeEtage(10);
        Cachettes = new List<int> {5, 6, 7,8, 17,19, 20 };
        CacherLaCle();
        AjoutModuleDePilotagessuffisants();
        MetUnModulePilotageValideAleatoire();
    }
    public void CacherLaCle()
    {
        bool CleCaché = false;
        int EtageCaché = random.Next(0, ListeEtages.Count());
        EtageCleCache = ListeEtages[EtageCaché];
        while (!CleCaché)
        {
            XCle = random.Next(0, 30);
            YCle = random.Next(0, 30);
            int tentative = ListeEtages[EtageCaché].MatriceEtage[XCle][YCle];
            foreach (int element in Cachettes)
            {
                if (tentative == element)
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

    public void AjoutModuleDePilotagessuffisants()
    {   //Check si il y a au moins 2 modules de pilotages
        int nombreDeModulesPilotage = 0;
        foreach (Etage etage in ListeEtages)
        {
            foreach (Module module in etage.ListeModules)
            {
                if (module is ModulePilotage) nombreDeModulesPilotage++;
            }

        }
        int manquant = 2-nombreDeModulesPilotage; 
        while (manquant>0)
        {
            int indiceAleaEtage= random.Next(0, ListeEtages.Count);
            Etage etageAlea = ListeEtages[indiceAleaEtage];
            {
              if (etageAlea is PosteDePilotage)
        {
            int indiceAlea = random.Next(2, 5);
            
            if (!(etageAlea.ListeModules[indiceAlea] is ModulePilotage))
            {
                etageAlea.ListeModules[indiceAlea] = new ModulePilotage();
                etageAlea.CreationMatriceEtage();

                manquant--; 
            }
        }
            }
    }
    }

    public void MetUnModulePilotageValideAleatoire() //met un module de pilotage valide aleatoirement parmis les modules de pilotage
    {
        int indiceAleaEtage = random.Next(0,ListeEtages.Count());
        Etage etageAlea = ListeEtages[indiceAleaEtage];
        bool valideMis = false;
        bool tombeSurEtagePilo = false;
        while (!tombeSurEtagePilo)
        {
            indiceAleaEtage = random.Next(0,ListeEtages.Count());
            etageAlea = ListeEtages[indiceAleaEtage];
            tombeSurEtagePilo = etageAlea is PosteDePilotage;    
        }
        int indiceAleaModule = random.Next(0,etageAlea.ListeModules.Count());

        Module moduleAlea = etageAlea.ListeModules[indiceAleaModule];
        while (!valideMis)
        {
            indiceAleaModule = random.Next(0,etageAlea.ListeModules.Count());
            moduleAlea = etageAlea.ListeModules[indiceAleaModule];
            if(moduleAlea is ModulePilotage modulePilo)
            {
    
                modulePilo.EstValide = true;
                modulePilo.InitialiserMatrice();
                etageAlea.CreationMatriceEtage();
                valideMis = true;
            }


        }
    }
}


