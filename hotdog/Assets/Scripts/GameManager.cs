using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] HealthBar playerHealthBar;
    [SerializeField] HealthBar bossHealthBar;



    // Update is called once per frame
    void Update()
    {
        if ( player.position.y <= -50f)
        {
            SceneManager.LoadScene("End");
        }

        if (playerHealthBar.GetValue() <= 0)
        {
            SceneManager.LoadScene("End");
        }

        if (bossHealthBar.GetValue() <= 0)
        {
            Invoke("ChangeToWin", 2f);
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
