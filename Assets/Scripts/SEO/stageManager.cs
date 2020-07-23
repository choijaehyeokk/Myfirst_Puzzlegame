using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stageManager : MonoBehaviour
{

    [SerializeField]
    private GameObject[] stages;
    public static int stage_record = 1; //스테이지 기록 남길 변수.
                                        //처음에 continue 누를 수 있으니까 stage=1으로 세팅함.

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            
            if (i == PlayerPrefs.GetInt("Stage") - 1)
            {
                stage_record = PlayerPrefs.GetInt("Stage"); // 스테이지 넘어가면 그 스테이지 값 저장. btnYype에서 continue 누르면 넘어감.
                stages[i].SetActive(true);
            }

            else
            {
                stages[i].SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
   
}
