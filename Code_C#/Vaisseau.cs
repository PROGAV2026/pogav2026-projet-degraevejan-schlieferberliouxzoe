using System.Runtime.InteropServices;

public class Vaisseau
{
    public string NomVaisseau = "ZINZIN";
    public List<Etage> ListeEtages { get; set; } = new List<Etage> { };
    public List<string> ListeEtagesPotentiels { get; set; } = new List<string> { };
    public Random random = new Random();
    public int nombreLieuDevie = 0;
    public int nombrePilotage = 0;
    public int nombreMachine = 0;
    public int XClé;
    public int YClé;
    public Vaisseau(bool modeTest)
    {


        ListeEtagesPotentiels.Add("lieuDeVie");
        ListeEtagesPotentiels.Add("posteDePilotage");
        ListeEtagesPotentiels.Add("salleMachine");
        if (modeTest) RemplirListeEtage(3); else RemplirListeEtage(10);
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

                if (ListeEtages[EtageCaché].MatriceEtage[XClé][YClé] == 12 || ListeEtages[EtageCaché].MatriceEtage[XClé][YClé] == 11 || ListeEtages[EtageCaché].MatriceEtage[XClé][YClé] == 10 || ListeEtages[EtageCaché].MatriceEtage[XClé][YClé] == 8 || ListeEtages[EtageCaché].MatriceEtage[XClé][YClé] == 9 || ListeEtages[EtageCaché].MatriceEtage[XClé][YClé] == 12)
                {
                    CleCaché = true;
                    break;
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
    // public void AfficherDetailVaisseau()
    // {
    //     Console.WriteLine($"\n======= CONFIGURATION DÉTAILLÉE DU VAISSEAU {NomVaisseau} =======");

    //     for (int i = 0; i < ListeEtages.Count; i++)
    //     {
    //         Etage etageActuel = ListeEtages[i];

    //         // Affichage de l'étage en gras/majuscule pour bien le voir
    //         Console.WriteLine($"\n[ ÉTAGE {i + 1} : {etageActuel.Nom.ToUpper()} ]");

    //         // Vérification si la liste de modules n'est pas vide
    //         if (etageActuel.ListeModules != null && etageActuel.ListeModules.Count > 0)
    //         {
    //             foreach (var module in etageActuel.ListeModules)
    //             {
    //                 // On affiche le type du module (ex: ModuleCouchage, ModuleTeleportation, etc.)
    //                 // .GetType().Name permet de récupérer le nom de la classe de l'objet
    //                 Console.WriteLine($"   > Module : {module.GetType().Name}");
    //             }
    //         }
    //         else
    //         {
    //             Console.WriteLine("   (Aucun module installé dans cet étage)");
    //         }
    //     }

    //     Console.WriteLine("\n============================================================");
    // }
}

