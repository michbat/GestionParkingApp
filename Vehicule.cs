using System.Diagnostics.Contracts;

namespace _08_gestion_de_parking;

/// <summary>
/// Classe abstraite représentant un véhicule dans le système de gestion de parking.
/// Sert de base pour tous les types de véhicules (voitures, motos, camions, etc.).
/// </summary>
/// <param name="immatriculation">Numéro d'immatriculation unique du véhicule</param>
/// <param name="heureEntree">Heure d'entrée du véhicule dans le parking</param>
public abstract class Vehicule(string immatriculation, DateTime heureEntree)
{
    /// <summary>
    /// Numéro d'immatriculation du véhicule (plaque minéralogique).
    /// Utilisé comme identifiant unique pour le véhicule.
    /// </summary>
    public string Immatriculation { get; set; } = immatriculation;

    /// <summary>
    /// Heure d'entrée du véhicule dans le parking.
    /// Utilisée pour calculer la durée de stationnement.
    /// </summary>
    public DateTime HeureEntree { get; private set; } = heureEntree;

    /// <summary>
    /// Heure de sortie du véhicule du parking.
    /// Null tant que le véhicule est encore stationné.
    /// </summary>
    public DateTime? HeureSortie { get; private set; }

    /// <summary>
    /// Montant des frais de stationnement calculés pour le véhicule.
    /// Varie selon le type de véhicule et la durée de stationnement.
    /// </summary>
    public double Frais { get; private set; }
}
