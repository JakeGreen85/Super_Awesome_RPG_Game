using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character
{
    public string Name { get; set; }
    public int Level { get; set; }
    public int Health { get; set; }
    public int Mana { get; set; }
    public int Dmg { get; set; }
    public float AttackRange { get; set; }
    public int Exp { get; set; }
    public Ability[] Abilities { get; set; }
    public Character(string name, int level, int health, int mana, int dmg, float atkRange){
        Name = name;
        Level = level;
        Health = health;
        Mana = mana;
        Dmg = dmg;
        AttackRange = atkRange;
        Exp = 0;
    }

    public void Attack(Character target){
        Debug.Log("Attacking: " + target.Name + " - " + target.Health + "health");
        target.Health -= this.Dmg;
    }

    public void UseAbilities(int ability){
        switch(ability){
            case 1:
                Ability1();
                break;
            case 2:
                Ability2();
                break;
            case 3:
                Ability3();
                break;
            case 4:
                Ability4();
                break;
            default:
                break;
        }
    }

    public abstract void Ability1();

    public abstract void Ability2();

    public abstract void Ability3();

    public abstract void Ability4();
}
