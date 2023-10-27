using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//ここではターンテーブルに表示するキャラクターの絵を管理します
//キャラクターidを受け取ったらそれに対応したspriteを表示します
//対応関係はデータベースみたいなオブジェクトを走らせてそこに問い合わせる予定
//：結局キャラクターにスプライト持たせたので直接いく
public class Turn_table : MonoBehaviour
{
    [SerializeField] GameObject table1;
    [SerializeField] GameObject table2;
    [SerializeField] GameObject table3;
    [SerializeField] GameObject table4;

    private GameObject[] tables;
    private GameObject[] gobs;


    private void Start()
    {
        tables = new GameObject[] { table1, table2, table3, table4 };

        pickup_all_player();

        create_turn_table();


    }

    private void create_turn_table()
    {


        //pick up listをすべてループして
        for (int ii=0; ii < 4; ii++)
        {
            int tmp_id = gobs[ii].GetComponent<player1>().char_id;

            //change_image(ii, tmp_id);
            tables[ii].GetComponent<Image>().sprite = gobs[ii].GetComponent<Image>().sprite;

        }



    }

    private void pickup_all_player()
    {
        //シーン上にインスタンス化されたオブジェクトを検知する
        //そのリストをすべてループでまわして
        //保持しておく

        gobs = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject gob in gobs)
        {
            Debug.Log(gob);
        }

    }

    //next turn button からcallする
    public void next_turn()
    {
        var gob_tmp = gobs[0];
        gobs[0] = gobs[1];
        gobs[1] = gobs[2];
        gobs[2] = gobs[3];
        gobs[3] = gob_tmp;

        create_turn_table();
        //
        //change_image(1, 2);
        //change_image(2, 3);
        //change_image(3, 4);
        //change_image(4, 1);
    }



    public void change_image(int table_id,int char_id)
    {
        Debug.Log("table:"+table_id.ToString()+ " char:"  +char_id.ToString());
  tables[table_id].GetComponent<Image>().sprite = Char_dict.cdict[char_id].GetComponent<Image>().sprite;
        
    }



}






