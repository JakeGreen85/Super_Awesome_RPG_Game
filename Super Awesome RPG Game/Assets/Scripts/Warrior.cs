using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : Character
{
    public int Strength { get; set; }
    public Warrior(string name, int level, int health, int mana, int dmg, float atkRange, int strength) : base(name, level, health, mana, dmg, atkRange)
    {
        Strength = strength;
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
