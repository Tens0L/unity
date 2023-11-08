using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//ここはあまり触ることはないデータベースエリア
//基本的に問い合わせだけ
//というふうにしようと思っていたが、途中で数値を更新したりしたいので
//ここの値はキャラクター情報をまとめて記録するエリアにすることにする
//




public class Status_list
{
    public string _name;
    public int _id;
    public float _HP;
    public float _ATK;
    public float _DEF;
    public float _SPD;

}

public class Char_dict : MonoBehaviour
{
    
    public static Dictionary<int, Status_list> cdict = new Dictionary<int, Status_list>();
    public static bool char_list_init_flag = true;  //save date




    private void Start()
    {

        //初めてスタートしたときだけキャラクターリセットがかかる。
        //これうまく動いていないかも
        //if (char_list_init_flag) { char_init(); }

        //
        char_init();

        //Debug.Log(cdict[0]._name);
        //Debug.Log(cdict[1]._name);
        //Debug.Log(cdict[2]._name);
        //Debug.Log(cdict[3]._name);

    }



    private void char_init()
    {
        //status_listをいちいちインスタンス化している
        //ちょっとあれだけどとりあえず動いているのでOK

        Debug.Log("init char list");

        var status0 = new Status_list();
        status0._name = "player1";
        status0._id = 0;
        status0._HP = 100;
        status0._ATK = 10;
        status0._DEF = 10;
        status0._SPD = 10;
        cdict[status0._id] = status0;


        var status1 = new Status_list();
        status1._name = "playerAAA";
        status1._id = 1;
        status1._HP = 100;
        status1._ATK = 11;
        status1._DEF = 8;
        status1._SPD = 9;
        cdict[status1._id] = status1;


        var status2 = new Status_list();
        status2._name = "playerBBB";
        status2._id = 2;
        status2._HP = 100;
        status2._ATK = 11;
        status2._DEF = 11;
        status2._SPD = 6;
        cdict[status2._id] = status2;


        var status3 = new Status_list();
        status3._name = "playerCCC";
        status3._id = 3;
        status3._HP = 100;
        status3._ATK = 6;
        status3._DEF = 7;
        status3._SPD = 14;
        cdict[status3._id] = status3;
        char_list_init_flag = false;

        var status4 = new Status_list();
        status4._name = "enemyDDD";
        status4._id = 4;
        status4._HP = 999;
        status4._ATK = 20;
        status4._DEF = 30;
        status4._SPD = 10;
        cdict[status4._id] = status4;
        char_list_init_flag = false;



    }





}





