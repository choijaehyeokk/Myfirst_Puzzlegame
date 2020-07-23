using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBall : MonoBehaviour
{
    // 맵과 key 타일
    public GameObject[] tiles;
    public GameObject[] key_tiles;

    // key 타일에서 움직이는 오브젝트
    public GameObject key;

    // 맵과 key의 목적 index
    public int des_idx = 4;
    public int key_des_idx = 3;

    // lerp 속도
    public float speed = 8.0f;

    // 맵과 key의 사이즈
    private int map_size = 3;
    private int key_map_size = 2;

    // ball 위 숫자들
    public GameObject[] numbers;

    // Key Map의 숫자를 알아온다.
    [SerializeField]
    private keyMapEditor KM_editor;

    // 현재 key가 어떤 값을 가르키는지 나타낸다.
    public int nowNumber;

    // Use this for initialization
    void Start()
    {
        nowNumber = KM_editor.index[key_des_idx];

        for (int i = 0; i < 10; i++)
        {
            if (nowNumber != i)
            {
                numbers[i].SetActive(false);
            }

            else
            {
                numbers[i].SetActive(true);
            }
        }

        speed = 8.0f;

        this.gameObject.transform.localPosition = new Vector3(tiles[des_idx].transform.localPosition.x,
            tiles[des_idx].transform.localPosition.y, tiles[des_idx].transform.localPosition.z);

        key.transform.localPosition = new Vector3(key_tiles[key_des_idx].transform.localPosition.x,
            key_tiles[key_des_idx].transform.localPosition.y, key_tiles[key_des_idx].transform.localPosition.z);
    }

    // Update is called once per frame
    void Update()
    {
        move_ball();
        move_key();
    }

    void move_ball()
    {
        this.gameObject.transform.localPosition = Vector3.Lerp(this.gameObject.transform.localPosition,
               new Vector3(tiles[des_idx].transform.localPosition.x,
               tiles[des_idx].transform.localPosition.y, tiles[des_idx].transform.localPosition.z), Time.deltaTime * speed);
    }

    void move_key()
    {
        key.transform.localPosition = Vector3.Lerp(key.transform.localPosition,
               new Vector3(key_tiles[key_des_idx].transform.localPosition.x,
               key_tiles[key_des_idx].transform.localPosition.y, key_tiles[key_des_idx].transform.localPosition.z),
               Time.deltaTime * speed);
    }

    public void click_up()
    {
        SoundManager.instance.PlaySound();
        if (des_idx - map_size >= 0)
        {
            des_idx -= map_size;
            
        }

        if (key_des_idx - key_map_size >= 0)
        {
            numbers[nowNumber].SetActive(false);
            key_des_idx -= key_map_size;
            nowNumber = KM_editor.index[key_des_idx];
            numbers[nowNumber].SetActive(true);
        }
    }

    public void click_down()
    {
        SoundManager.instance.PlaySound();
        if (des_idx + map_size < map_size * map_size)
        {
            des_idx += map_size;
        }

        if (key_des_idx + key_map_size < key_map_size * key_map_size)
        {
            numbers[nowNumber].SetActive(false);
            key_des_idx += key_map_size;
            nowNumber = KM_editor.index[key_des_idx];
            numbers[nowNumber].SetActive(true);
        }
    }

    public void click_left()
    {
        SoundManager.instance.PlaySound();
        if (des_idx % map_size - 1 >= 0)
        {
            des_idx -= 1;
        }

        if (key_des_idx % key_map_size - 1 >= 0)
        {
            numbers[nowNumber].SetActive(false);
            key_des_idx -= 1;
            nowNumber = KM_editor.index[key_des_idx];
            numbers[nowNumber].SetActive(true);
        }
    }

    public void click_right()
    {
        SoundManager.instance.PlaySound();
        if (des_idx % map_size + 1 < map_size)
        {
            des_idx += 1;
        }

        if (key_des_idx % key_map_size + 1 < key_map_size)
        {
            numbers[nowNumber].SetActive(false);
            key_des_idx += 1;
            nowNumber = KM_editor.index[key_des_idx];
            numbers[nowNumber].SetActive(true);
        }
    }
}
