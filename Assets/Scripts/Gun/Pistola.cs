using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistola : MonoBehaviour
{
    public SpriteRenderer render;
    public Transform gun;
    public Rigidbody2D rb;

    public Animator animator;

    Vector2 direction;

    Vector2 mouseWorldPosition = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
