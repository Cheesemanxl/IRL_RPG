using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public Animator animator;
    public float speed;
    private Rigidbody2D body;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Create a position Vector from player input
        Vector3 pos = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);

        //Animation Handlers
        animator.SetFloat("Horizontal", pos.x);
        animator.SetFloat("Vertical", pos.y);
        animator.SetFloat("Magnitude", pos.magnitude);

        if (pos.x > 0)
        {
            animator.SetBool("LookRight", true);
            animator.SetBool("LookLeft", false);
        }

        if (pos.x < 0)
        {
            animator.SetBool("LookRight", false);
            animator.SetBool("LookLeft", true);
        }

        if (pos.y > 0)
        {
            animator.SetBool("LookUp", true);
            animator.SetBool("LookDown", false);
        }
        
        if (pos.y < 0)
        {
            animator.SetBool("LookUp", false);
            animator.SetBool("LookDown", true);
        }

        //Set player position equal to input vector

        body.MovePosition(new Vector2((transform.position.x + pos.x * speed * Time.deltaTime), transform.position.y + pos.y * speed * Time.deltaTime));
        //transform.position = transform.position + pos * Time.deltaTime * speed;
    }

}
