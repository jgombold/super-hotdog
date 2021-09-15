using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;

    public HealthBar healthBar;
    [SerializeField] GameObject damageEffect;

    private float timer;
    private bool effect;

    // Start is called before the first frame update
    void Start()
    {   
        effect = false;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    { /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(1);
        }*/
        if(effect)
        {
            timer += Time.deltaTime;
            damageEffect.SetActive(effect);
            if (timer >= .25f)
            {
                effect = false;
                damageEffect.SetActive(effect);
                timer = 0;
            }
            
        }
        

        
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        effect = true;

    }

    

    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("PLAYER HIT: " + collision.collider.name);
        if ( collision.gameObject.tag == "HeadBullet")
        {
            TakeDamage(1);
        }
        
    }

}
