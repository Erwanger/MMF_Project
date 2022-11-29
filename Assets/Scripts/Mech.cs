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

[System.Serializable]
public class Part
{
/*Int Id
Type
Nom
Description
�nergie
Stats
Co�t en ressources(en faisant correspondre l�Int avec l�Id de ressource)*/

    public ComponentType type;
    public int id, energyCost;
    public int[] stats;
    public List<Resource> resourceCost;
    public string name, description;

    [System.Serializable]
    public struct Resource
    {
        public int resourceId;
        public int qty;

        public Resource(int _res, int _qty)
        {
            resourceId = _res;
            qty = _qty;
        }
    }

    public Part(ComponentType _t, int _id, int _energy, int[] _stats, List<Resource> _resources, string _name, string _desc)
    {
        type = _t;
        id = _id;
        energyCost = _energy;
        stats = new int[4];
        resourceCost = new List<Resource>();
        for(int i=0; i<4; i++)
        {
            stats[i] = _stats[i];
        }
        foreach (Resource res in _resources)
        {
            resourceCost.Add(res);
            
        }
        _resources.Clear();
        name = _name;
        description = _desc;
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
    Frame,
    Weapon,
    Arm,
    Leg,
    Reactor
}
