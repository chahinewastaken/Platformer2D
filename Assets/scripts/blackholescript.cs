using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class blackholescript : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D col) {
    if (col.gameObject.name=="player")
    {
        Destroy(col.gameObject);
        SceneManager.LoadScene("Main");
    }
   }
}
