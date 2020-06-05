using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumping : MonoBehaviour {

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Rigidbody2D rigid = other.gameObject.GetComponent<Rigidbody2D>();
            rigid.velocity = Vector2.zero;
            Vector2 jumpVelocity = new Vector2(0, 10);
            rigid.AddForce(jumpVelocity, ForceMode2D.Impulse);
        }
    }
}
