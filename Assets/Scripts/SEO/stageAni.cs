using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stageAni : MonoBehaviour
{
    [SerializeField]
    private Animation[] rev_ani;
    public int size;

    public GameObject[] init_ani;
    int tile_idx = 0;

    float t_delay = 0.1f;

    public bool ischeck = false;

    [SerializeField]
    private calculateResult result_component;

    // Use this for initialization
    void Start()
    {
        SetInit();
    }

    // Update is called once per frame
    void Update()
    {
        if (ischeck)
        {
            ischeck = false;
            SetEnd();
        }
    }

    void SetInit()
    {
        tile_idx = 0;

        for (int i = 0; i < size; i++)
        {
            rev_ani[i] = init_ani[i].GetComponent<Animation>();
            init_ani[i].SetActive(false);
        }

        StartCoroutine("playInitAni", t_delay);
    }

    public void SetEnd()
    {
        result_component.SetResult();

        tile_idx = size - 1;

        for (int i = tile_idx; i >= 0; i--)
        {
            rev_ani[i][rev_ani[i].clip.name].normalizedTime = 1f;
            rev_ani[i][rev_ani[i].clip.name].speed = -1.0f;
        }

        StartCoroutine("playEndAni", t_delay);
    }

    IEnumerator playInitAni(float delayTime)
    {
        init_ani[tile_idx].SetActive(true);
        tile_idx++;

        yield return new WaitForSeconds(delayTime);

        if (tile_idx < size)
        {
            StartCoroutine("playInitAni", t_delay);
        }

        else
        {
            StopCoroutine("playInitAni");
        }
    }

    IEnumerator playEndAni(float delayTime)
    {
        rev_ani[tile_idx].Play();
        tile_idx--;

        yield return new WaitForSeconds(delayTime);

        if (tile_idx >= 0)
        {
            StartCoroutine("playEndAni", t_delay);
        }

        else
        {
            StopCoroutine("playEndAni");
        }
    }
}
