using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hello : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Manager.Instance.SoundManager.play(Define.Sound.Effect, "Sounds/unityChan/Voice/univ0001");
        Manager.Instance.SoundManager.play(Define.Sound.BGM, "Sounds/unityChan/Voice/univ0002");
    }
}
