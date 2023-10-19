using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class PlayerController : CharacterController
{
    public Component Controller;

    private void Start() {
        
    }

    private void Update() {
        RaycastHit hit;
        if(Input.GetKey(KeyCode.Mouse0))
        {
            Debug.Log("Auto_Attack");
            if(Physics.Raycast(transform.position, transform.forward, out hit, AttackRange))
            {
                Debug.DrawRay(transform.position, transform.forward, Color.green);
                hit.transform.GetComponent<CharacterController>().Health -= Dmg;
            }
        }
        if(Input.GetKey(KeyCode.Alpha1))
        {
            Debug.Log("Ability_1");
            
        }
        if(Input.GetKey(KeyCode.Alpha2))
        {
            Debug.Log("Ability_2");
            //Controller.Ability2();
        }
        if(Input.GetKey(KeyCode.Alpha3))
        {
            Debug.Log("Ability_3");
            //Controller.Ability3();
        }
        if(Input.GetKey(KeyCode.Alpha4))
        {
            Debug.Log("Ability_4");
            //Controller.Ability4();
        }
    }
}
