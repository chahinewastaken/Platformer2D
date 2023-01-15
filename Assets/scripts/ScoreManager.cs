using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{   
    int score;
public Text scoretxt;
void OnTriggerEnter2D(Collider2D col){
    if(col.gameObject.tag =="coin"){
        score++;
        Destroy(col.gameObject);
        scoretxt.text=score.ToString();
    }
    
    
}
void Update(){
    if(score > PlayerPrefs.GetInt("Highscore"))
    {
        PlayerPrefs.SetInt("highscore", score);
    }
}
}
