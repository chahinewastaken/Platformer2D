using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class blackhole2 : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D col) {
    if (col.gameObject.name=="player")
    {
        Destroy(col.gameObject);
        SceneManager.LoadScene("Main 2");
    }
   }
}
