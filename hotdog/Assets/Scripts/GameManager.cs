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
            Invoke("ChangeToWin", 2f);
        }

        if (bossHealthBar.GetValue() <= 750)
        {
            meatballs.SetActive(true);
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
