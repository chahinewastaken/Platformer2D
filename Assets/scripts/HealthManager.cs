using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class HealthManager : MonoBehaviour
{
    const float MAXHEALTH = 100;
    public float health;
    public Slider healthSlider;
    public float bonusHp=20;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        health = MAXHEALTH;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Die(){
	    GetComponent<CharacterController2D>().enabled = false;
        StartCoroutine(AfterDeath());
        SceneManager.LoadScene("Main");
        StopCoroutine(AfterDeath());
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
        GetComponent<AudioSource>().Play();
    }
    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.name=="health+"){
            health+=bonusHp;
            // UPDATE THE SLIDER
            healthSlider.value = health / MAXHEALTH;
        }
    }
    IEnumerator AfterDeath(){
         animator.SetBool("diying", true);
         yield return new WaitForSeconds(50f);
    }

}
