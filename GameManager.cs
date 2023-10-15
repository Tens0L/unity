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

        //前にクリックしたオブジェクトの情報をリセットする
            //if (clicked_gob is not null)
            //{
            //    if (clicked_gob.GetComponent<player1>() is not null)
            //    {
            //        clicked_gob.GetComponent<player1>().visible_field_panel(false);
            //    }
            //}

        //前にクリックしたオブジェクトを空にしておく
        clicked_gob = null;

        //Rayをとばしてgameobjectを検出する
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(ray,out hit))
        {
            clicked_gob = hit.collider.gameObject;
        }

        //player1のパネルを表示する
        if(clicked_gob.GetComponent<player1>() is not null)
        {
            clicked_gob.GetComponent<player1>().visible_field_panel(true);

        }



    }





}




