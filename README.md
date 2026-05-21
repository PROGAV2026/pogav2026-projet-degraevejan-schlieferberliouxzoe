<div align="center">

# 🚀 PROJET ZINZIN — Clé du Vaisseau

_À la recherche de la clé perdue à bord du vaisseau_

</div>

---

## 📖 Description

Dans le cadre de notre projet en programmation avancée, on a eu l'opportunité de concevoir un jeu en C#, dans le terminal.

Voici, le rendu ci-dessous du visuel :

> <img width="1000" height="800" alt="Terminal" src="https://github.com/PROGAV2026/pogav2026-projet-degraevejan-schlieferberliouxzoe/blob/main/Photo_readme/Capture_ensembleJeu.png" />

---

## 🌌 Concept

> Un **ZINZIN** est perdu dans un vaisseau de **10 étages** et doit, en trouvant la clé, sortir du vaisseau en **10 minutes** 😉

| #   | Objectif                             |
| --- | ------------------------------------ |
| 1️⃣  | Explorer les étages du vaisseau      |
| 2️⃣  | Trouver la clé cachée dans un module |
| 3️⃣  | Revenir au bon module de pilotage    |

---

## 🛸 Organisation du vaisseau

### Les étages

Le vaisseau est composé de **trois** types d'étages :

| Étage | Type              |
| ----- | ----------------- |
| 🖥️    | Poste de pilotage |
| ⚙️    | Salle machine     |
| 🛏️    | Lieu de vie       |

### Les modules

Chaque étage contient 4 **modules** parmi lesquels le **ZINZIN** peut avoir des interactions avec des objects présents dans les modules:

| Module | Description           |
| ------ | --------------------- |
| 🔵     | Téléportation Départ  |
| 🔴     | Téléportation Arrivée |
| 📦     | Coffre                |
| 🛌     | Couchette             |
| ☢️     | Moteur                |
| 🕹️     | Pilotage              |

---

## 🕹️ Deplacement du joueur

> Le joueur peut se déplacer dans le vaisseau grâce aux flèches du clavier. Le personnage a la capacité d'interagir avec A, avec les élèments qui l'entoure.
> Il peut aussi à tout moment quitter le jeu avec la touche échap.
>
> <img width="300" height="200" alt="Terminal" src="https://github.com/PROGAV2026/pogav2026-projet-degraevejan-schlieferberliouxzoe/blob/main/Photo_readme/Capture_Deplacement.png" />

## ⚙️ Installation

Nous avons utilisé l'ensemble du terminal pour une meilleure expérience utilisateur.

**1. Ouvrir un terminal dans une nouvelle fenêtre**

<img width="500" height="350" alt="Terminal" src="https://github.com/user-attachments/assets/89d80034-58a6-47f3-a2a9-59e1b3b3d163" />

> 💡 Mettez en plein écran avec **F11** pour une meilleure expérience.

**2. Cloner et lancer le projet**

```bash
git clone https://github.com/PROGAV2026/pogav2026-projet-degraevejan-schlieferberliouxzoe.git
cd Code_C#
dotnet run
```

---

## 🧪 Mode Test

Un mode test est disponible pour tester rapidement les fonctionnalités, vous pourrez faire le choix lors du lancement du jeu.

<img width="600" height="350" alt="Mode Test" src="https://github.com/user-attachments/assets/3b6df3b8-a0ba-4066-bc42-6d4d9668f226" />

---

## 🏆 Meilleur Joueur

Le jeu enregistre le nom et le temps des **10 meilleurs joueurs** dans un fichier 😉

À la fin du jeu, vous pourrez voir apparaître le classement — **soyez les premiers à terminer le jeu !**
<img width="400" height="600" alt="Mode Test" src="https://github.com/PROGAV2026/pogav2026-projet-degraevejan-schlieferberliouxzoe/blob/main/Photo_readme/Capture_classement.png" />

---

## 🖥️ Rendu Terminal

Pour le rendu terminal nous avons cherché longtemps comment faire au mieux l'affichage console. Au premier semestre, nous avions été beaucoup frustrés de l'aspect du terminal. Nous avons trouvé une librairie qui permet de découper les fenêtres en plusieurs panneaux pour l'affichage du jeu ce qui nous a permis de simplifier l'affichage en lui même.

📚 Documentation : [Spectre.Console](https://spectreconsole.net/)

---

## 👨‍💻 Auteurs

<div align="center">

| 👤 **Jan de Greave** | 👤 **Zoé Schliefer Berlioux** |

</div>

---

<div align="center">

_Bonne découverte du jeu ! Amusez-vous bien 🚀_

</div>
