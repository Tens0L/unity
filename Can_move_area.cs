using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Can_move_area : MonoBehaviour
{

    [SerializeField] GameObject my_parent;
    private void Start()
    {
        //my_parent = GetComponentInParent<GameObject>();
    }

    public void ivent_reactor()
    {
        //player1のivent_reactorをよびだして、gotoを呼び出してもらう
        my_parent.GetComponent<player1>().ivent_reactor();

    }



}
