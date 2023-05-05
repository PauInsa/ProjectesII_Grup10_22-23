using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolControl : MonoBehaviour
{
    public PauseMenu pause;
    public Shoot shoot;
    public PistolMovement movement;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pause.isPaused == false)
        {
            if (Input.GetMouseButtonDown(0))
                shoot.shoot();

            if (Input.GetMouseButtonDown(1))
                movement.Jump();

            if (Input.GetKey(KeyCode.W))
                shoot.Reload();

            if (Input.GetKeyDown(KeyCode.P))
                shoot.Cheat();

            if (Input.GetKey(KeyCode.A))
                movement.Rotate(false);
            else if (Input.GetKey(KeyCode.D))
                movement.Rotate(true);
        }
    }
}
