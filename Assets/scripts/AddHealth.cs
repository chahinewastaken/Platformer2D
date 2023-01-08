using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddHealth : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.name=="player"){
            Destroy(this.gameObject);
        }
    }
}
