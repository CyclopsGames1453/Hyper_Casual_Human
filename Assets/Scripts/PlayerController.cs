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

    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

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
        else if (Input.GetMouseButtonUp(0))
        {
            animator.SetBool("isWalk", false);
        }

        if (isTouch)
        {
            endPosition = Input.mousePosition;

            if (Vector3.Distance(startPosition, endPosition) > 1)
            {
                animator.SetBool("isWalk", true);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, CalculateRotation(), turnSpeed * Time.deltaTime);
                transform.position += transform.forward * moveSpeed * Time.deltaTime;
            }
            else
            {
                animator.SetBool("isWalk", true);
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
