using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCameraValues : MonoBehaviour
{
    public CameraMovement camera;

    public float extraY;
    public float extraX;

    float originalY;
    float originalX;

    private void Start()
    {
        originalX = camera.extraX;   
        originalY = camera.extraY;   
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Gun"))
        {
            camera.extraX = extraX;
            camera.extraY = extraY;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Gun"))
        {
            camera.extraX = originalX;
            camera.extraY = originalY;
        }
    }
}
