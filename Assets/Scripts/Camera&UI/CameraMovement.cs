using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;

    [SerializeField] float rightLimit = 6.4f;
    [SerializeField] float leftLimit = -5.9f;
    [SerializeField] float upLimit = 6.4f;
    [SerializeField] float downLimit = -5.9f;

    public float extraY;
    public float extraX;

    [SerializeField] float fixedY;
    [SerializeField] float fixedX;
    [SerializeField] bool fixY;
    [SerializeField] bool fixX;


    // Update is called once per frame
    void Update()
    {
        Vector3 finalPos;

        finalPos = new Vector2(target.position.x, target.position.y);

        if (target.position.x <= leftLimit)
            finalPos.x = leftLimit;
        else if (target.position.x >= rightLimit)
            finalPos.x = rightLimit;

        if (target.position.y <= downLimit)
            finalPos.y = downLimit;
        else if (target.position.y >= upLimit)
            finalPos.y = upLimit;

        if (fixX)
            finalPos.x = fixedX;

        if (fixY)
            finalPos.y = fixedY;


        finalPos = new Vector3(finalPos.x + extraX, finalPos.y + extraY, -10);

        transform.position = finalPos;
    }
}
