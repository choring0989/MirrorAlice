using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class climd : MonoBehaviour
{ 
    public float speed = 4;

    void OnTriggerStay2D(Collider2D other)
    {
        other.GetComponent<Rigidbody2D>().gravityScale = 0;
        if (other.tag == "Player" && Input.GetKey(KeyCode.Q))
        {
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);

        }
        else if (other.tag == "Player" && Input.GetKey(KeyCode.W))
        {
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speed);

        }
        else if (other.tag == "Player")
        {
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        other.GetComponent<Rigidbody2D>().gravityScale = 1f;
    }
}
