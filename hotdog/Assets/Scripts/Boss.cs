using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private ParticleSystem particle;
    [SerializeField] private float speed;
    [SerializeField] private HealthBar healthBar;

    private int counter;
    

    void Start()
    {
        counter = 0;
    }

    void Update()
    {   
        transform.LookAt(target);

        if (counter == 100)
        {
            Shoot();
            particle.Play();
            counter = 0;
        }
        counter++;

        Debug.Log(healthBar.GetValue());


        
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
       
    }


    
}