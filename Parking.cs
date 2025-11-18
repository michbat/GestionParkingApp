namespace _08_gestion_de_parking;

/// <summary>
/// Gère les opérations d'un parking, incluant l'ajout de véhicules et la persistance des données.
/// Maintient une liste des véhicules stationnés et sauvegarde automatiquement les informations dans un fichier CSV.
/// </summary>
public class Parking
{
    /// <summary>
    /// Capacité maximale du parking en nombre de véhicules.
    /// </summary>
    private const int CAPACITE_MAX = 50;
    /// <summary>
    /// Liste des véhicules actuellement stationnés dans le parking.
    /// Utilise readonly pour empêcher la réassignation de la collection.
    /// </summary>
    private readonly List<Vehicule> vehicules = [];

    /// <summary>
    /// Propriété en lecture seule exposant la collection des véhicules stationnés.
    /// Permet l'accès externe sans modification directe de la collection privée.
    /// </summary>
    public List<Vehicule> Vehicules => vehicules;
    // public List<Vehicule> Vehicules {
    //     get { return vehicules; }
    // }


    /// <summary>
    /// Nom du fichier CSV utilisé pour la persistance des données de stationnement.
    /// </summary>
    private const string FichierCSV = "parking.csv";

    /// <summary>
    /// Propriété en lecture seule indiquant si le parking a atteint sa capacité maximale.
    /// </summary>
    /// <returns>True si le parking est plein, False sinon</returns>
    public bool EstPlein => vehicules.Count >= CAPACITE_MAX;

    /// <summary>
    /// Ajoute un véhicule à la liste des véhicules stationnés et sauvegarde automatiquement.
    /// Vérifie d'abord si le parking a encore de la place disponible.
    /// </summary>
    /// <param name="vehicule">Le véhicule à ajouter au parking</param>
    /// <returns>True si l'ajout a réussi, False si le parking est plein</returns>
    public bool AjouterVehicule(Vehicule vehicule)
    {
        // Vérification de la capacité disponible avant ajout
        if (EstPlein)
        {
            return false; // Parking plein, ajout impossible
        }
        
        // Ajout du véhicule à la collection
        vehicules.Add(vehicule);
        
        // Sauvegarde immédiate pour persister les modifications
        SauvegarderVehicules();
        
        return true; // Ajout réussi
    }

    /// <summary>
    /// Sauvegarde la liste des véhicules dans le fichier CSV.
    /// Format: Immatriculation,HeureEntree,Frais
    /// </summary>
    public void SauvegarderVehicules()
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

    /// <summary>
    /// Retire un véhicule du parking après calcul des frais de stationnement.
    /// Enregistre l'heure de sortie, calcule les frais, sauvegarde puis supprime le véhicule de la liste.
    /// </summary>
    /// <param name="vehicule">Le véhicule à retirer du parking</param>
    public void RetirerVehicule(Vehicule vehicule)
    {
        // Enregistrement de la sortie et calcul des frais
        vehicule.Sortir();
        
        // Sauvegarde avant suppression pour conserver l'historique
        SauvegarderVehicules();
        
        // Retrait du véhicule de la collection
        vehicules.Remove(vehicule);
    }

}
