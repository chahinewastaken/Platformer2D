using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    const float MAXHEALTH = 100;
    float health;
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
}
}
