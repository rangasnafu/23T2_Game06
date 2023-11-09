using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public GameObject dialogueBoxUI;
    public GameObject dialogueUI; // Assign your UI GameObject in the Inspector

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            dialogueUI.SetActive(true);
            dialogueBoxUI.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        dialogueUI.SetActive(false);
        dialogueBoxUI.SetActive(false);
    }
}
