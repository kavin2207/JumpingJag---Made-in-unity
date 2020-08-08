using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    Rigidbody2D rb;
    public Vector2 force, jump;
    bool Ongrounded = false;
    public Transform playerPosi;
     
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(force);
        if (Input.GetMouseButtonDown(0) && !Ongrounded)
        {
            Debug.Log("dddd");
            rb.velocity = Vector2.up * jump;
            playerPosi.position = playerPosi.position + new Vector3(0,1.3f,0);
            //Ongrounded = true;
        }
        GetComponent<gameEnd>().endGame();

    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.tag == "wall")
        {
            
            transform.Rotate(0, 180f, 0);
            force.x = force.x * -1;
        }
        if (col.transform.tag == "ground")
        {
            Ongrounded = false;
        }
        Debug.Log("dddddssss" + force.x);

    }


}
