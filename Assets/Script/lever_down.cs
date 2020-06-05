using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lever_down : MonoBehaviour
{
    Animator ani;
    public GameObject stone_tlie;
    public GameObject water_tlie;
    public GameObject door;
    int flag = 1;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player" && Input.GetKey(KeyCode.Q))
        {
            ani = this.gameObject.GetComponent<Animator>();
            ani.SetInteger("lever", 1);
            door.SetActive(true);
            flag++;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (flag % 2 == 0) {
            ani.SetInteger("lever", 0);
            stone_tlie.GetComponent<Collider2D>().enabled = false;
            water_tlie.GetComponent<Collider2D>().enabled = true;
        }
        else
        {
            ani.SetInteger("lever", 0);
            stone_tlie.GetComponent<Collider2D>().enabled = true;
            water_tlie.GetComponent<Collider2D>().enabled = false;
        }
    }
}
