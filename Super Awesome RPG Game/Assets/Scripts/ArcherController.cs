using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;

/// <summary>
/// Controller for the archer class with all the warrior specific behavior
/// </summary>
public class ClassTemplate : CharacterController
{
    [Header("Archer Ability Settings")]

    [Space(3)]

    [Header("Piercing Shot")]
    public float piercingRange;
    public float piercingCharge;
    

    [Space(5)]

    [Header("Crippling Volley")]
    public float cripplingRadius;
    public float cripplingEffect;
    public float damageMultiplier;
    public float cripplingDuration
    

    [Space(5)]

    [Header("Eagle Eye Precision")]
    public float precisionCharge;;
    public float criticalHitIncrease;
    public float precitionDuration;
    

    [Space(5)]

    [Header("Storm of Arrows")]
    public float ultimateRadius;
    public float ultimateDuration;
    public float ultimateMultiplier;
    public float ultimateCharge;
    


    /// <summary>
    /// Checks the input from the user and casts the corresponding ability
    /// </summary>
    /// <param name="ability">The ability index which will be cast (1-4)</param>
    public override void UseAbility(int ability)
    {
        switch(ability)
        {
            case 1:
                Ability1(piercingRange, piercingCharge);
                break;
            case 2:
                Ability2(cripplingRadius, cripplingEffect, damageMultiplier, cripplingDuration);
                break;
            case 3:
                Ability3(precisionCharge, criticalHitIncrease, precitionDuration);
                break;
            case 4:
                Ability4(ultimateRadius, ultimateDuration, ultimateMultiplier, ultimateCharge);
                break;
            default:
                break;
        }
    }
    /// <summary>
    /// Piercing Shot: Projectile that pierces through enemies
    /// </summary>
    /// <param name="range"></param>
    /// <param name="charge"></param>
    private void Ability1(float range, float charge)
    {
        
    }

    private IEnumerator EnumForAbility1()
    {
        
    }

    /// <summary>
    /// Crippling Volley: Launch arrows in an area, that damage and slows enemies
    /// </summary>
    /// <param name="radius"></param>
    /// <param name="effect"></param>
    /// <param name="multiplier"></param>
    /// <param name="duration"></param>
    private void Ability2(float radius, float effect, float multiplier, float duration)
    {

    }

    private IEnumerator EnumForAbility2()
    {
        
    }

    /// <summary>
    /// Eagle Eye Precision: Enter a state of heightened focus that increase attackspeed and critical hit chance
    /// </summary>
    /// <param name="charge"></param>
    /// <param name="cHitIncrease"></param>
    /// <param name="duration"></param>
    private void Ability3(float charge, float cHitIncrease, float duration)
    {

    }

    private IEnumerator EnumForAbility3()
    {
        
    }

    /// <summary>
    /// Storm of Arrows: Launch a volley of deadly arrows that cause a lot of damage to enemies in the area
    /// </summary>
    /// <param name="radius"></param>
    /// <param name="duration"></param>
    /// <param name="multiplier"></param>
    /// <param name="charge"></param>
    private void Ability4(float radius, float duration, float multiplier, float charge)
    {
        
    }

    private IEnumerator EnumForAbility4()
    {
        
    }


    private void OnCollisionEnter(Collision other) 
    {

    }

}