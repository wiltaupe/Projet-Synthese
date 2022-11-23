using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName ="evenements", menuName ="event")]
public class Evenement : ScriptableObject
{

    public string[] description;
    public Image[] background;
    public bool choix;
    public bool combat;
    public bool retourMenu;


    /*
        PlaneteGlace : Vous êtes arrivés sur une planète entièrement gelée, aucune forme de vie n’est présente, vous sembler voir au loin de la glace rouge, solide comme un blindage de vaisseau, peut-être pouvez-vous en tirer avantage... (débloque l’objet Glaciation)
        PlaneteRavagee : Un groupe occulte vous fais signe lors de votre arrivée, il souhaite apporter des modifications à votre vaisseau, ils promettent d’améliorer la cadence de tir...mais à quel prix ? (Ajoute 2 dilemmes défectueux) -> deuxième rencontre : À c’est vous que mes cousins ont arnaqués, ils ont dit avoir intentionnellement rendu des pièces défectueuses dans votre vaisseau. Laisser moi remédier à la situation (inverse pourcentage du malus et de l’avantage) dans 25% des cas (double malus et /2 les avantages) ou rajoute encore 2 dilemmes défectueux
        PlaneteNeutre : Le suzerain du royaume vous invite dans son château fait de topaze et d’émeraude. Sa garde rapprochée vous invite à vous servir dans son entrepôt personnel : vous pouvez choisir parmi 3 objets. 
        PlanetesHostiles : La légion d’honneur du suzerain est alliée depuis plusieurs décennies avec le tyran galactique, un de ses vaisseaux vous attaque --> mode combat activé
        PlaneteToxique : ajoute un membre d’équipage robotique (si amélioration défectueuse -- > combat) 
        PlaneteParadisiaque : vous et votre équipage profitez de l’hospitalité de cette planète pour vous reposer, en vous réveillant un membre de votre équipage semble avoir eu des relations intime avec une personne importante de cette planète, son père vous attaque violemment avec son vaisseau. Dans 25% des cas, vous perdez votre membre d’équipage, il s’emble s’être sauvé avec la personne importante --> deuxième rencontre : vous arrivez de nouveau sur une planète qui semble hospitalière, un individu de la planète semble reconnaitre votre équipage, il dit être le frère du fiancé de votre ancien membre d’équipage, il souhaite se joindre à vous. 
        PlaneteFeu : réduit la santé maximale de 3 de vos pièces de 50% 
        PlaneteIndigene : la population sur cette planète semble trouver votre comportement un peu étrange. Elle vous oblige à changer en vous donnant un dilemme de réflexion. 
        PlaneteCrystalline : Aye toi, le pauvre, c’est quoi se vaisseau de pacotille que tu possèdes, ramener moi ça à la décharge, qu’on lui montre la qualité d’un vaisseau cristallin : votre vaisseau est détruit et remplacé par un vaisseau cristallin 
        PlaneteEnormomax : Les habitants de cette planète semble apprécier le goût de la chair. Vous et votre équipage tenter de repartir au plus vite. -Checker moi ce repas qui essaye de se sauver de mon assiette. Un membre de votre équipage se fait rattraper. Vous perdez un membre. 
        PlanetePlate :  Cette planète semble vous faire douter de vos cours de science, vous reficher longuement a la logique autour de cette planète. Il existe un certain dilemme moral autour de la population de cette planète qui pense que les autres planètes ne sont pas plates. Vous décidez de ne pas vous en mêler et repartez. 
        PlaneteMecanique : Vous arrivez sur une planète ou règne un empereur robotique : “Votre chair vous éloigne de la perfection robotisée, offrez-moi le sang, et je ferais de vous des êtres de titane” Acceptez-vous son offre (si oui, vous perdez un membre d’équipage et le reste est transformé en robot, sinon combat)
        AnneauMonde : Les habitant de cette mégastructure semble enfin avoir trouver un matériau assez solide et flexible pour réussir la création d’un projet d’aussi grande envergure. -Je vous offre mon savoir en échange d’un des vôtres. (Si oui, vous perdez un objet et vous en recevez un nouveau) 
     */

}