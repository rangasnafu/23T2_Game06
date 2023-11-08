using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{
    public GameObject box;
    public GameObject interactivebox;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            box.SetActive(false);
            interactivebox.SetActive(true);
        }
    }
}
