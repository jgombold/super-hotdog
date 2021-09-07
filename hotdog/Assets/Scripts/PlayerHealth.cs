using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;

    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
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

        if( healthBar.GetValue() <= 0)
        {
            SceneManager.LoadScene("End");
        }
        
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
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
