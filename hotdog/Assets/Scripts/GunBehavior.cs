using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Based off of tutorial at https://youtu.be/wZ2UUOC17AY

public class GunBehavior : MonoBehaviour
{
    //bullet
    public GameObject bullet;

    //bullet force
    public float shootForce, upwardForce;

    //gun stats
    public float timeBetweenShooting, spread, reloadTime, timeBetweenShots;
    public int magazineSize, bulletsPerTap;
    public bool allowButtonHold;

    int bulletsLeft, bulletsShot;

    //bools
    bool shooting, readyToShoot, reloading;

    //References
    public Camera fpsCam;
    public Transform attackPoint;
    public ParticleSystem muzzleFlash;

    //bug fixing
    public bool allowInvoke = true;

    //audio
    private AudioSource gunShot;

    private void Awake()
    {
        //make sure mag is full
        bulletsLeft = magazineSize;
        readyToShoot = true;

        gunShot = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {   
        //prevent shooting while in pausemenu
        if (PauseMenu.GameIsPaused)
        {
            return;
        }
        MyInput();
    }

    private void MyInput()
    {
        //check if allowed to hold down fire button
        if (allowButtonHold)
        {
            shooting = Input.GetKey(KeyCode.Mouse0);
        }
        else
        {
            shooting = Input.GetKeyDown(KeyCode.Mouse0);
        }


        //shooting
        if (readyToShoot && shooting)
        {
            //set bullets shot to 0
            bulletsShot = 0;

            Shoot();
        }
    }

    private void Shoot()
    {
        readyToShoot = false;

        muzzleFlash.Play();
        gunShot.Play();

        //Find the exact hit position using a raycast
        Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        //check if ray hit something
        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
        {
            targetPoint = hit.point;
        }
        else
        {
            //hits nothing, just shoot out at a point far away
            targetPoint = ray.GetPoint(75);
        }

        //calculate direction from attackPoint to targetPoint
        Vector3 directionWithoutSpread = targetPoint - attackPoint.position;

        //not gonna use spread


        //instantiate bullet/projectile
        //quaternion.identity means no rotation
        GameObject currentBullet = Instantiate(bullet, attackPoint.position,Quaternion.identity);
        //Rotate bullet to shoot direction
        currentBullet.transform.forward = directionWithoutSpread.normalized;

        //add force
        currentBullet.GetComponent<Rigidbody>().AddForce(directionWithoutSpread.normalized * shootForce, ForceMode.Impulse);
        //if you want bounce
        //currentBullet.GetComponent<Rigidbody>().AddForce(fpsCam.transform.up * upwardForce, ForceMode.Impulse);

        bulletsLeft--;
        bulletsShot++;

        //Invoke ResetShot
        if (allowInvoke)
        {
            Invoke("ResetShot", timeBetweenShooting);
            allowInvoke = false;
        }
    }

    private void ResetShot()
    {
        readyToShoot = true;
        allowInvoke = true;
    }

    //not gonna have reload
}
