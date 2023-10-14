using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability
{
    public string Name;
    public int ManaCost;
    public int LevelReq;
    public int Range;
    public Ability(string name, int mana, int level, int range){
        Name = name;
        ManaCost = mana;
        LevelReq = level;
        Range = range;
    }

    public abstract void Use();
}