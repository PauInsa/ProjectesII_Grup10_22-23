using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public float delta = 0.001f;


    [SerializeField] float rightLimit = 6.4f;
    [SerializeField] float leftLimit = -5.9f;
    [SerializeField] float upLimit = 1.4f;

    [SerializeField] float extraY = 0.6f;

    // Update is called once per frame
    void Update()
    {
        Vector3 finalPos;

        finalPos = new Vector3(target.position.x, target.position.y);

        if (target.position.x <= leftLimit)
            finalPos = new Vector3(leftLimit, finalPos.y);
        else if (target.position.x >= rightLimit)
            finalPos = new Vector3(rightLimit, finalPos.y);

        if (target.position.y >= upLimit)
            finalPos = new Vector3(finalPos.x, upLimit);

        finalPos = new Vector3(finalPos.x, finalPos.y + extraY, -10);

        transform.position = Vector3.MoveTowards(transform.position, finalPos, delta);
    }
}
