using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;

/// <summary>
/// Controller for the rogue class with all the warrior specific behavior
/// </summary>
public class RogueController : CharacterController
{
    [Header("Rogue Ability Settings")]

    [Space(3)]

    [Header("Bleed to target")]
    

    [Space(5)]

    [Header("Increase attack speed")]
    

    [Space(5)]

    [Header("Increase movement speed")]
    

    [Space(5)]

    [Header("Invisible and invinsible")]
    


    /// <summary>
    /// Checks the input from the user and casts the corresponding ability
    /// </summary>
    /// <param name="ability">The ability index which will be cast (1-4)</param>
    public override void UseAbility(int ability)
    {
        switch(ability)
        {
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

    private void Ability1()
    {
        
    }

    private IEnumerator EnumForAbility1()
    {
        
    }

    private void Ability2()
    {

    }

    private IEnumerator EnumForAbility2()
    {
        
    }

    private void Ability3()
    {

    }

    private IEnumerator EnumForAbility3()
    {
        
    }

    private void Ability4()
    {
        
    }

    private IEnumerator EnumForAbility4()
    {
        
    }


    private void OnCollisionEnter(Collision other) 
    {

    }

}