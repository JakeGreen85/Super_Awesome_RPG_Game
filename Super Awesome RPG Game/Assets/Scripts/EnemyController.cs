using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Character character;

    private void Start() {
        character = new Enemy("dummy", 1, 30, 100, 0, 0);
    }

    private void Update() {
        if(character.Health <= 0){
            Destroy(this.gameObject);
        }
    }

    public void AutoAttack(){
        RaycastHit hit;
        if(Physics.Raycast(transform.position, Vector3.forward, out hit, character.AttackRange)){
            character.Attack(hit.transform.GetComponent<Character>());
        }
    }
}
