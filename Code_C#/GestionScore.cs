public class GestionScore 
{
    public string CheminFichier { get; set; }

    public GestionScore(nom nom, Chrono temps)
    {
        this.nom = nom;
        this.temps = temps;
    }

    public void EnregistrementScore(string nom, Chrono temps)
    {
      // Code pour enregistrer le score dans un fichier
     }
    public voic lireScore(){
        // Code pour lire les scores depuis un fichier
    }
}