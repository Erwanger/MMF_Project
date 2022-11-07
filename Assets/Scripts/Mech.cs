using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Mech
{
/*Pv : Quantit� de d�g�ts pouvant �tre encaiss�s
Def : Quantit� de d�g�ts ignor�s
Agi : Capacit� � esquiver(et poursuivre un ennemi avec Tag �Agile�?)
Spd : Vitesse de d�placement du mech
PuissATK : Capacit� � infliger des d�g�ts.
Equipage : Nombre de personnes requises pour manoeuvrer le mech
Puissance r�acteur : Nombre de pts de structure max du mech
Tags : Liste des Tags r�cup�r�s par chaque partie du mech*/


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
�nergie
Stats
Co�t en ressources(en faisant correspondre l�Int avec l�Id de ressource)*/

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
