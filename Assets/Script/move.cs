using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class move : MonoBehaviour {

    public float moveP = 1f;
    public float jumpP = 5f;
    Rigidbody2D rigid;
    Animator ani;
    Vector3 movement;
    GameObject player;
    bool alive = true;
    bool isJump = false;

    void Start()
    {
        //Camera.main.gameObject.transform.SetParent(this.gameObject.transform);
        player = GameObject.FindGameObjectWithTag("Player");
        rigid = gameObject.GetComponent<Rigidbody2D>();
        ani = this.gameObject.GetComponent<Animator>();
        StartCoroutine("Move");
    }
    void Jump()
    {
        if (!isJump)
        {
            rigid.velocity = Vector2.zero;
            Vector2 jumpVelocity = new Vector2(0, jumpP);
            rigid.AddForce(jumpVelocity, ForceMode2D.Impulse);
        }
        isJump = true;
    }

    private IEnumerator Move()
    {
        do
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            if (Input.GetButtonDown("Jump"))
            {
                Jump();
            }

            if (Input.GetKey(KeyCode.M) && alive == true)
            {
                Scene currentScene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(2);
            }

            if (h < 0)
            {
                ani.SetInteger("state", 1);
                movement = Vector3.left;
                transform.localScale = new Vector3(-7, 7, 0);
            }
            else if (h > 0)
            {
                ani.SetInteger("state", 1);
                movement = Vector3.right;
                transform.localScale = new Vector3(7, 7, 0);
            }
            else if (v < 0 || v > 0)
            {
                ani.SetInteger("state", 1);
                movement = new Vector3(h, 0, 0f);
            }
            else
            {
                ani.SetInteger("state", 0);
                movement = new Vector3(h, v, 0f);
            }

            transform.position += movement * moveP * Time.deltaTime;

            yield return null;
        }
        while (alive == true);

        //StopCoroutine("Move");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "ground")
        {
            isJump = false;
        }

        if (collision.collider.tag == "denger")
        {
            ani.SetInteger("state", 4);
            transform.localScale = new Vector3(7, -7, 0);
            alive = false;
            return;
        }
    }

}
