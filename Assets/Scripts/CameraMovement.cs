using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;


    [SerializeField] float rightLimit = 6.4f;
    [SerializeField] float leftLimit = -5.9f;
    [SerializeField] float y = 1.4f;


    // Update is called once per frame
    void Update()
    {
        Vector3 finalPos;

        finalPos = new Vector2(target.position.x, target.position.y);

        if (target.position.x <= leftLimit)
            finalPos.x = leftLimit;
        else if (target.position.x >= rightLimit)
            finalPos.x = rightLimit;

        finalPos = new Vector3(finalPos.x, y, -10);

        transform.position = finalPos;
    }
}
