namespace _08_gestion_de_parking;

/// <summary>
/// Gère les opérations d'un parking, incluant l'ajout de véhicules et la persistance des données.
/// Maintient une liste des véhicules stationnés et sauvegarde automatiquement les informations dans un fichier CSV.
/// </summary>
public class Parking
{
    /// <summary>
    /// Liste des véhicules actuellement stationnés dans le parking.
    /// Utilise readonly pour empêcher la réassignation de la collection.
    /// </summary>
    private readonly List<Vehicule> vehicules = [];
    
    /// <summary>
    /// Nom du fichier CSV utilisé pour la persistance des données de stationnement.
    /// </summary>
    private const string FichierCSV = "parking.csv";

    /// <summary>
    /// Ajoute un véhicule à la liste des véhicules stationnés et sauvegarde automatiquement.
    /// </summary>
    /// <param name="vehicule">Le véhicule à ajouter au parking</param>
    public void AjouterVehicule(Vehicule vehicule)
    {
        vehicules.Add(vehicule);
        SauvegarderVehicules();
    }
    
    /// <summary>
    /// Sauvegarde la liste des véhicules dans le fichier CSV.
    /// Format: Immatriculation,HeureEntree,Frais
    /// </summary>
    private void SauvegarderVehicules()
    {
        using StreamWriter writer = new(FichierCSV);

        foreach (var v in vehicules)
        {
            writer.WriteLine($"{v.Immatriculation},{v.HeureEntree},{v.Frais}");
        }
    }

    /// <summary>
    /// Charge la liste des véhicules depuis le fichier CSV s'il existe.
    /// Les données sont parsées et recréées sous forme d'objets Voiture.
    /// </summary>
    public void ChargerVehicules()
    {
        if (File.Exists(FichierCSV))
        {
            using StreamReader reader = new(FichierCSV);

            string? ligne;

            while ((ligne = reader.ReadLine()) != null)
            {
                string[] data = ligne.Split(',');
                DateTime heureEntree = DateTime.Parse(data[1]);
                // Note: Actuellement ne charge que des voitures - à améliorer pour supporter tous types
                vehicules.Add(new Voiture(data[0], heureEntree));
            }
        }
    }

}
