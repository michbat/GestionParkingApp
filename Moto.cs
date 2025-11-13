namespace _08_gestion_de_parking;

/// <summary>
/// Représente une moto dans le système de gestion de parking.
/// Hérite de la classe abstraite Vehicule et implémente les comportements spécifiques aux motos.
/// Les motos bénéficient généralement de tarifs préférentiels et d'emplacements dédiés.
/// </summary>
/// <param name="immatriculation">Numéro d'immatriculation de la moto</param>
/// <param name="heureEntree">Heure d'entrée de la moto dans le parking</param>
public class Moto(string immatriculation, DateTime heureEntree) : Vehicule(immatriculation, heureEntree)
{
    // TODO: Ajouter des propriétés spécifiques aux motos (cylindrée, type de moto, etc.)
    // TODO: Implémenter le calcul du tarif réduit pour les motos
}
