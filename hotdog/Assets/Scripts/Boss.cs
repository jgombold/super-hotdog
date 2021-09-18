using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private ParticleSystem particle;
    [SerializeField] private float speed;
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private AudioSource pop;

    public float shootInterval;
    private float timer;
    
    void Start()
    {
        //InvokeRepeating("Shoot",shootInterval, shootInterval);
    }    

    void Update()
    {   
        transform.LookAt(target);
        
        if (PauseMenu.GameIsPaused)
        {
            return;
        }

        timer += Time.deltaTime;
        if ( timer > shootInterval)
        {
            Shoot();
            timer = 0;
        }
        
    }

    void Shoot()
    {
        //GameObject currentBullet = Instantiate(bullet, attackPoint.position,Quaternion.identity);
        //currentBullet.transform.forward = target.position.normalized;
        //Vector3 test = currentBullet.transform.forward;
        //currentBullet.GetComponent<Rigidbody>().AddForce(test * 20f, ForceMode.Impulse);
        Vector3 pos = attackPoint.transform.position;
        Vector3 dir = (target.transform.position - attackPoint.transform.position).normalized;
        //Debug.DrawLine(pos, pos + dir * 10, Color.red, Mathf.Infinity);

        GameObject currentBullet = Instantiate(bullet, attackPoint.position,Quaternion.identity);
        currentBullet.transform.forward = dir;
        currentBullet.GetComponent<Rigidbody>().AddForce(dir * speed, ForceMode.Impulse);
        particle.Play();
        pop.Play();
    }


    
}