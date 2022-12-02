using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
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


    public int hp, defense, agility, speed, atkPower, mechPower;
    public List<Tags> mechTags;
    public List<Part> mechComponents;
    public string name;
    public string description;

    public Mech(string _name, string _description, int _hp, int _def, int _agi, int _spd, int _atkPow, int _mechPow, List<Tags> _mTags, List<Part> _mComp)
    {
        name = _name;
        description = _description;
        hp = _hp;
        defense = _def;
        agility = _agi;
        speed = _spd;
        atkPower = 0;
        mechPower = 0;

        mechTags = new List<Tags>();
        
        mechComponents = new List<Part>();
        foreach (Part t in _mComp)
        {
            mechComponents.Add(t);
        }
        _mComp.Clear();
    }
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

    public enum ComponentType
    {
        Frame,
        Weapon,
        Arm,
        Leg,
        Reactor
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


