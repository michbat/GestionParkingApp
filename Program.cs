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
            Console.WriteLine("==== Gestion de parking ====\n");
            Console.ResetColor();

            // Menu des options disponibles
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("1. Ajouter véhicule");
            Console.WriteLine("2. Afficher les véhicules");
            Console.WriteLine("3. Retirer un véhicule");
            Console.WriteLine("4. Consulter les places disponibles et les gains");
            Console.WriteLine("5. Quitter");
            Console.ResetColor();

            Console.Write("\nChoisissez une option : ");
            string? choix = Console.ReadLine();

            // Traitement du choix utilisateur
            switch (choix)
            {
                case "1":
                    // TODO: Implémenter AjouterVehicule()
                    break;
                case "2":
                    // TODO: Implémenter ListerVehicules()
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
                Console.WriteLine("Appuyer sur n'importe quelle touche pour reafficher le menu...");
                Console.ResetColor();
                Console.ReadKey();
            }
        }

        // Pause avant fermeture complète
        Thread.Sleep(2000);
        Console.Clear();
    }
}