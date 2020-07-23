using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class calculateResult : MonoBehaviour
{
    /// <summary>
    /// 연산자 텍스트를 저장한다.
    /// </summary>
    [SerializeField]
    private Text[] oper_text;

    /// <summary>
    /// 블록 숫자 텍스트를 저장한다.
    /// </summary>
    [SerializeField]
    private Text[] block_text;

    /// <summary>
    /// 1: + /
    /// 2: - /
    /// 3: × /
    /// 4: ÷ /
    /// 5: =
    /// </summary>
    public int[] kind_of_oper;

    /// <summary>
    /// 계산할 때 사용되는 블록 넘버가 들어간다.
    /// </summary>
    [SerializeField]
    private int[] block_num;

    /// <summary>
    /// 실제 식 계산 결과 값입니다.
    /// </summary>
    int cal_result = 0;

    /// <summary>
    /// 유저가 입력한 계산 결과 값입니다.
    /// </summary>
    int user_result = 0;

    [SerializeField]
    private GameObject Perfect_Popup;

    [SerializeField]
    private GameObject Fail_Popup;

    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            if (kind_of_oper[i] == 1)
            {
                oper_text[i].text = "+";
            }

            else if (kind_of_oper[i] == 2)
            {
                oper_text[i].text = "-";
            }

            else if (kind_of_oper[i] == 3)
            {
                oper_text[i].text = "×";
            }

            else if (kind_of_oper[i] == 4)
            {
                oper_text[i].text = "÷";
            }

            else if (kind_of_oper[i] == 5)
            {
                oper_text[i].text = "=";
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetRed(int num)
    {
        block_num[0] = num;
        block_text[0].text = num.ToString();
    }

    public void SetGreen(int num)
    {
        block_num[1] = num;
        block_text[1].text = num.ToString();
    }

    public void SetBlue(int num)
    {
        block_num[2] = num;
        block_text[2].text = num.ToString();
    }

    public void SetYellow(int num)
    {
        user_result = num;
        block_text[3].text = num.ToString();
    }

    /// <summary>
    /// 식의 계산 결과가 일치하면 true, 일치하지 않으면 false를 반환한다.
    /// </summary>
    public bool SetResult()
    {
        cal_result = 0;

        if (kind_of_oper[0] < kind_of_oper[1] && kind_of_oper[0] < 3 && kind_of_oper[1] >= 3)
        {
            Debug.Log("뒤 연산을 먼저 합니다.");

            if (kind_of_oper[1] == 3)
            {
                cal_result = block_num[1] * block_num[2];
            }

            else if (kind_of_oper[1] == 4)
            {
                cal_result = block_num[1] / block_num[2];
            }

            Debug.Log("첫 번째 연산 결과: " + cal_result);

            if (kind_of_oper[0] == 1)
            {
                cal_result = block_num[0] + cal_result;
            }

            else if (kind_of_oper[0] == 2)
            {
                cal_result = block_num[0] - cal_result;
            }

            Debug.Log("두 번째 연산 결과: " + cal_result);
        }

        else
        {
            Debug.Log("앞 연산을 먼저 합니다.");

            if (kind_of_oper[0] == 1)
            {
                cal_result = block_num[0] + block_num[1];
            }

            else if (kind_of_oper[0] == 2)
            {
                cal_result = block_num[0] - block_num[1];
            }

            else if (kind_of_oper[0] == 3)
            {
                cal_result = block_num[0] * block_num[1];
            }

            else if (kind_of_oper[0] == 4)
            {
                cal_result = block_num[0] / block_num[1];
            }

            Debug.Log("첫 번째 연산 결과: " + cal_result);

            if (kind_of_oper[1] == 1)
            {
                cal_result = cal_result + block_num[2];
            }

            else if (kind_of_oper[1] == 2)
            {
                cal_result = cal_result - block_num[2];
            }

            else if (kind_of_oper[1] == 3)
            {
                cal_result = cal_result * block_num[2];
            }

            else if (kind_of_oper[1] == 4)
            {
                cal_result = cal_result / block_num[2];
            }

            Debug.Log("두 번째 연산 결과: " + cal_result);
        }

        if (user_result == cal_result)
        {
            int num = PlayerPrefs.GetInt("Stage") + 1;

            if (num <= 10)
            {
                PlayerPrefs.SetInt("Stage", num);
            }

            Debug.Log(cal_result + " is same with " + user_result);

            StartCoroutine("FinishTimer", 8.0f);
            StartCoroutine("PerfectTimer");
            

            return true;
        }

        else
        {
            Debug.Log(cal_result + " is different with " + user_result);

            StartCoroutine("FinishTimer", 8.0f);
            StartCoroutine("FailTimer");
            

            return false;
        }
    }

    IEnumerator FinishTimer(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);

        SceneManager.LoadScene("Game Scene");
    }

    IEnumerator PerfectTimer()
    {
        yield return new WaitForSeconds(4.0f);

        Perfect_Popup.SetActive(true);
        SoundManagerPF.instance.PlaySound();
    }

    IEnumerator FailTimer()
    {
        yield return new WaitForSeconds(4.0f);

        Fail_Popup.SetActive(true);
        SoundManagerFL.instance.PlaySound();
    }
}