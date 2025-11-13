namespace _08_gestion_de_parking;

/// <summary>
/// Représente une voiture dans le système de gestion de parking.
/// Hérite de la classe abstraite Vehicule et implémente les comportements spécifiques aux voitures.
/// </summary>
/// <param name="immatriculation">Numéro d'immatriculation de la voiture</param>
/// <param name="heureEntree">Heure d'entrée de la voiture dans le parking</param>
public class Voiture(string immatriculation, DateTime heureEntree) : Vehicule(immatriculation, heureEntree)
{
    // TODO: Ajouter des propriétés spécifiques aux voitures (nombre de portes, type de carburant, etc.)
    // TODO: Implémenter le calcul du tarif de stationnement pour les voitures
}
