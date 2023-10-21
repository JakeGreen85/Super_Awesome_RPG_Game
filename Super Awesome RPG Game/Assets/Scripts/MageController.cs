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
    public int projectiles;
    public float projectileSpeed;
    public float barrageRange;
    public float barrageDuration;
    public GameObject smallPrefab;

    [Space(5)]

    [Header("Chaos Bolt")]
    public float boltSize;
    public float boltSpeed;
    public float boltRange;
    public float damageMultiplier;
    public float largePrefab;

    [Space(5)]

    [Header("Arcane Cataclysm")]
    public float ultimateRange;
    public float ultimateWidth;
    public float ultimateMultiplier;
    public float ultimateCharge;
    public float ultimateKnockback;

    /// <summary>
    /// Checks the input from the user and casts the corresponding ability
    /// </summary>
    /// <param name="ability">The ability index which will be cast (1-4)</param>
    public override void UseAbility(int ability)
    {
        switch(ability)
        {
            case 1:
                Ability1(blinkDistance, blinkCooldown);
                break;
            case 2:
                Ability2(projectiles, projectileSpeed, range, barrageDuration);
                break;
            case 3:
                Ability3(boltSize, boltSpeed, boltRange, damageMultiplier);
                break;
            case 4:
                Ability4(ultimateRange, ultimateWidth, ultimateMultiplier, ultimateCharge, ultimateKnockback);
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// Blink: Teleport in the given direction
    /// </summary>
    /// <param name="dist">How far the player travels</param>
    /// <param name="cooldown">Cooldown of ability</param>
    private void Ability1(float dist, float cooldown)
    {
        Vector3 dir = new Vector3(Input.GetAxis("Horizontal")*dist, 0, Input.GetAxis("Vertical")*dist);
        transform.SetPositionAndRotation(transform.position + dir, transform.rotation);
    }

    /// <summary>
    /// Arcane Barrage: Send out a barrage of arcane torrents, that follows your crosshair until colliding with something
    /// </summary>
    /// <param name="projectiles">How many projectiles to send out</param>
    /// <param name="speed">Speed of projectiles</param>
    /// <param name="range">Range of projectiles</param>
    private void Ability2(int projectiles, float speed, float range, float duration)
    {
        StartCoroutine(Arcane_Barrage(projectiles, range, duration));
    }

    /// <summary>
    /// Increase armor (IEnumerator for ability2)
    /// </summary>
    /// <param name="multiplier">Armor multiplier (armor * multiplier)</param>
    /// <param name="duration">Duration of the armor increase</param>
    /// <returns></returns>
    private IEnumerator Arcane_Barrage(float projectiles, float range, float duration)
    {
        for(int i=0, i < projectiles, i++)
        {

            float startTime = Time.time;
            while(Time.time - startTime < duration)
            {
                yield return null;
            }

            // Each projectile should follow the player crosshair until colliding  with something
            StartCoroutine(Arcane_Projectile(smallPrefab)); 
        }
    }

    private IEnumerator Arcane_Projectile(GameObject prefab)
    {
        Instantiate(prefab);
    }

    /// <summary>
    /// Chaos Bolt: Send out a huge projectile that follows your crosshair until colliding with something
    /// </summary>
    /// <param name="size">Size of projectile</param>
    /// <param name="speed">Speed of projectile</param>
    /// <param name="range">Range of projectile</param>
    /// <param name="multiplier">Damage multiplier of projectile</param>
    /// <returns></returns>
    private void Ability3(float size, float speed, float range, float multiplier)
    {
        StartCoroutine(Arcane_Projectile(largePrefab));
    }

    /// <summary>
    /// Arcane Cataclysm: Ultimate ability (Send of wave of arcane energy that knocks back enemies and gives debuff)
    /// </summary>
    /// <param name="range">The range of the wave</param>
    /// <param name="width">Width of wave</param>
    /// <param name="multiplier">Damage multiplier of ultimate</param>
    /// <param name="charge">Charge duration of ultimate</param>
    private void Ability4(float range, float width, float multiplier, float charge, float knockback)
    {
        StartCoroutine(Arcane_Cataclysm(charge, multiplier, range, width, knockback));
    }


    private IEnumerator Arcane_Cataclysm(float charge, float multiplier, float range, float width, float knockback)
    {
        // Charge attack
        float startTime = Time.time;
        while(Time.time - startTime < charge)
        {
            yield return null;
        }

        // Register hits 
        RaycastHit[] hits;
        if(Physics.SphereCastAll(transform.position, width, transform.forward, out hit, range))
        {
            foreach(RaycastHit hit in hits)
            {
                // subtract health and knockback each enemy hit
                hit.transform.GetComponent<CharacterController>().Health -= Dmg*multiplier;
                hit.GetComponent<rigidbody>().AddForce(transform.forward.x*knockback, knockback, transform.forward.z*knockback, ForceMode.VelocityChange);
            }
        }
    }

}