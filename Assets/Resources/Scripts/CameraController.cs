using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    // Use this for initialization
    public float speed;
    public Transform target;
    public int OffsetZ;
    private Vector3 startPosition;

    private void Awake()
    {
        startPosition = transform.position;
    }

    private void FixedUpdate()
    {
        if (GameController.Instance.state == State.play)
        {
            Vector3 targetCamPos = target.position;
            targetCamPos.z -= OffsetZ;
            targetCamPos.y = 2;
            transform.position = Vector3.Lerp(transform.position, targetCamPos, speed * Time.deltaTime);
        }
    }

    public void reset()
    {
        transform.position = startPosition;
    }
}
