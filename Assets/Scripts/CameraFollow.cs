using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothing = 5f;
    public bool followYAxis = false;
    public Vector3 offset = new Vector3(4f, 4.5f, -10f);

    private void FixedUpdate()
    {
        Vector3 targetPosition = target.position + offset;
        if (!followYAxis)
        {
            targetPosition.y = transform.position.y;

        }
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing * Time.fixedDeltaTime);
        //lerp means linear interpolation
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
