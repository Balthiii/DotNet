# Prise de note Lundi 10 décembre

La commande dotnet new mvc -n mvc -o mvcTemplate crée un projet MVC vide appelé mvc dans le dossier mvcTemplate, prêt à être personnalisé et utilisé pour développer une application web basée sur l'architecture Model-View-Controller.

```
dotnet new mvc -n mvc -o mvcTemplate
```

La commande dotnet run est utilisée pour compiler et exécuter une application .NET à partir du code source, sans avoir besoin de construire manuellement les fichiers d'assemblage ou de spécifier les commandes de compilation et d'exécution séparées.

```
dotnet run
```

Un namespace (espace de noms) est un conteneur logique qui organise et regroupe des types (classes, interfaces, structures, énumérations, délégués, etc.) afin de les rendre plus faciles à gérer et à utiliser dans une application(faciliter l'import et l'export des classes). Il permet d'éviter les conflits de noms en donnant à chaque type un nom unique basé sur son espace de noms.

Les méthodes de controlleurs sont appelés des actions en dotnet.

## Prise de note mardi 11 décembre

Voici la syntaxe pour écrire un commentaire dans un fichier .cshtml

```
@* Ceci est un commentaire *@
```

Voici comment installer des dépendances tierces. Dirigez-vous sur le site nuget.org qui est la source principal lorsque l'on tente d'ajouter des fonctionnalités supplémentaires à un projet.

## Prise de note mercredi 12 décembre

Nous allons devoir installer 2 packages pour mettre en place un système d'authentification

Microsoft.AspNetCore.Identity.UI et Microsoft.AspNetCore.Identity.EntityFrameworkCore
