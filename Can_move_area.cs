using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//移動可能エリアでの動きをここにまとめたい
//
//
public class Can_move_area : MonoBehaviour
{
    //移動先のマーカーオブジェクト
    [SerializeField]  GameObject spot_pref;
    //移動先となるマーカーのポジションを保持する
    public Vector3 spot_pos;

    //クリックされたときの動きだけ定義しておく
    public void ivent_reactor(Vector3 spot_v3)
    {

        //移動先spotの場所をクリックイベントから受け取ったvector3を代入
        spot_pref.transform.position = spot_v3;
        //spotの表示
        spot_pref.SetActive(true);
        //spotの場所を記録しておく。移動時に使用する。
        spot_pos = spot_v3;

    }

    public void init()
    {
        //spotを原点に移動して非表示にする
        spot_pref.transform.position = new Vector3(0f, 0f, 0f);
        spot_pref.SetActive(false);

    }



}
