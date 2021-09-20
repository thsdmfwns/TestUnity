using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    Idle,
    Die,
    Run,
}

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float Speed = 10.0f;
    private Vector3 station;
    private Animator animator;
    private PlayerState playerState;
    void Start()
    {
        animator = GetComponent<Animator>();
        Manager.Instance.inputManager.MouseAction += OnMouseClicked;
        Manager.Instance.inputManager.MouseAction += OnMouseClicked;
    }

    private void OnMouseClicked(Define.MouseEvent obj)
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, LayerMask.GetMask("Floor")))
        {
            station = hit.point;
            playerState = PlayerState.Run;
        }
    }
    void Update()
    {
        switch (playerState)
        {
            case PlayerState.Idle:
                UpdateIdle();
                break;
            case PlayerState.Die:
                UpdateDie();
                break;
            case PlayerState.Run:
                UpdateRun();
                break;
        }
    }

    private void UpdateRun()
    {
        DoMove();
        animator.SetFloat("Speed", Speed);
    }

    private void UpdateDie()
    {
        return;
    }

    private void UpdateIdle()
    {
        animator.SetFloat("Speed", 0);
    }

    void DoMove()
    {
        var dir = station - transform.position;
        if (dir.magnitude < 0.000001f)
        {
            playerState = PlayerState.Idle;
        }
        else
        {
            var moveDist = Mathf.Clamp(Speed * Time.deltaTime, 0, dir.magnitude);
            transform.position += dir.normalized * moveDist;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 0.1f);
        }
    }
}
