using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;


// this is git hub test 2023 10- 15
//   thank you! hello from iphone

public class player1 : MonoBehaviour
{
    [SerializeField] GameObject field_panel;
    [SerializeField] GameObject can_move_area;

    private string my_state;
    private void Start()
    {
        my_state = "stanby";
    }
    public void ivent_reactor()
    {
        if (my_state == "stanby") { visible_field_panel(true); }
        if (my_state == "move") { go_to_spot(); }

    }


    //キャラクター用のメニューパネルを表示したい
    private void visible_field_panel(bool t_or_f)
    {
        //パネルを表示・非表示する
        field_panel.SetActive(t_or_f);

    }

    //可動範囲を表示したい
    private void visible_can_move_area(bool t_or_f)
    {
        //動けるエリアに相当するGameobjectを表示・非表示する
        can_move_area.SetActive(t_or_f);

        //move状態にする
        my_state = "move";

    }

    //移動したい
    private void go_to_spot()
    {
        transform.Translate(new Vector3(1f, 1f, 1f));




    }




    //[SerializeField] NavMeshAgent myAgent;
    //[SerializeField] Transform target;
    //private void Start()
    //{
    //    myAgent = GetComponent<NavMeshAgent>();
    //    var path = new NavMeshPath();
    //    NavMesh.CalculatePath(transform.position, target.position, NavMesh.AllAreas, path);

    //    var length = path.corners[path.corners.Length - 1] - target.position;
    //    if(length.magnitude > 1.0f) { Debug.Log("err: there is not Nav Mesh Path"); }
    //}

    //void Update()
    //{
    //    // 次に目指すべき位置を取得
    //    var nextPoint = myAgent.steeringTarget;
    //    Vector3 targetDir = nextPoint - transform.position;

    //    // その方向に向けて旋回する(360度/秒)
    //    Quaternion targetRotation = Quaternion.LookRotation(targetDir);
    //    transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 360f * Time.deltaTime);

    //    // 自分の向きと次の位置の角度差が30度以上の場合、その場で旋回
    //    float angle = Vector3.Angle(targetDir, transform.forward);
    //    if (angle < 30f)
    //    {
    //        transform.position += transform.forward * 5.0f * Time.deltaTime;
    //        // もしもの場合の補正
    //        //if (Vector3.Distance(nextPoint, transform.position) < 0.5f)　transform.position = nextPoint;
    //    }

    //    // targetに向かって移動します。
    //    myAgent.SetDestination(target.position);
    //    myAgent.nextPosition = transform.position;
    //}

}
