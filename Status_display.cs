using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Status_display : MonoBehaviour
{
    [SerializeField] GameObject char_name_display_area;
    [SerializeField] GameObject HP_display_area;

    //playerからよびだされる
    //char_dicg.csで定義しているstatus_listの型をうけとって
    //値を各display_areaに割り振っていく
    public void update_display(Status_list _sl)
    {
        //name
        char_name_display_area.GetComponent<TextMeshProUGUI>().text = _sl._name.ToString();
        //HP
        HP_display_area.GetComponent<TextMeshProUGUI>().text = _sl._HP.ToString();
        //ATK
        //DEF
        //SPD



    }
}
