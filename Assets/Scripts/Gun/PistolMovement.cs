using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolMovement : MonoBehaviour
{
    public Transform gun;
    public Rigidbody2D rb;

    public Transform standingMassCenter;
    public Transform normalMassCenter;

    public float jumpForce;
    public float gunTorque;

    public bool grounded;

    public Transform centerMassViewer;

    // Start is called before the first frame update
    void Start()
    {
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
    }

    public void Jump()
    {
        if (grounded)
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    public void Rotate(bool toRight)
    {
        if(toRight)
            rb.AddTorque(-gunTorque * Time.deltaTime, ForceMode2D.Impulse);
        else
            rb.AddTorque(gunTorque * Time.deltaTime, ForceMode2D.Impulse);
    }
}
