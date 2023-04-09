using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shoot : MonoBehaviour
{
    public PoolRb casePool;

    public Transform gun;
    public Rigidbody2D rb;
    public Animator anim;
    //public AudioSource fireSound, reloadSound;

    public Transform standingMassCenter;
    public Transform normalMassCenter;

    public Transform shootPoint;
    public GameObject bullet;
    GameObject goBullet;
    public float bulletSpd;
    float bulletDissapearTime = 5.0f;

    public Transform casePoint;
    public float bulletCaseForce;

    public float jumpForce;
    public float gunTorque;
    public float recoilForce;
    public float fireRate;
    float deltaTimeFire = 0.0f;

    public float reloadTime;

    public TextMeshProUGUI ammoText;
    public int maxAmmo;
    int ammo;

    bool reloading;
    float deltaTimeReload;

    public bool grounded;

    public bool ableToShoot;

    bool cheated;

    public Transform centerMassViewer;
    // Start is called before the first frame update
    void Start()
    {
        ammo = maxAmmo;
        reloading = false;
        ableToShoot = false;
        cheated = false;

        UpdateMassCenter();
    }

    void UpdateMassCenter()
    {
        float angle = Vector2.Angle(gun.transform.right, Vector2.right);

        if (grounded && angle <= 90.0f)
            rb.centerOfMass = standingMassCenter.localPosition;
        else
            rb.centerOfMass = normalMassCenter.localPosition;
        rb.WakeUp();

        centerMassViewer.localPosition = rb.centerOfMass;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMassCenter();

        grounded = Physics2D.Raycast(gun.position, Vector2.down, 1.2f, LayerMask.GetMask("Wall"));

        if (Input.GetMouseButtonDown(0))
        {
            shoot();
        }

        if (Input.GetMouseButtonDown(1))
        {
            Jump();
        }

        if (Input.GetKey(KeyCode.W) && !reloading && ammo != maxAmmo)
            Reload();

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (cheated)
                maxAmmo -= 30;
            else
                maxAmmo += 30;

            cheated = !cheated;
        }

        if (Input.GetKey(KeyCode.A))
            rb.AddTorque(gunTorque* Time.deltaTime , ForceMode2D.Impulse);
        else if (Input.GetKey(KeyCode.D))
            rb.AddTorque(-gunTorque * Time.deltaTime , ForceMode2D.Impulse);


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
                ableToShoot = true;

                //CinemachineMovimientoCamara.Instance.MoverCamara(2.5f, 2.5f, 0.1f);
                //particleSystem.Play();

                deltaTimeFire = Time.time + fireRate;

                goBullet = Instantiate(bullet, shootPoint.position, shootPoint.rotation);
                goBullet.transform.right = gun.transform.right;
                goBullet.GetComponent<Rigidbody2D>().AddForce(goBullet.transform.right * bulletSpd);
                Destroy(goBullet, bulletDissapearTime);

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
    public void recoil()
    {
        Vector2 xyVector = new Vector2(gun.transform.right.x, gun.transform.right.y);
        xyVector.Normalize();
        //rb.velocity = Vector2.zero;
        rb.AddForce(xyVector * recoilForce, ForceMode2D.Force);
    }

    public void Reload()
    {
        for(int i = 0; i < ammo; i++)
        {
            SpawnBulletCase();
        }
        ammo = 0;
        anim.SetTrigger("Reload");
        anim.SetInteger("Ammo", ammo);
        reloading = true;
        //reloadSound.Play();
        deltaTimeReload = Time.time + reloadTime;
    }
    void SpawnBulletCase()
    {
        Rigidbody2D caseRb = casePool.Spawn();

        caseRb.GetComponent<DissapearTime>().SetPool(casePool);

        caseRb.transform.position = casePoint.position;
        caseRb.transform.rotation = casePoint.rotation;
        caseRb.AddForce(new Vector2(Random.Range(-0.5f, 0.5f), 1f) * bulletCaseForce);
        caseRb.AddTorque(gunTorque/10, ForceMode2D.Force);
    }
    void Jump()
    {
        if (grounded)
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}


