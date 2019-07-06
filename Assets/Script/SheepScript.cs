using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepScript : MonoBehaviour
{
    public Transform target;
    public float speed = 0.0f;
    public float minDistance = 3f;

    private float range;
    private bool inRange;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        range = Vector2.Distance(transform.position, target.position);
        //Debug.Log(range);

        if (inRange == true)
        {
            Debug.Log("RUN AWAY!!!");
            transform.position = Vector2.MoveTowards(transform.position, target.position, -1 * speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Hipster")
        {
            Debug.Log("Enter Trigger!");
            inRange = true;
        }
        
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Hipster")
        {
            Debug.Log("Exit Trigger!");
            inRange = false;
        }
    }
}
