using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Character character;

    private void Start() {
        character = new Warrior("Captain America", 100, 1000, 1000, 10, 3, 1000);
    }

    private void Update() {
        RaycastHit hit;
        if(Input.GetKey(KeyCode.Mouse0))
        {
            Debug.Log("Auto_Attack");
            if(Physics.Raycast(transform.position, transform.forward, out hit, character.AttackRange))
            {
                character.Attack(hit.transform.GetComponent<EnemyController>().character);
            }
        }
        if(Input.GetKey(KeyCode.Alpha1))
        {
            Debug.Log("Ability_1");
            character.UseAbilities(1);
        }
        if(Input.GetKey(KeyCode.Alpha2))
        {
            Debug.Log("Ability_2");
            character.UseAbilities(2);
        }
        if(Input.GetKey(KeyCode.Alpha3))
        {
            Debug.Log("Ability_3");
            character.UseAbilities(3);
        }
        if(Input.GetKey(KeyCode.Alpha4))
        {
            Debug.Log("Ability_4");
            character.UseAbilities(4);
        }
    }
}
