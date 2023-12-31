using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public float speed;
    private Transform target;

    //float currentTime = 0f;
    //float startingTime = 0f;

    private float horizontal;
    private bool isFacingRight = true;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("FollowPoint").GetComponent<Transform>();
        //currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        Flip();

        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        //currentTime -= Time.deltaTime;

        //if (currentTime < 0)
        //{
        //    target = GameObject.FindGameObjectWithTag("FollowPoint").GetComponent<Transform>();
        //    transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        //}

        //if (Input.GetKeyDown(KeyCode.F))
        //{
        //    //target = GameObject.FindGameObjectWithTag("AbilityFollow").GetComponent<Transform>();
        //    //transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        //    currentTime = 5;
        //}
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
