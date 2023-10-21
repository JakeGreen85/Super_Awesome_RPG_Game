using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyController : CharacterController
{
    private void Update() {
        CheckDeath();
    }

    private void CheckDeath(){
        if(Health <= 0){
            Destroy(this.gameObject);
        }
    }
}
