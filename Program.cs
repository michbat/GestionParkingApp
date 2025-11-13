using System.Runtime.CompilerServices;
using _08_gestion_de_parking;

/// <summary>
/// Point d'entrée principal de l'application de gestion de parking.
/// Fournit une interface console interactive pour gérer les véhicules.
/// </summary>
class Program
{
    static void Main(string[] args)
    {
        // Configuration UTF-8 pour l'affichage du symbole monetaire €
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // Initialisation du parking et chargement des données existantes
        Parking parking = new();
        parking.ChargerVehicules();
        const int capaciteMax = 50; // TODO: Utiliser pour vérifier la capacité avant ajout

        bool continuer = true;

        // Boucle principale de l'interface utilisateur
        while (continuer)
        {
            Console.Clear();

            // Affichage du titre
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("==== Gestion de parking ====");
            Console.ResetColor();

            // Menu des options disponibles
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("1. Ajouter véhicule");
            Console.WriteLine("2. Afficher les véhicules");
            Console.WriteLine("3. Retirer un véhicule");
            Console.WriteLine("4. Consulter les places disponibles et les gains");
            Console.WriteLine("5. Quitter le menu");
            Console.ResetColor();

            Console.Write("\nChoisissez une option : ");
            string? choix = Console.ReadLine();

            // Traitement du choix utilisateur
            switch (choix)
            {
                case "1":
                    AjouterVehicule(parking);
                    break;
                case "2":
                    AfficherVehicules(parking);
                    break;
                case "3":
                    // TODO: Implémenter RetirerVehicule()
                    break;
                case "4":
                    // TODO: Implémenter ConsulterStatistiques()
                    break;
                case "5":
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("\nFermeture du programme");
                    Console.ResetColor();
                    continuer = false;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nOption invalide.");
                    Console.ResetColor();
                    break;
            }

            // Pause avant retour au menu (sauf si quitter)
            if (continuer)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("\nAppuyer sur n'importe quelle touche pour reafficher le menu...");
                Console.ResetColor();
                Console.ReadKey();
            }
        }

        // Sauvegarde finale avant fermeture de l'application
        parking.SauvegarderVehicules();

        // Pause avant fermeture complète
        Thread.Sleep(2000);
        Console.Clear();
    }

    /// <summary>
    /// Interface utilisateur pour ajouter un véhicule au parking.
    /// Collecte l'immatriculation et le type de véhicule via la console.
    /// </summary>
    /// <param name="parking">Instance du parking où ajouter le véhicule</param>
    static void AjouterVehicule(Parking parking)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        string? immatriculation;

        // Validation de l'immatriculation avec boucle de contrôle
        do
        {
            Console.Write("Immatriculation du véhicule: ");
            Console.ResetColor();
            immatriculation = Console.ReadLine();
            if (string.IsNullOrEmpty(immatriculation))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nLe numéro d'immatriculation ne doit pas être vide...");
                Console.ResetColor();
            }

        } while (string.IsNullOrEmpty(immatriculation));

        // Affichage du menu de sélection du type de véhicule
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("==== Type de véhicule ====");
        Console.WriteLine("1. Voiture");
        Console.WriteLine("2. Moto");
        Console.Write("\nChoisissez le type de véhicule (1 ou 2) : ");
        Console.ResetColor();
        string? choixType = Console.ReadLine();

        Vehicule vehicule;

        // Création du véhicule selon le type sélectionné
        if (choixType == "1")
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nUne voiture va être ajoutée...");
            Console.ResetColor();
            vehicule = new Voiture(immatriculation.Trim(), DateTime.Now);
        }
        else if (choixType == "2")
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nUne moto va être ajoutée...");
            Console.ResetColor();
            vehicule = new Moto(immatriculation.Trim(), DateTime.Now);
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Type de véhicule invalide. Opération annulée.\n");
            Console.ResetColor();
            return;
        }

        // Ajout du véhicule au parking
        parking.AjouterVehicule(vehicule);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nVéhicule ajouté avec succès !");
        Console.ResetColor();

    }

    /// <summary>
    /// Affiche la liste de tous les véhicules actuellement stationnés dans le parking.
    /// Utilise la propriété publique Vehicules pour accéder aux données.
    /// </summary>
    /// <param name="parking">Instance du parking dont afficher les véhicules</param>
    static void AfficherVehicules(Parking parking)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("==== Véhicules stationnés ====");
        Console.ResetColor();

        // Parcours et affichage de chaque véhicule stationné
        foreach (var v in parking.Vehicules)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Immatriculation : {v.Immatriculation} - Entrée : {v.HeureEntree}");
            Console.ResetColor();
        }

    }
}