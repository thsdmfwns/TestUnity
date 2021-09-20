using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    Define.CameraMode CameraMode = Define.CameraMode.Quater;
    [SerializeField]
    Vector3 Delta;
    [SerializeField]
    GameObject Player;

    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(Player.transform.position, Delta, out hit, Delta.magnitude, LayerMask.GetMask("Wall")))
        {
            var distance = (hit.point - Player.transform.position).magnitude;
            transform.position = Player.transform.position + Delta.normalized + new Vector3(0, 1, 0);
            return;
        }
        transform.position = Player.transform.position + Delta;
        transform.LookAt(Player.transform);
    }
}
