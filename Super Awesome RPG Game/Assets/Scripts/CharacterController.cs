using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [Header("Character Stats")]
    [Space(5)]
    public string Name;
    public int Level;
    public float Health;
    public float Armor;
    public float Mana;
    public float Dmg;
    public float AttackRange;
    public float Exp;
    public Class Character_Class;
    public Ability[] Abilities;
    [Header("Character Status")]
    public bool Invinsible;
    public bool Stun;
    private void Update() {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log("Auto_Attack");
            AutoAttack();
        }
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("Ability_1");
            UseAbility(1);
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("Ability_2");
            UseAbility(2);
        }
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            Debug.Log("Ability_3");
            UseAbility(3);
        }
        if(Input.GetKeyDown(KeyCode.Alpha4))
        {
            Debug.Log("Ability_4");
            UseAbility(4);
        }
    }

    public void AutoAttack()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit, AttackRange))
        {
            hit.transform.GetComponent<CharacterController>().Health -= Dmg;
        }
    }

    public virtual void UseAbility(int ability)
    {
        
    }

    private void Ability1()
    {
    }
    private void Ability2()
    {

    }

    private void Ability3()
    {

    }
    private void Ability4()
    {

    }
    public enum Class
    {
        Warrior,
        Mage,
        Cleric,
        Archer,
        Rogue,
        E_Dummy
    }
}
