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
}
