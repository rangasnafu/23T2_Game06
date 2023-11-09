using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoBoxPressurePlate : MonoBehaviour
{
    public GameObject doorToDeactivate;
    public GameObject explosionEffect;

    private bool box1Inside;
    private bool box2Inside;

    private bool doorDeactivated = false;

    private void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Box"))
        {
            box1Inside = true;
            TryOpenDoor();
        }
        else if (other.CompareTag("Box2"))
        {
            box2Inside = true;
            TryOpenDoor();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Box"))
        {
            box1Inside = false;
        }
        else if (other.CompareTag("Box2"))
        {
            box2Inside = false;
        }
    }

    private void TryOpenDoor()
    {
        if (box1Inside && box2Inside && !doorDeactivated)
        {
            //Destroy(doorToDeactivate);
            //Instantiate(explosionEffect, transform.position, Quaternion.identity);

            Vector3 doorPosition = doorToDeactivate.transform.position;

            StartCoroutine(DeactivateAndExplode());
        }
    }

    private IEnumerator DeactivateAndExplode()
    {
        yield return new WaitForSeconds(1.0f); // Wait for 1 second

        Destroy(doorToDeactivate);
        doorDeactivated = true;

        if (explosionEffect != null)
        {
            Instantiate(explosionEffect, doorToDeactivate.transform.position, Quaternion.identity);
        }
    }
}
