using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkTag : MonoBehaviour
{
    [SerializeField]
    private calculateResult cal_component;

    [SerializeField]
    private moveBall ball_component;

    [SerializeField]
    private bool[] isClear;

    /// <summary>
    /// SetEnd를 실행시키기 위한 컴포넌트이다.
    /// </summary>
    [SerializeField]
    private stageAni end_component;

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            isClear[i] = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isClear[0] && isClear[1] && isClear[2] && isClear[3])
        {
            end_component.SetEnd();
            isClear[0] = false;
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "red")
        {
            cal_component.SetRed(ball_component.nowNumber);
            isClear[0] = true;
        }

        else if (collision.gameObject.tag == "green")
        {
            cal_component.SetGreen(ball_component.nowNumber);
            isClear[1] = true;
        }

        else if (collision.gameObject.tag == "blue")
        {
            cal_component.SetBlue(ball_component.nowNumber);
            isClear[2] = true;
        }

        else if (collision.gameObject.tag == "yellow")
        {
            cal_component.SetYellow(ball_component.nowNumber);
            isClear[3] = true;
        }
    }
}