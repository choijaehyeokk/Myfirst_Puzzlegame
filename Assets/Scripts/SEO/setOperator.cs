using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setOperator : MonoBehaviour
{
    [SerializeField]
    private GameObject[] tiles;

    // 0: 덧셈
    // 1: 뺄셈
    // 2: 곱셈
    // 3: 나눗셈
    public GameObject[] oper;

    // 사용하지 않을 경우에는 -1로 설정하라.
    public int plus;
    public int minus;
    public int multi;
    public int sper;

    // Use this for initialization
    void Start()
    {
        if (plus != -1)
        {
            oper[0].transform.localPosition = tiles[plus].transform.localPosition;
        }

        if (minus != -1)
        {
            oper[1].transform.localPosition = tiles[minus].transform.localPosition;
        }

        if (multi != -1)
        {
            oper[2].transform.localPosition = tiles[multi].transform.localPosition;
        }

        if (sper != -1)
        {
            oper[3].transform.localPosition = tiles[sper].transform.localPosition;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
