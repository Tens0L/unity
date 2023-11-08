using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using DG.Tweening;

//  #------#  user - game interface  #------#  


public class GameManager : MonoBehaviour
{

    [SerializeField] private InputAction _action;
    [SerializeField] GameObject main_camera_root;


    private bool before_clicked_gob_is_player;
    private void Start()
    {
        before_clicked_gob_is_player = false;

    }
    // インプットアクションのシステムを有効化したい
    private void OnEnable()
    {
        // Actionのコールバックを登録
        //  started / performed / canceled
        _action.performed += OnPerformed;

        // InputActionを有効化
        // これをしないと入力を受け取れない
        _action?.Enable();

    }

    // インプットアクションのシステムを無効化したい
    private void OnDisable()
    {
        // Actionのコールバックを解除
        _action.performed -= OnPerformed;

        // 自身が無効化されるタイミングなどで
        // Actionを無効化する必要がある
        _action?.Disable();

    }


    private GameObject clicked_gob; //新しいクリックオブジェクト
    private GameObject before_gob; // 1つ前のクリックオブジェクト
    // コールバックを受け取ったときの処理をしたい
    private void OnPerformed(InputAction.CallbackContext context)
    {
        var value = context.ReadValue<float>();


        before_clicked_gob_is_player = false;

        //前にクリックしたオブジェクトのパネルをALL　OFF　しておく
        if (clicked_gob)
        {
            if (clicked_gob.GetComponent<player1>())
            {

                before_clicked_gob_is_player = true;
                //前にクリックしたオブジェクトを保存

                

            }
        }
        //

        before_gob = clicked_gob;


        //Rayをとばしてgameobjectを検出する
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();
        if (EventSystem.current.IsPointerOverGameObject()) return;
        if (Physics.Raycast(ray,out hit))
        {
            
            //
            clicked_gob = hit.collider.gameObject;
            //さっきもplayerだった場合ALL OFFをかける
            if (clicked_gob.GetComponent<player1>())
            {

                    if (before_clicked_gob_is_player) //さっきのgob
                    {
                        before_gob.GetComponent<player1>().all_panel_visible_OFF();
                    }
            }
        }
        else
        {
            return;
        }

            //camera move
            main_camera_root.transform.DOMove(hit.point, 1f);
            //瞬間移動パターン
            //main_camera_root.transform.position=hit.point;

            //ここには何をクリックしたかだけを呼び出すようにしたい
            //
            //player1をくりっくした　ことだけ伝えたい
            if (clicked_gob.GetComponent<player1>() is not null)
            {
                clicked_gob.GetComponent<player1>().ivent_reactor();
            }


            //can move areaをクリックしたことだけ伝える
            if (clicked_gob.name == "can_move_area")
            {
                clicked_gob.GetComponent<Can_move_area>().ivent_reactor(hit.point);
            }
            //can act areaをクリックしたことだけ伝える
            if (clicked_gob.name == "can_act_area")
            {
                clicked_gob.GetComponent<Can_act_area>().ivent_reactor(hit.point);
            }
        

        //クリック系まとめ　ここまで

    }





}




