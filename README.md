# Gestion de Parking

Application console en C# pour gérer un parking de 50 places.

## Fonctionnalités

- Ajout de véhicules (voitures et motos) avec enregistrement de l'heure d'entrée
- Sortie de véhicules avec calcul automatique des frais (10€ pour les voitures, 5€ pour les motos)
- Consultation du nombre de places disponibles et des gains du jour
- Persistance des données dans des fichiers CSV (parking.csv et gains.csv)

## Structure du projet

Le projet utilise les concepts de la programmation orientée objet :

- Classe abstraite `Vehicule` comme base
- Classes dérivées `Voiture` et `Moto`
- Classe `Parking` pour la gestion globale

## Utilisation

Compilez et exécutez le projet. Le menu propose 5 options :

1. Ajouter un véhicule
2. Afficher les véhicules présents
3. Retirer un véhicule
4. Consulter les statistiques
5. Quitter

Les données sont sauvegardées automatiquement et rechargées au démarrage.

## Prérequis

.NET 8.0 ou supérieur
