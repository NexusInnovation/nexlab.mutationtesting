# nexlab.mutationtesting
Exploration des tests par mutation

## Introduction
*nexlab.mutationtesting* est un projet d'exploration initié par les développeurs(ses) chez [Nexus Innovations](https://nexusinno.com/) pour analyser la pratique, les outils afin de d'appliquer celle-ci dans un contexte favorable.

### Qu'est-ce que les tests par mutation ?
En développement logiciel, la gestion de la qualité se concentre souvent à coder des tests automatisés dont le rôle est de s'assurer du bon fonctionnement d'un comportement dans un processus d'intégration en continue.

Pour mesurer la qualité, les tests automatisés permettent d'obtenir le % de tests réussis et aussi la couverture du code testé par les tests automatisés. Est-ce suffisant pour dire que l'application fonctionne vraiment ?

La réponse est non. L'une des raisons est que **100% des tests réussis et 100% de couverture du code par les tests ne veut pas dire que le code est testés et vérifiés entièrement**. On parle ici de l'efficacité des tests à trouver une anomalie.

C'est ainsi que les tests par mutation permettent d'obtenir une métrique additionnelle afin d'ajouter de la stabilité en simulant des anomalies dans le code testé (des mutants) et relancer les tests pour vérifier que chaque anomalie a fait échoué un ou plusieurs tests (nombre de mutants tués).

## Comment l'appliquer ?

Il existe plusieurs outils selon la technologie utilisés, cependant l'intégration dans un processus d'intégration en continue se résume à ceci:

```mermaid
%%{init: {'theme':'dark'}}%%
graph LR
    A[Construire] --> B[Tester]
    B --> C[Muter et construire]
    C --> D[Tester]
    D --> E[Publier le rapport des tests]

    style C fill:#117711,stroke:#333,stroke-width:2px,TextColor:red
    style D fill:#117711,stroke:#333,stroke-width:2px,nodeTextColor:black
```
Les étapes en vert sont ajoutés aux processus d'intégration en continue de sorte d'attraper des régressions tôt pendant le développement afin d'agir rapidement.

## En pratiques

Le context du projet à développer doit être favorable. En d'autres mots, la qualité doit être un attribut important pour la réussite du projet et soutenu par les intervenants.

La gestion de la qualité doit nécessairement passer par des tests automatisés afin d'appliquer des tests par mutation.

### Avantages

1. Offre un aperçu sur l'efficacité des tests à attraper des comportements indésirables
1. Prévient des erreurs de régression lorsqu'on bonifie les tests afin d'attraper des mutants ayant survécus
1. Réduit des allers-retours causés par des anomalies identifié lors de tests manuelles
1. Augmente la qualité des tests pour gagner en confiance sur la stabilité

### Inconvénients

1. Effort accrue pour le développement des tests automatisés
1. Ajout d'une responsabilité à analyser le rapport de tests par mutation
1. Coût d'exécution des tests par mutation ralentit l'intégration en continue
1. L'efficacité des tests par mutation dépend des possibilités qu'offre l'outil de mutation et ne peut pas simuler tous les types de modification

### Défis et risques

Adopter les tests par mutation ne doit pas être perçu comme une tâches en extra ou même exclus du développement d'une fonctionnalité. La culture de gestion de la qualité en pratique ne doit pas se restreindre à chasser des mutants et atteindre une couverture de test acceptable.

#### Attentes irréalistes

Viser une couverture de tests de 100% et 0 survivants parmi les mutants sur l'entièreté du code est plutôt une utopie. Techniquement l'entièrement du code possèdent différent niveau de testabilité et de pertinence à être testé. 

Du code qu'on appel parfois de plomberie dont la pertinence d'effectuer des mutations serait remis en question. L'enregistrement de services pour l'injection des dépendances, la gestion de traitement asynchrone par exemple peut être du code mutable mais difficile à attraper ou possiblement non pertinent.

Ainsi, nous devons choisir le code qui est soumis aux tests par mutation.

#### La chasse aux mutants

Maintenant que la chasse aux mutants est commencée, le premier problème est qu'il risque fort d'y avoir beaucoup plus de mutants que les développeurs peuvent gérer dans un effort acceptable. 

Si on exige qu'aucun mutant doit survivre, les développeurs vont passer beaucoup de temps à les attraper et seront tentés de vouloir tricher la métrique pour respecter ce standard. Sinon, attraper tous les mutants va générer beaucoup de tests automatisés peu pertinents, abstraits dont la maintenance sera coûteuse et souffrante.

#### Attraper les plus importants

Dans le cas où l'on tolère une efficacité à attraper les mutants de 85%, un problème est qu'on veut idéalement attraper les mutants les plus importants et dommageable selon le contexte. 

Techniquement la mise en place de filtres pour identifier ceux-ci peut s'avérer ardue et complexe. Il est inévitable que **le rapport des mutants survivants doit être surveillé** afin de réagir. Car, évidement le nombre total de mutants survivant sera le même pour une modification au code qui laisse nouvellement passer un mutant très dommageable mais attrape un autre moins important.

## Références

[Awesome Mutation testing](https://github.com/theofidry/awesome-mutation-testing): Répertoire GitHub très riches en information

[Don't chase test coverage](https://www.youtube.com/watch?v=BVErL_Ez9LI): Capsule de Dave Farley (Continuous Delivery) qui expose les faiblesses de la métrique de couverture du code par les tests - Août 2023

[C# Unit Tests With Mutation Testing](https://www.youtube.com/watch?v=9BoKyeZapLs): Webinar JetBrains avec l'invité Stefan Pölz (Clean C# Code & TDD) ([twitter](https://twitter.com/0x_F0)) - 4 Mai 2023

[An introduction to mutation testing](https://www.cs.cornell.edu/~dgeisler/mutation/testing/2021/11/01/mutation-testing1.html): Article en 3 parties qui expose la base mais aussi la tendance en pratique, des problèmes rencontrés et plus... par Dietrich Geisler - 8 Novembre 2021

[Increase the quality of unit tests using mutation with PITest](https://dev.to/silviobuss/increase-the-quality-of-unit-tests-using-mutation-with-pitest-3b27/): Article qui expose un cas les bienfaits d'intégrer les tests de mutation en JAVA par Silvio Buss - 17 Juillet 2019

[An industrial application of mutation testing: lessons, challenges and research](https://homes.cs.washington.edu/~rjust/publ/industrial_mutation_icst_2018.pdf): Papier complet d'un étude de cas en 2018 sur l'application de la pratique chez Google entre autres... par
- Google Switzerland: Goran Petrovic, Marko Ivankovi
- George Mason University USA: Bob Kurtz, Paul Ammann
- University of Massachusetts USA: René Just

[Mutation Testing](http://blog.cleancoder.com/uncle-bob/2016/06/10/MutationTesting.html): Article qui expose les avantages et les implications des tests par mutation par Robert C. Martin (Uncle Bob) - 10 Juin 2016