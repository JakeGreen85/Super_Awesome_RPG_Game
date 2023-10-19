using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyController : CharacterController
{

    private void Update() {
        if(Health <= 0){
            Destroy(this.gameObject);
        }
    }
}
