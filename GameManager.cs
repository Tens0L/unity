using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
//  #------#  user - game interface  #------#  


public class GameManager : MonoBehaviour
{

    [SerializeField] private InputAction _action;
    private GameObject clicked_gob;

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

    // コールバックを受け取ったときの処理をしたい
    private void OnPerformed(InputAction.CallbackContext context)
    {
        var value = context.ReadValue<float>();


        //前にクリックしたオブジェクトを空にしておく
        clicked_gob = null;

        //Rayをとばしてgameobjectを検出する
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(ray,out hit))
        {
            clicked_gob = hit.collider.gameObject;
        }
        else
        {
            //Debug.Log("nothing");
            return;
        }

        //Debug.Log(hit.point);
        

        //ここには何をクリックしたかだけを呼び出すようにしたい

        //player1をくりっくした　ことだけ伝えたい
        if(clicked_gob.GetComponent<player1>() is not null)
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




    }





}




