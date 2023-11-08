using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public GameObject doorToDeactivate;
    public GameObject explosionEffect;

    private bool doorDeactivated = false;

    private void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Box"))
        {

            Debug.Log("box on pressure plate");
            if (doorToDeactivate != null && !doorDeactivated)
            {
                //Destroy(doorToDeactivate);
                //Instantiate(explosionEffect, transform.position, Quaternion.identity);

                Vector3 doorPosition = doorToDeactivate.transform.position;

                StartCoroutine(DeactivateAndExplode());

                //PlayPressurePlateSound();

                //if (explosionEffect != null)
                //{
                //    Instantiate(explosionEffect, doorToDeactivate.transform.position, Quaternion.identity);
                //}
            }
        }
    }

    //private void PlayPressurePlateSound()
    //{
    //    if (audioSource != null && audioSource.clip != null)
    //    {
    //        audioSource.Play();
    //    }
    //}

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
