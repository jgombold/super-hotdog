using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] HealthBar playerHealthBar;
    [SerializeField] HealthBar bossHealthBar;
    [SerializeField] GameObject meatballs;
    [SerializeField] BossMovement bossMovement;
    [SerializeField] Boss bossBehavior;
    [SerializeField] Transform bossLocation;
    [SerializeField] ParticleSystem explosion;
    [SerializeField] GameObject exlposionObject;
    [SerializeField] GameObject theBoss;
    [SerializeField] AudioSource explodeSound;

    //[SerializeField] GameObject boss;

    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //checks if player fell off platform
        if ( player.position.y <= -50f)
        {
            SceneManager.LoadScene("End");
        }

        //checks if player has no more health
        if (playerHealthBar.GetValue() <= 0)
        {
            SceneManager.LoadScene("End");
        }

        //checks is boss has no more health
        if (bossHealthBar.GetValue() <= 0)
        {   
            try {
                exlposionObject.transform.position = bossLocation.position;
                Destroy(theBoss);
                explodeSound.Play();
                explosion.Play();
                Invoke("ChangeToWin", 3f);
            }
            catch (MissingReferenceException)
            {
                
            }
            
        }

        if (bossHealthBar.GetValue() <= (bossHealthBar.GetMaxValue() * (3/4.0)))
        {
            meatballs.SetActive(true);
            bossMovement.RPM = 30;
            bossBehavior.shootInterval = .25f;
            
        }

        if (bossHealthBar.GetValue() <= (bossHealthBar.GetMaxValue() * (1/2.0)))
        {
            bossBehavior.shootInterval = .125f;
            bossMovement.RPM = 35;
        }

        //Debug.Log("PLAYER HEALTH: " + playerHealthBar.GetValue());
        //Debug.Log("BOSS HEALTH: " + bossHealthBar.GetValue());
    }

    void ChangeToLose()
    {
        SceneManager.LoadScene("End");
    }

    void ChangeToWin()
    {
        SceneManager.LoadScene("Win");
    }
}
