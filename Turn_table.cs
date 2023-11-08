using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;  //motion

//ここではターンテーブルに表示するキャラクターの絵を管理します
//キャラクターidを受け取ったらそれに対応したspriteを表示します
//対応関係はデータベースみたいなオブジェクトを走らせてそこに問い合わせる予定
//：結局キャラクターにスプライト持たせたので直接いく


//テーブルの数はキャラクターの数に縛られずに
//表示に徹する仕様に改善しました。キャラクターが多くなっても
//内部でターンを保持して、表示は可能な範囲で行うので
//堅牢性向上した　11/8
public class Turn_table : MonoBehaviour
{
    //手作業でテーブルのパネルとる
    [SerializeField] GameObject table1;
    [SerializeField] GameObject table2;
    [SerializeField] GameObject table3;
    [SerializeField] GameObject table4;
    [SerializeField] GameObject table5;
    [SerializeField] GameObject table6;

    //
    [SerializeField] GameObject main_camera_root;

    private GameObject[] tables;
    private GameObject[] gobs;
    private int count_char;

    private void Start()
    {
        tables = new GameObject[] { table1, table2, table3,table4,table5,table6};
        pickup_all_player();

        create_turn_table();


    }

    private void create_turn_table()
    {


        //pick up listをすべてループして
        for (int ii=0; ii < count_char; ii++)
        {
            //int tmp_id = gobs[ii].GetComponent<player1>().char_id;

            if (ii < tables.Length )
            {
                tables[ii].GetComponent<Image>().sprite = gobs[ii].GetComponent<Image>().sprite;
            }
        }
        // カメラ瞬間移動
        //main_camera_root.transform.position = gobs[0].transform.position;
        // 
        main_camera_root.transform.DOMove(gobs[0].transform.position, 1f);


        //前のobjをactive_turn=falseにして
        gobs[3].GetComponent<player1>().active_turn = false;
        //次のobjをactive_turn=trueにする
        gobs[0].GetComponent<player1>().active_turn = true;

        
        foreach (GameObject gob in gobs)
        {
            gob.GetComponent<player1>().all_panel_visible_OFF();
            
        }
        


    }

    private void pickup_all_player()
    {
        //シーン上にインスタンス化されたオブジェクトを検知する
        //そのリストをすべてループでまわして
        //保持しておく
        count_char = 0;

        gobs = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject gob in gobs)
        {
            Debug.Log(gob);
            count_char++;
        }

    }

    //next turn button からcallする
    public void next_turn()
    {


        //  ... -> 4 -> 3 -> 2 -> 1
        var gob_tmp = gobs[0];
        //charactorカウントでループすると
        //charactor最大値まで代入が発生してしまい、
        //参照エラーとなるため、-1までのループにする
        for (var i = 0; i < count_char-1; i++)
        {
            gobs[i] = gobs[i + 1];
            //gobs[0] = gobs[1];
            //gobs[1] = gobs[2];
            //gobs[2] = gobs[3];
        }
        //charactor最大数-1がゲームオブジェクトリストの最大値なので
        //一番後ろにtmpを代入
        gobs[count_char-1] = gob_tmp;




        create_turn_table();



    }





}






