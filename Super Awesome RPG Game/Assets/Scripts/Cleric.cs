using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleric : Character
{
    public int Intelligence { get; set; }
    public Cleric(string name, int level, int health, int mana, int dmg, float atkRange, int intelligence) : base(name, level, health, mana, dmg, atkRange)
    {
        Intelligence = intelligence;
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
