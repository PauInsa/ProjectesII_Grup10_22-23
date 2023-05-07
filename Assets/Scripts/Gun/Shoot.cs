using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shoot : MonoBehaviour
{
    public Transform gun;
    public Rigidbody2D rb;

    public Animator anim;
    public AudioSource fireSound;
    public AudioSource reloadSound;

    public Transform shootPoint;
    public GameObject bullet;
    GameObject goBullet;
    public float bulletSpd;
    float bulletDissapearTime = 5.0f;

    public PoolRb casePool;
    public Transform casePoint;
    public float bulletCaseForce;
    public float caseTorque;

    public float recoilForce;
    public float fireRate;
    float deltaTimeFire = 0.0f;

    public float reloadTime;
    bool reloading;
    float deltaTimeReload;

    public TextMeshProUGUI ammoText;
    public int maxAmmo;
    int ammo;

    bool cheated;

    void Start()
    {
        ammo = maxAmmo;
        reloading = false;
        cheated = false;
    }

    void Update()
    {
        if (Time.time > deltaTimeReload && reloading)
        {
            ammo = maxAmmo;
            anim.SetInteger("Ammo", ammo);
            reloading = false;
        }

        ammoText.text = ("Ammo: "+ ammo);
    }

    public void shoot()
    {
        if (!reloading)
        {
            if (Time.time > deltaTimeFire)
            {
                //CinemachineMovimientoCamara.Instance.MoverCamara(2.5f, 2.5f, 0.1f);
                //particleSystem.Play();

                deltaTimeFire = Time.time + fireRate;

                goBullet = Instantiate(bullet, shootPoint.position, shootPoint.rotation);
                goBullet.transform.right = gun.transform.right;
                goBullet.GetComponent<Rigidbody2D>().AddForce(goBullet.transform.right * bulletSpd);
                Destroy(goBullet, bulletDissapearTime);

                fireSound.Play();

                SpawnBulletCase();

                recoil();
                anim.SetTrigger("Shoot");
                ammo--;
                anim.SetInteger("Ammo", ammo);

                if (ammo == 0)
                    Reload();
            }
        }
    }
    void recoil()
    {
        Vector2 xyVector = new Vector2(gun.transform.right.x, gun.transform.right.y);
        xyVector.Normalize();
        //rb.velocity = Vector2.zero;
        rb.AddForce(xyVector * recoilForce, ForceMode2D.Force);
    }

    public void Reload()
    {
        if (!reloading && ammo != maxAmmo)
        {
            for (int i = 0; i < ammo; i++)
            {
                SpawnBulletCase();
            }
            ammo = 0;
            anim.SetTrigger("Reload");
            anim.SetInteger("Ammo", ammo);
            reloading = true;
            reloadSound.Play();
            deltaTimeReload = Time.time + reloadTime;
        }
    }
    void SpawnBulletCase()
    {
        Rigidbody2D caseRb = casePool.Spawn();

        caseRb.GetComponent<DissapearTime>().SetPool(casePool);

        caseRb.transform.position = casePoint.position;
        caseRb.transform.rotation = casePoint.rotation;
        caseRb.AddForce(new Vector2(Random.Range(-0.5f, 0.5f), 1f) * bulletCaseForce);
        caseRb.AddTorque(caseTorque, ForceMode2D.Force);
    }

    public void Cheat()
    {
        if (cheated)
            maxAmmo -= 30;
        else
            maxAmmo += 30;

        cheated = !cheated;
    }
}


