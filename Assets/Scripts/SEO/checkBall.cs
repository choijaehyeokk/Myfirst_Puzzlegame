using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkBall : MonoBehaviour
{
    private BoxCollider col_box;
    public Animation tileAni;

    // Use this for initialization
    void Start()
    {
        col_box = this.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "ball")
        {
            tileAni.Play();
            col_box.enabled = false;
        }
    }
}
