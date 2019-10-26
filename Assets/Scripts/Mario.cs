using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mario : MonoBehaviour
{
    public float speed;
    public float jumpSpeed;
    private Rigidbody2D rigid2d;
    private int NUM_JUMPS = 2;

    // Start is called before the first frame update
    void Start()
    {
        speed = 10;
        jumpSpeed = 350;
        rigid2d = GetComponent<Rigidbody2D>();
        GetComponent<Animator>().SetInteger("Jumping", 0);
    }

    bool checkJump()
    {
        return (GetComponent<Animator>().GetInteger("Jumping") < NUM_JUMPS);
    }

    void jump()
    {
        int jumping = GetComponent<Animator>().GetInteger("Jumping") + 1;
        rigid2d.AddForce(new Vector2(0, jumpSpeed));
        GetComponent<Animator>().SetInteger("Jumping",jumping);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && checkJump())
        {
            jump();
        }
        
        
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                rigid2d.AddForce(new Vector2(speed, 0));
                GetComponent<SpriteRenderer>().flipX = false;
                GetComponent<Animator>().SetBool("Running", true);
            }
            else
            {

                rigid2d.AddForce(new Vector2(-speed, 0));
                GetComponent<SpriteRenderer>().flipX = true;
                GetComponent<Animator>().SetBool("Running", true);
            }
        }
        else
            GetComponent<Animator>().SetBool("Running", false);
        processPos();
    }
    void processPos()
    {
        Vector2 pos = transform.position;
        if (pos.y < -20)
        {
            pos.y = -1;
            pos.x = -8;
        }
        transform.position = pos;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            GetComponent<Animator>().SetInteger("Jumping", 0);
        }
    }
}
