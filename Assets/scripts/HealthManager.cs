using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    const float MAXHEALTH = 100;
    public float health;
    public Slider healthSlider;
    public float bonusHp=20;
    // Start is called before the first frame update
    void Start()
    {
        health = MAXHEALTH;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Die(){
	    GetComponent<CharacterController2D>().enabled = false;
    }
    public void TakeDamage(float amount) {
	    health -= amount;
	    if(health <= 0){
		    health = 0;
		    Die();
		}
        health -= amount;
        if(health <= 0)
        {
            health = 0;
            Die();
        }
				
	    // UPDATE THE SLIDER
        healthSlider.value = health / MAXHEALTH;
    }
    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.name=="health+"){
            health+=bonusHp;
            // UPDATE THE SLIDER
            healthSlider.value = health / MAXHEALTH;
        }
    }
}
