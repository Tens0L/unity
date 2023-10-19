using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Can_move_area : MonoBehaviour
{

    [SerializeField] GameObject my_parent;
    [SerializeField]  GameObject spot_pref;
    public Vector3 spot_pos;

    public void ivent_reactor(Vector3 spot_v3)
    {


        //player1のivent_reactorをよびだして、gotoを呼び出してもらう
        //my_parent.GetComponent<player1>().ivent_reactor();

        spot_pref.transform.position=spot_v3;
        spot_pref.SetActive(true);
        spot_pos = spot_v3;

    }

    public void init()
    {

        spot_pref.SetActive(false);

    }



}
