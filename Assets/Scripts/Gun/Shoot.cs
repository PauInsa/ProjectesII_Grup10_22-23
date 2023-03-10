using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shoot : MonoBehaviour
{
    public Transform gun;
    public Rigidbody2D rb;

    //public AudioSource fireSound, reloadSound;

    public Transform shootPoint;
    public GameObject bullet;
    GameObject goBullet;
    public float bulletSpd;
    float bulletDissapearTime = 5.0f;

    public Transform casePoint;
    public GameObject bulletCase;
    GameObject goBulletCase;
    public float bulletCaseForce;
    float bulletCaseDissapearTime = 60.0f;

    float deltaTimeJump;
    public float jumpTime;
    public bool activateJump;
    public float jumpForce;
    public float downForce = 0.0f;
    public float gunTorque;
    public float recoilForce;
    public float fireRate;
    float deltaTimeFire = 0.0f;

    public float reloadTime;

    public int maxAmmo;
    int ammo;

    bool reloading;
    float deltaTimeReload;

    public bool grounded;

    //public ParticleSystem sparkles;
    

    public bool ableToShoot;

    // Start is called before the first frame update
    void Start()
    {
        ammo = maxAmmo;
        reloading = false;
        ableToShoot = false;
        activateJump = false;
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics2D.Raycast(gun.position, Vector2.down, 1.2f, LayerMask.GetMask("Wall"));

        if (Input.GetMouseButtonDown(0))
        {
            shoot();
        }

        if (Input.GetMouseButtonDown(1))
        {
            Jump();
        }

        if (Input.GetKey(KeyCode.E))
            Reload();

        if (Input.GetKey(KeyCode.A))
            rb.AddTorque(gunTorque , ForceMode2D.Force);
        else if (Input.GetKey(KeyCode.D))
            rb.AddTorque(-gunTorque , ForceMode2D.Force);


        if (activateJump)
        {
            CalculateJump();
            if (grounded)
                activateJump = false;
        }

        if (!grounded)
            activateJump = true;

        //sparkles.transform.position = goBullet.transform.position;  
    }

    public void shoot()
    {

        if (ammo == 0 && !reloading)
            Reload();

        if (!reloading)
        {
            if (Time.time > deltaTimeFire)
            {
                ableToShoot = true;

                //CinemachineMovimientoCamara.Instance.MoverCamara(2.5f, 2.5f, 0.1f);
                //particleSystem.Play();

                deltaTimeFire = Time.time + fireRate;

                goBullet = Instantiate(bullet, shootPoint.position, shootPoint.rotation);
                goBullet.transform.right = gun.transform.right;
                goBullet.GetComponent<Rigidbody2D>().AddForce(goBullet.transform.right * bulletSpd);
                Destroy(goBullet, bulletDissapearTime);

                goBulletCase = Instantiate(bulletCase, casePoint.transform.position, casePoint.rotation);
                goBulletCase.transform.right = casePoint.transform.right;
                goBulletCase.GetComponent<Rigidbody2D>().AddForce(goBulletCase.transform.right * bulletCaseForce);
                goBulletCase.GetComponent<Rigidbody2D>().AddTorque(gunTorque, ForceMode2D.Force);
                Destroy(goBulletCase, bulletCaseDissapearTime);

                recoil();

                ammo--;

                //fireSound.Play();
            }
        }
        else
        {
            if (Time.time > deltaTimeReload)
            {
                ammo = maxAmmo;
                reloading = false;
            }
        }
    }
    public void recoil()
    {
        Vector2 xyVector = new Vector2(gun.transform.right.x, gun.transform.right.y);
        xyVector.Normalize();
        rb.velocity = Vector2.zero;
        downForce = 0.0f;
        rb.AddForce(xyVector * recoilForce, ForceMode2D.Impulse);
    }

    public void Reload()
    {
        reloading = true;
        //reloadSound.Play();
        deltaTimeReload = Time.time + reloadTime;
    }
    void Jump()
    {
        if (grounded)
        {
            activateJump = true;
            deltaTimeJump = Time.time + jumpTime;
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    void CalculateJump()
    {
        float finalForce = downForce * (deltaTimeJump - Time.time);
        rb.AddForce(Vector2.up * finalForce, ForceMode2D.Force);
    }
}


