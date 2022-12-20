# Projet-Synthèse
Projet Final - Technique Informatique - CVM
Etudiants : William Caron / David Demers

## Sommaire
Projet synthese d'un groupe de deux étudiants d'une formation intesive d'approximativement 2000 heures en technique informatique du Cégep du Vieux Montréal.

## Présentation du projet
Ce projet constiste a être un jeu video du style Rogue Like dans l'espace où le joueur se doit de détruire le vaisseau ennemi à l'aide de son propre vaisseau. Tout au long de son aventure, le joeur va se retrouver face à diversion situation qui lui permettra d'augmenter la puissance de son vaisseau.

## Installation
Pour ce faire, il suffit de télécharger Unity avec la version d'editeur 2021.2.19f1 ou de jouer avec la version du Build de Unity.

## Utilisation

### Lancer le jeu
Dans Unity, il faut démarer la scene MenuInitial.

### Préparation d'avant partie
Lors du premier lancement du jeu, l'utilisateur sera amener a entrer son nom ainsi que son âge dans l'espace réservé pour celui-ci. Il sera facile de distinger où les écrires.

### Lancer la Partie
Pour lancer la partie, il suffit de clicker sur le bouton [Vengez-Vous !]. Le bouton [Souvenir] n'étant pas implémenter son utilité est de faire un changement de scene vers un menu qui contient seulement un fond d'écran animer et un bouton retour.

### Déroulement de la Partie
* La première scene de jeu oblige a l'utilisateur de placer 3 pièces de vaisseau appelé module avant de pouvoir faire un changement de scene dans un vaisseau généré aléatoirement.

* Par la suite, le joueur sera alors amener dans un menu contenant une carte céleste remplis de planètes qui marqueras l'avancement du joueur au cours de sa partie. Il suffit d'en sélectionner une completement a gauche de celle-ci pour changer de scene vers un évenements aléatoire.

* Dans le cas d'un combat le vaisseau de l'utilisateur sera situé a la gauche de l'écran et le vaisseau ennemi a la droite. Le joueur sera alors présenté à une liste de choix qui auront chacun un effet pour le combat. La plupart d'entre elles sont seulement a selectionner mais certaine demander aussi de devoir viser une salle de vaisseau ennemi. Le joueur perd la partie si la vie, situé en bas de son vaisseau, est réduit à 0.

* Dans le cas d'une victoire le joueur sera redirigé vers le menu contenant la carte celestre. Dans le cas d'une défaite vers le menu de fin de partie.

## Références 
https://www.geeksforgeeks.org/print-leaf-nodes-left-right-binary-tree
https://www.youtube.com/watch?v=alU04hvz6L4 // temps 22:25
