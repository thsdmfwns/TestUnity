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
        //�ݹ� �Լ� 
        Debug.Log("�浹 ����!");
    }

    private void OnTriggerEnter(Collider other)
    {
        //�ݹ� �Լ� 
        Debug.Log("Ʈ���� ����!!");
    }
}
