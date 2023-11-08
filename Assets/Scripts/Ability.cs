using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Ability : MonoBehaviour
{
    //public GameObject box;
    //public GameObject box2;
    //public GameObject interactiveboxPrefab;
    
    public GameObject aura;

    float currentTime = 0f;
    float startingTime = 0f;

    void Start()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;

        if (currentTime < 0)
        {
            aura.SetActive(false);
            //box.SetActive(true);
            //box2.SetActive(true);
            //Destroy(interactiveboxPrefab);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            //box.SetActive(false);
            //box2.SetActive(false);
            //Instantiate(interactiveboxPrefab, box.transform.position, Quaternion.identity);
            aura.SetActive(true);

            currentTime = 5f;
        }
    }
}
