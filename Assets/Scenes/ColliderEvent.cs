using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderEvent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //콜백 함수 
        Debug.Log("충돌 판정!");
    }

    private void OnTriggerEnter(Collider other)
    {
        //콜백 함수 
        Debug.Log("트리거 입장!!");
    }
}
