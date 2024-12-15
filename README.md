# Système de Gestion d'Événements

## Fonctionnalités

- Contrôle d'accès basé sur les rôles (Enseignant/Étudiant).
- Opérations CRUD pour les événements ainsi que les Enseignant et Étudiants (Créer, Lire, Modifier, Supprimer).
- Filtres d'événements par titre et date.
- Messages de confirmation lors des actions sur les événements.
- Design responsive

## Prérequis

Avant de pouvoir lancer le projet, vous devez avoir installé les éléments suivants :

1. **.NET SDK (Version 9.0.101 recommandé)**  
   Vous pouvez le télécharger depuis le site officiel de .NET :  
   [Télécharger .NET SDK](https://dotnet.microsoft.com/download).

2. **MariaDB** (ou un autre système de base de données compatible) :  
   [Télécharger WampServer](https://www.wampserver.com/).

## Installation

1. **Cloner le dépôt**  
   Clonez ce dépôt sur votre machine locale en utilisant Git :
   ```bash
   git clone git@github.com:Balthiii/dotNet.git
   ```
2. **Configurer la base de données**  
   Si vous utilisez MariaDB, vous devez configurer votre base de données et mettre à jour la chaîne de connexion dans le fichier appsettings.json. Par défaut, la chaîne de connexion est configurée pour se connecter à une base de données MariaDB.

Exemple de chaîne de connexion dans appsettings.json :

```
"ConnectionStrings":
    "DefaultConnection": "server=localhost;port=3307;database=RPIDEV;user=root;password=yourpassword;"
```

3. **Restaurer les packages NuGet**

Ouvrez un terminal dans le répertoire du projet et exécutez la commande suivante pour restaurer les dépendances du projet :

```
dotnet restore
```

4. **Appliquer les migrations de la base de données**

Exécutez les migrations pour configurer la base de données en utilisant la commande suivante :

```
dotnet ef database update
```

5. **Lancer l'application**

```
dotnet run

```
