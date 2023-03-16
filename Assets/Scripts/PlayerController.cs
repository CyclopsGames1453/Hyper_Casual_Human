using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float turnSpeed;

    bool isTouch;

    Vector3 startPosition;
    Vector3 endPosition;

    void Update()
    {
        isTouch = false;

        if (Input.GetMouseButtonDown(0))
        {
            startPosition = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            isTouch = true;
        }

        if (isTouch)
        {
            endPosition = Input.mousePosition;

            if (Vector3.Distance(startPosition, endPosition) > 1)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, CalculateRotation(), turnSpeed * Time.deltaTime);
                transform.position += transform.forward * moveSpeed * Time.deltaTime;
            }
        }
    }

    Quaternion CalculateRotation()
    {
        Quaternion temp = Quaternion.LookRotation(CalculateDirection(), Vector3.up);
        return temp;
    }

    Vector3 CalculateDirection()
    {
        Vector3 temp = (endPosition - startPosition).normalized;
        temp.z = temp.y;
        temp.y = 0;
        return temp;
    }
}
