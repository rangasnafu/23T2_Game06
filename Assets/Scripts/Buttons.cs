using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    float currentTime = 0f;
    float startingTime = 0f;

    public GameObject bridgeObject;
    //public GameObject revealEffect;

    public GameObject doorToDeactivate;
    public GameObject explosionEffect;

    public GameObject doorToDelete;

    private bool doorDeactivated = false;
    private bool doorDeleted = false;

    void Start()
    {
        currentTime = startingTime;
    }

    void Update()
    {
        currentTime -= Time.deltaTime;

        if (currentTime < 0)
        {
            bridgeObject.SetActive(false);
            //Instantiate(explosionEffect, bridgeObject.transform.position, Quaternion.identity);
        }
    }

    public void BreakDoor()
    {
        Debug.Log("pressed button");
        if (doorToDeactivate != null && !doorDeactivated)
        {
            Vector3 doorPosition = doorToDeactivate.transform.position;

            StartCoroutine(DeactivateAndExplode());
        }
    }

    public void DeleteDoor()
    {
        Debug.Log("pressed button");
        if (doorToDelete != null && !doorDeleted)
        {
            Vector3 doorPosition = doorToDelete.transform.position;

            StartCoroutine(DeleteAndExplode());
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

    private IEnumerator DeleteAndExplode()
    {
        yield return new WaitForSeconds(1.0f); // Wait for 1 second

        Destroy(doorToDelete);
        doorDeleted = true;

        if (explosionEffect != null)
        {
            Instantiate(explosionEffect, doorToDelete.transform.position, Quaternion.identity);
        }
    }

    public void RevealBridge()
    {
        bridgeObject.SetActive(true);
        currentTime = 3f;
        //Instantiate(revealEffect, bridgeObject.transform.position, Quaternion.identity);
    }
}
