using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyMapEditor : MonoBehaviour
{
    [SerializeField]
    private GameObject[] tiles1;

    [SerializeField]
    private GameObject[] tiles2;

    [SerializeField]
    private GameObject[] tiles3;

    [SerializeField]
    private GameObject[] tiles4;

    public int[] index;

    // Use this for initialization
    void Start()
    {
        setNumbers();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void setNumbers()
    {
        for (int j = 0; j < 4; j++)
        {
            int num = index[j];

            if (j == 0)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (num == i)
                    {
                        tiles1[i].SetActive(true);
                        continue;
                    }

                    tiles1[i].SetActive(false);
                }
            }

            else if (j == 1)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (num == i)
                    {
                        tiles2[i].SetActive(true);
                        continue;
                    }

                    tiles2[i].SetActive(false);
                }
            }

            else if (j == 2)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (num == i)
                    {
                        tiles3[i].SetActive(true);
                        continue;
                    }

                    tiles3[i].SetActive(false);
                }
            }

            else
            {
                for (int i = 0; i < 10; i++)
                {
                    if (num == i)
                    {
                        tiles4[i].SetActive(true);
                        continue;
                    }

                    tiles4[i].SetActive(false);
                }
            }
        }
    }
}
