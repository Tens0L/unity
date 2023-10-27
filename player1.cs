using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;


// this is git hub test 2023 10- 15
//   thank you! hello from iphone

public class player1 : MonoBehaviour
{
    [SerializeField] GameObject field_panel;
    [SerializeField] GameObject ok_cancel_panel;
    [SerializeField] GameObject can_move_area;
    [SerializeField] GameObject can_act_area;
    public int char_id;
    private string my_state;
    private void Start()
    {
        my_state = "stanby";
    }
    public void ivent_reactor()
    {
        if (my_state == "stanby") { visible_field_panel(true); }
        if (my_state == "move_set") { ok_cancel_panel.SetActive(true); }//go_to_spot(); }
        if (my_state == "action") { action_for_spot(); }

    }

    public void ok_cancel_reactor(bool t_or_f)
    {
        //can move area のspot置いた状態で ok/cancel を選択
        go_to_spot(t_or_f);




    }


    //キャラクター用のメニューパネルを表示したい
    private void visible_field_panel(bool t_or_f)
    {
        //パネルを表示・非表示する
        field_panel.SetActive(t_or_f);

    }

    //可動範囲を表示したい
    public void visible_can_move_area(bool t_or_f)
    {
        //動けるエリアに相当するGameobjectを表示・非表示する
        can_move_area.SetActive(t_or_f);

        //move_set状態にする
        my_state = "move_set";

        //メニューは非表示にする
        field_panel.SetActive(false);

    }

    //移動したい
    private void go_to_spot(bool t_or_f)
    {
        if (t_or_f)
        {
            //agentを宣言しておく
            var myAgent = GetComponent<NavMeshAgent>();
            //移動する
            myAgent.SetDestination(can_move_area.GetComponent<Can_move_area>().spot_pos);
            //移動可能エリアを初期化してもらう
            can_move_area.GetComponent<Can_move_area>().init();

            //mystateをstandbyにする
            my_state = "stanby";

            //動けるエリアを非表示にする
            can_move_area.SetActive(false);

            //パネルを非表示にする
            field_panel.SetActive(false);
            ok_cancel_panel.SetActive(false);
        }
        else{
            Debug.Log("goto is cancel");
            field_panel.SetActive(true);
            ok_cancel_panel.SetActive(false);
        }

        //navMeshを焼きなおししたいがこれだとエラー
        //field.GetComponent<NavMeshBuildSource>();
    }

    //攻撃範囲を表示したい
    public void visible_can_act_area(bool t_or_f)
    {
        //攻撃エリアを表示する
        can_act_area.SetActive(true);
        //
        my_state = "action";


    }
    //actしたい
    private void action_for_spot()
    {

        Debug.Log("ATACK!!");
        //actionする
        var myAgent = GetComponent<NavMeshAgent>();
        var tmp_v3 = transform.position;
        myAgent.speed = 10f;
        myAgent.SetDestination(can_act_area.GetComponent<Can_act_area>().spot_pos);
        //myAgent.SetDestination(tmp_v3);


        //mystateをstandbyにする
        my_state = "stanby";
        //action範囲を非表示にする
        can_act_area.SetActive(false);
        //パネルを非表示する
        field_panel.SetActive(false);


    }






}
