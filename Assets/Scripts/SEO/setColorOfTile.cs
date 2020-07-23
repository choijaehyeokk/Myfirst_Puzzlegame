using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setColorOfTile : MonoBehaviour
{

    // 0: red
    // 1: green
    // 2: blue
    [SerializeField]
    private GameObject[] colors;

    [SerializeField]
    private GameObject tile;

    // Use this for initialization
    void Start()
    {
        int idx = -1;

        if (tile.tag == "red")
        {
            idx = 0;
        }

        else if (tile.tag == "green")
        {
            idx = 1;
        }

        else if (tile.tag == "blue")
        {
            idx = 2;
        }

        else if (tile.tag == "yellow")
        {
            idx = 3;
        }

        for (int i = 0; i < 4; i++)
        {
            if (i == idx)
            {
                colors[i].SetActive(true);
            }

            else
            {
                colors[i].SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
