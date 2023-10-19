using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;

/// <summary>
/// Controller for the warrior class with all the warrior specific behavior
/// </summary>
public class MageController : CharacterController
{
    [Header("Mage Ability Settings")]

    [Space(3)]

    [Header("Blink")]
    public float blinkDistance;
    public float blinkCooldown;

    [Space(5)]

    [Header("Arcane Barrage")]
    public float armorMultiplier;
    public float multiplierDuration;

    [Space(5)]

    [Header("Chaos Bolt")]
    public float windUpDuration;
    public float damageMultiplier;

    [Space(5)]

    [Header("Celestial Veil")]
    public float ultimateRange;
    public float ultimateDuration;


    /// <summary>
    /// Checks the input from the user and casts the corresponding ability
    /// </summary>
    /// <param name="ability">The ability index which will be cast (1-4)</param>
    public override void UseAbility(int ability)
    {
        switch(ability)
        {
            case 1:
                Ability1(blinkDistance);
                break;
            case 2:
                Ability2(armorMultiplier, multiplierDuration);
                break;
            case 3:
                Ability3(windUpDuration, damageMultiplier);
                break;
            case 4:
                Ability4(ultimateRange, ultimateDuration);
                break;
            default:
                break;
        }
    }


    /// <summary>
    /// Blink: Teleport in the given direction
    /// </summary>
    /// <param name="delay">Charge is delayed by this amount</param>
    /// <param name="duration">Charge lasts for this amount</param>
    private void Ability1(float dist)
    {
        Vector3 dir = new Vector3(Input.GetAxis("Horizontal")*dist, 0, Input.GetAxis("Vertical")*dist);
        transform.SetPositionAndRotation(transform.position + dir, transform.rotation);

    }


    /// <summary>
    /// Arcane Barrage: Send out a barrage of arcane torrents, that follows your crosshair until colliding with something
    /// </summary>
    /// <param name="multiplier">Armor increase (armor * multiplier)</param>
    /// <param name="duration">Duration of the armor increase</param>
    private void Ability2(float multiplier, float duration)
    {
        StartCoroutine(IncreaseArmorForDuration(multiplier, duration));
    }

    /// <summary>
    /// Increase armor (IEnumerator for ability2)
    /// </summary>
    /// <param name="multiplier">Armor multiplier (armor * multiplier)</param>
    /// <param name="duration">Duration of the armor increase</param>
    /// <returns></returns>
    private IEnumerator IncreaseArmorForDuration(float multiplier, float duration)
    {
        // Play armor_up sound
        float startTime = Time.time;
        Armor *= multiplier;
        while(Time.time - startTime < duration)
        {
            yield return null;
        }

        Armor /= multiplier;
    }


    /// <summary>
    /// Chaos Bolt: Send out a huge projectile that follows your crosshair until colliding with something
    /// </summary>
    /// <param name="duration">The duration of the wind up (delay of attack)</param>
    /// <param name="multiplier">The damage multiplier (base damage * multiplier)</param>
    /// <returns></returns>
    private void Ability3(float duration, float multiplier)
    {

        StartCoroutine(Deadly_Blow(duration, multiplier));
    }

    /// <summary>
    /// IEnumerator for Annihilation Blow (Ability3)
    /// </summary>
    /// <param name="duration">The duration of the wind up (delay of attack)</param>
    /// <param name="multiplier">The damage multiplier (base damage * multiplier)</param>
    /// <returns></returns>
    private IEnumerator Deadly_Blow(float duration, float multiplier)
    {
        // Wind up (delay)
        float startTime = Time.time;
        // play wind_up sound
        while(Time.time - startTime < duration)
        {
            yield return null;
        }

        // Then hit (collision detection)
        RaycastHit hit;
        // Play swinging sound
        if(Physics.Raycast(transform.position, transform.forward, out hit, AttackRange))
        {
            // Play hit sound
            hit.transform.GetComponent<CharacterController>().Health -= Dmg*multiplier;
        }
    }


    /// <summary>
    /// Celestial Veil: Ultimate ability (Give invinsibility)
    /// </summary>
    /// <param name="range">The range for which players gain invinsibility</param>
    /// <param name="duration">The duration for invinsibility</param>
    private void Ability4(float range, float duration)
    {
        
    }


    private void OnCollisionEnter(Collision other) 
    {
        
    }

}