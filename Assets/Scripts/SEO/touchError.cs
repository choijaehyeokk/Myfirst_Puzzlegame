using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchError : MonoBehaviour
{
    private GameObject[] Childbtn = new GameObject[4];

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            Childbtn[i] = this.transform.GetChild(i).gameObject;
            Childbtn[i].SetActive(false);
        }

        StartCoroutine("StartTouch");
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator StartTouch()
    {
        yield return new WaitForSeconds(4.0f);

        for (int i = 0; i < 4; i++)
        {
            Childbtn[i] = this.transform.GetChild(i).gameObject;
            Childbtn[i].SetActive(true);
        }
    }
}
