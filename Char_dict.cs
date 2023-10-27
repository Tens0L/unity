using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//ここはあまり触ることはないデータベースエリア
//基本的に問い合わせだけ
//
//

public class Char_dict : MonoBehaviour
{
    
    public static Dictionary<int, GameObject> cdict = new Dictionary<int, GameObject>();
    public static bool char_list_init_flag = true; //save date
    [SerializeField] GameObject pref1;
    [SerializeField] GameObject pref2;
    [SerializeField] GameObject pref3;
    [SerializeField] GameObject pref4;



    private void Start()
    {

        //初めてスタートしたときだけキャラクターリセットがかかる。
        //if (char_list_init_flag) { char_init(); }


        char_init();


    }



    private void char_init()
    {
        Debug.Log("init char list");


        cdict[0] = pref1;
        cdict[1] = pref2;
        cdict[2] = pref3;
        cdict[3] = pref4;


        char_list_init_flag = false;
    }





}