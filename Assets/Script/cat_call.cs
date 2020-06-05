using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cat_call : MonoBehaviour {

    public GameObject pop;
    public GameObject door;
    Animator ani;
    int n = 0;
    void Start()
    {
        // pop = GameObject.FindGameObjectWithTag("popup");
        if (pop == null)
           Debug.Log("Null");
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (n == 0)
        {
            pop.SetActive(true);
            ani = pop.gameObject.GetComponent<Animator>();
            ani.SetInteger("start", 1);
        }
        Destroy(pop, 12.0f);
        n++;
        door.SetActive(true);
    }
}
