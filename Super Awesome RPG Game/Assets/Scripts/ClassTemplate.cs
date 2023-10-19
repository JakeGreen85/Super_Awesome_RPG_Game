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
public class ClassTemplate : CharacterController
{
    [Header("Warrior Ability Settings")]

    [Space(3)]

    [Header("Warrior's Rush")]
    public float _chargeSpeed;
    public float chargeDelay;
    public float chargeDuration;
    public int knockback;
    public float knockbackDmgMultiplier;
    public bool _isCharging = false;

    [Space(5)]

    [Header("Draconic Armor")]
    public float armorMultiplier;
    public float multiplierDuration;

    [Space(5)]

    [Header("Annihilation Blow")]
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
                Ability1(chargeDelay, chargeDuration);
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
    /// Warrior's Rush: Charge forward after a delay for the given duration
    /// </summary>
    /// <param name="delay">Charge is delayed by this amount</param>
    /// <param name="duration">Charge lasts for this amount</param>
    private void Ability1(float delay, float duration)
    {
        if(!_isCharging)
        {
            _isCharging = true;
            StartCoroutine(ChargeForDuration(delay, duration));
        }
    }

    /// <summary>
    /// Charges forward for a given duration (IEnumerator for Ability1 in WarriorController)
    /// </summary>
    /// <param name="delay">The delay for the charge (seconds)</param>
    /// <param name="duration">The duration to charge forward (seconds)</param>
    /// <returns></returns>
    private IEnumerator ChargeForDuration(float delay, float duration)
    {
        // First we do the delay
        float startTime = Time.time;
        // Play wind_up sound
        GetComponent<FirstPersonController>().playerCanMove = false;
        while(Time.time - startTime < delay)
        {
            yield return null;
        }

        // Then we charge
        // Play charge sound
        startTime = Time.time;
        while(Time.time - startTime < duration)
        {
            Debug.Log(transform.forward);
            transform.Translate(transform.forward * (_chargeSpeed * Time.deltaTime), Space.World);
            yield return null;
        }
        _isCharging = false;
        GetComponent<FirstPersonController>().playerCanMove = true;
    }


    /// <summary>
    /// Draconic Armor: Increase armor for set duration by the given multiplier
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
    /// Annihilation Blow: Wind up and deal a ton of damage
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
        GameObject[] characters = GameObject.FindGameObjectsWithTag("Player");

        // Find all player characters in the given range and add them to a list "characters_in_range" and give them invinsibility
        foreach(GameObject character in characters)
        {
            if(Vector3.Distance(this.transform.position, character.transform.position) < range)
            {
                // Play celestial_veil sound on affected players
                StartCoroutine(Invinsibile_Duration(duration, character));
            }
        }
        // Start coroutine that runs for 5 seconds, then revokes invinsibility for all players that were given invinsibility
    }

    /// <summary>
    /// Set invinsibility for set duration to a given player (IEnumerator for Ultimate ability (Ability4))
    /// </summary>
    /// <param name="duration">The duration for which the coroutine should run for</param>
    /// <param name="character">The character that should receive invinsibility</param>
    /// <returns></returns>
    private IEnumerator Invinsibile_Duration(float duration, GameObject character)
    {
        // Run coroutine for the given duration
        float startTime = Time.time;
        while(Time.time - startTime < duration)
        {
            // Make sure that the character is invinsible for the entire duration in the case that the player gained invinsibility from a different source
            if(!character.GetComponent<CharacterController>().Invinsible)
            {
                character.GetComponent<CharacterController>().Invinsible = true;
            }
            yield return null;
        }

        // After the duration, revoke invinsibility
        character.GetComponent<CharacterController>().Invinsible = false;
            
    }


    private void OnCollisionEnter(Collision other) {
        // Knockback enemies when charging into them
        if(_isCharging)
        {
            // Play charge_hit_sound
            other.rigidbody.AddForce(this.transform.forward.x*knockback,knockback,this.transform.forward.z*knockback, ForceMode.VelocityChange);
            other.gameObject.GetComponent<CharacterController>().Health -= Dmg * knockbackDmgMultiplier;
        }
    }

}