using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    public GameObject doorToDeactivate;
    public GameObject explosionEffect;

    private bool doorDeactivated = false;

    public void BreakDoor()
    {
        Debug.Log("pressed button");
        if (doorToDeactivate != null && !doorDeactivated)
        {
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
