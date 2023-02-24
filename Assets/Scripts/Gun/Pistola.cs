using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistola : MonoBehaviour
{
    Interpolator aimToCursor;
    public float aimDelayTime;

    public SpriteRenderer render;
    public Transform gun;
    public Rigidbody2D rb;

    public Animator animator;

    Vector2 direction;

    public float aimHeight;
    public float angularDrag;
    public float linearDrag;

    Vector2 mouseWorldPosition = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        aimToCursor = new Interpolator(aimDelayTime);
    }

    // Update is called once per frame
    void Update()
    {
        mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    public void FixedUpdate()
    {
        //if(!Physics2D.Raycast(gun.position, Vector2.down, aimHeight, LayerMask.GetMask("Walls")) && aimToCursor.IsMinPrecise)
        //{
        //    aimToCursor.ToMax();

        //    Vector2 aimingDirection = (Vector2)gun.position + (mouseWorldPosition - 2 * (Vector2)gun.position) * aimToCursor.Value;
        //    Quaternion aimingRotation = Quaternion.LookRotation(Vector3.forward, Quaternion.Euler(0, 0, 90f) * aimingDirection);
        //    rb.SetRotation(aimingRotation);

        //    if (aimToCursor.IsMaxPrecise)
        //        isAiming = true;
        //}
        //else
        //    isAiming = false;

        if (!Physics2D.Raycast(gun.position, Vector2.down, aimHeight, LayerMask.GetMask("Wall"))/*|| isAiming == true*/)
        {
            direction = mouseWorldPosition - (Vector2)gun.position;
            Quaternion rotation = Quaternion.LookRotation(Vector3.forward, Quaternion.Euler(0,0,90f) * direction);
            rb.SetRotation(rotation);
        }
    }
}
