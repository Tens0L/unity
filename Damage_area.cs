using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage_area : MonoBehaviour
{

    private int my_parent_id;
    private void Start()
    {
        my_parent_id = GetComponentInParent<player1>().char_id;


    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            if (other.GetComponent<player1>().char_id != my_parent_id)
            {
                Debug.Log(other);
                Char_dict.cdict[other.GetComponent<player1>().char_id]._HP -= 10;
            }
        }
    }

}
