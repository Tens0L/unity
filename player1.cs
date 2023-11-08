using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using TMPro;
using DG.Tweening;


// this is git hub test 2023 10- 15
//   thank you! hello from iphone

public class player1 : MonoBehaviour
{
    [SerializeField] GameObject field_panel;
    [SerializeField] GameObject ok_cancel_panel;
    [SerializeField] GameObject status_panel;
    [SerializeField] GameObject can_move_area;
    [SerializeField] GameObject can_act_area;
    [SerializeField] GameObject damage_area;
    public int char_id;
    private string my_state;
    public bool active_turn;

    private void Start()
    {
        my_state = "stanby";
        active_turn = false;

        //refresh_display_player_status();

    }
    //別のものをくりっくしたときに表示をオフにしたい
    //
    //
    public void all_panel_visible_OFF()
    {

        //ALL OFF
            field_panel.SetActive(false);
            ok_cancel_panel.SetActive(false);
            status_panel.SetActive(false);
            can_act_area.SetActive(false);
            can_move_area.SetActive(false);

        //ついでに
        my_state = "stanby";

    }
    // status panel
    //
    //
    private void refresh_display_player_status()
    {
        Debug.Log(Char_dict.cdict[char_id]._name);
        status_panel.GetComponent<Status_display>().update_display(Char_dict.cdict[char_id]);
    }

    public void ivent_reactor()
    {
        //基本的にパネルのONOFFだけおこなう
        //
        //
        if (my_state == "stanby") {
            all_panel_visible_OFF();
            //player情報の表示を更新
            refresh_display_player_status();
            //statusパネルを呼び出す
            status_panel.SetActive(true);
        }

        if (my_state == "stanby" && active_turn){field_panel.SetActive(true);}
        if (my_state == "move_set") { ok_cancel_panel.SetActive(true); }//go_to_spot(); }
        if (my_state == "action_set") { ok_cancel_panel.SetActive(true); }//action_for_spot(); }

    }

    


    public void ok_cancel_reactor(bool t_or_f)
    {
        if (t_or_f == true)
        {
            Debug.Log("ok!");

            if (my_state == "move_set")
            {
                //can move area のspot置いた状態で ok/cancel を選択
                go_to_spot();
            }
            if (my_state == "action_set")
            {
                //can act area spot置いた状態でok/cancel を選択
                action_for_spot();
            }
        }
        else {
            Debug.Log("cancel");
            all_panel_visible_OFF();
            my_state = "stanby";
        }

    }


    //可動範囲を表示したい
    public void visible_can_move_area()
    {
        //動けるエリアに相当するGameobjectを表示・非表示する
        can_move_area.SetActive(true);
        can_move_area.GetComponent<Can_move_area>().init();

        //move_set状態にする
        my_state = "move_set";

        //メニューは非表示にする
        field_panel.SetActive(false);

    }
    //攻撃範囲を表示したい
    public void visible_can_act_area()
    {
        //攻撃エリアを表示する
        can_act_area.SetActive(true);
        can_act_area.GetComponent<Can_act_area>().init();

        //
        my_state = "action_set";
        //
        field_panel.SetActive(false);


    }

    //移動したい
    private void go_to_spot()
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
            status_panel.SetActive(false);
        


        //navMeshを焼きなおししたいがこれだとエラー
        //field.GetComponent<NavMeshBuildSource>();
    }



    //actしたい
    private void action_for_spot()
    {

            Debug.Log("ATACK!!");
        //actionする
        //var myAgent = GetComponent<NavMeshAgent>();
        //myAgent.SetDestination(can_act_area.GetComponent<Can_act_area>().spot_pos);
        //can_act_area.GetComponent<Can_act_area>().init();
        //

        //ダメージエリアON
        damage_area.SetActive(true);


            Vector3 pos1 = gameObject.transform.position;
            Vector3 pos2 = can_act_area.GetComponent<Can_act_area>().spot_pos;
            //DoMoveによるアクション
            damage_area.transform.DOMove(pos2,0.2f).OnComplete(Action_complete_func);
        

            //mystateをstandbyにする
            my_state = "stanby";
            //action範囲を非表示にする
            can_act_area.SetActive(false);
            //パネルを非表示する
            field_panel.SetActive(false);
            ok_cancel_panel.SetActive(false);
            status_panel.SetActive(false);

        


        }
    //DoMoveによる処理の後処理
    private void Action_complete_func()
    {
        //もとの位置に戻す
        //damage_area.transform.DOMove(transform.position, 0.2f);

        //瞬間移動でよい
        damage_area.transform.position= transform.position;
        //ダメージエリアOFF
        damage_area.SetActive(false);

    }

}
