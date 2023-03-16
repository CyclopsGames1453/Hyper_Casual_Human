using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    Transform player;

    [SerializeField] float smoothFactor;

    int quality;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        Vector3 targetPosition = new Vector3(player.position.x, player.position.y + 5.5f, player.position.z - 5f);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPosition, smoothFactor * Time.deltaTime);
        transform.position = smoothedPosition;
    }
}
