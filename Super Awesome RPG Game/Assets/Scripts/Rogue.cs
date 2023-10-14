using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rogue : Character
{
    public int Agility { get; set; }
    public Rogue(string name, int level, int health, int mana, int dmg, float atkRange, int agility) : base(name, level, health, mana, dmg, atkRange)
    {
        Agility = agility;
    }

    public override void Ability1()
    {

    }

    public override void Ability2()
    {

    }

    public override void Ability3()
    {

    }

    public override void Ability4()
    {

    }
}
