using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Mech
{
/*Pv : Quantité de dégâts pouvant être encaissés
Def : Quantité de dégâts ignorés
Agi : Capacité à esquiver(et poursuivre un ennemi avec Tag “Agile”?)
Spd : Vitesse de déplacement du mech
PuissATK : Capacité à infliger des dégâts.
Equipage : Nombre de personnes requises pour manoeuvrer le mech
Puissance réacteur : Nombre de pts de structure max du mech
Tags : Liste des Tags récupérés par chaque partie du mech*/


    private int hp, defense, agility, speed, atkPower, mechPower;
    private List<Tags> mechTags;
    private List<Tags> mechComponents;     




}


public class Part
{
/*Int Id
Type
Nom
Description
Énergie
Stats
Coût en ressources(en faisant correspondre l’Int avec l’Id de ressource)*/

    private ComponentType type;
    private int id, energyCost;
    private int[] stats;
    private List<Resource> resourceCost;
    private string name, description;
    

    struct Resource
    {
        int resourceId;
        int qty;
    }
}

public enum Tags
{
    Kinetic,
    Thermal,
    Sharp,
    CloseCombat,
    NonLethal,
    AoE,
    Heal,
    Drill,
    Grab,
    LongRange,
    IgnoreDef,
    DCA,
    Fly,
    Self
}

public enum ComponentType
{






}
