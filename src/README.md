# Exemple
Ceci est un projet afin d'expérimenter avec [Stryker Mutator](https://stryker-mutator.io/docs/stryker-net/introduction/)

Un simple Web API avec 2 controlleurs. 

Les buts sont:
1. Voir la relation avec le code coverage & le mutation score;
1. Différent mutant implémenter et voir l'intéraction avec le rapport généré;

# Installation
Afin d'exécuter l'outil de test par mutation, l'outil de stryker doit être installé, ensuite rouler manuellement. Ceci va générer un rapport HTML par défaut.

1. Installer l'outil: `dotnet tool install -g dotnet-stryker`
1. Exécuter styrker: `dotnet stryker`

# Résultat
Voici un exemple de résultat donné après l'exécution

```
Killed:   12
Survived: 14
Timeout:   2

Your html report has been generated at:
...\reports\mutation-report.html
You can open it in your browser of choice.

Time Elapsed 00:00:53.1934961
The final mutation score is 35.00 %
```

Dans ce cas-ci, l'outil a généré 28 mutants dans le code qui est testé (le code non testé n'aura aucun mutant d'injecté). Seulement 35% des mutant qui ont été injectés ont été tué.

# Configuration
Un fichier de [configuration](https://stryker-mutator.io/docs/stryker-net/Configuration) est possible d'être créé: `stryker-config.json`

Voici un exemple de configuration:
```json
{
    "stryker-config":
    {
        "reporters": [
            "progress",
            "html"
        ]
    }
}
```

# Consultation du rapport
Lorsque stryker a terminé, un mutation score est généré qui est un pourcentage des mutant généré qui ont été éliminé.

Un rapport HTML peut également être généré qui permet de rapidement voir les mutants qui ont été injectés (morts, survivants, ignorés)