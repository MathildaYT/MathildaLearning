
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum PlayerMoveState
{
    Up,
    Right,
    Back,
    Left,
    
}
public class PlayerController : MonoBehaviour
{
    private PlayerMoveState State;//角色状态
    private PlayerMoveState oldState = 0;//前一次角色的状态
    public float speed = 3f;
    private Animator anim;
    private Vector3 currentpos;
    private Vector3 dest;
    public int pos_x;
    public int pos_z;
    int newposz;
    int newposx;
    private bool IsStand=false;
    public Vector3 targetpos;

    void Start()
    {
        anim = transform.GetComponent<Animator>();
        dest = transform.position;
        currentpos = transform.position;
    }
    void Update()
    {
        if (!IsStand)
        {
            if (Vector3.Distance(new Vector3(this.transform.position.x, 0, this.transform.position.z), dest) > 0.01f)
            {
                Vector3 temp = Vector3.MoveTowards(currentpos, dest, speed);
                this.GetComponent<Rigidbody>().MovePosition(temp);
            }
            else
            {
                this.transform.position = dest;
                currentpos = dest;
                IsStand = true;
            }

        }
        newposz = pos_z;
        newposx = pos_x;
        bool verify = false;
        if (Input.GetKey(KeyCode.W))
        {
            newposz = pos_z + 1;
            newposx = pos_x;
            if (CheckIsValid(newposx, newposz))
            {
                if (IsStand)
                {
                    verify = true;
                    setState(PlayerMoveState.Up);
                    IsStand = false;
                }
            }

        }
        if (Input.GetKey(KeyCode.S))
        {
            newposz = pos_z - 1;
            newposx = pos_x;
            if (CheckIsValid(newposx, newposz))
            {
                if (IsStand)
                {
                    verify = true;
                    setState(PlayerMoveState.Back);
                    IsStand = false;
                }
            }
        }

        if (Input.GetKey(KeyCode.A))
        {
            newposz = pos_z;
            newposx = pos_x - 1;
            if (CheckIsValid(newposx, newposz))
            {
                if (IsStand)
                {
                    verify = true;
                    setState(PlayerMoveState.Left);
                    IsStand = false;
                }
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            newposz = pos_z;
            newposx = pos_x + 1;
            if (CheckIsValid(newposx, newposz))
            {
                if (IsStand)
                {
                    verify = true;

                    setState(PlayerMoveState.Right);
                    IsStand = false;
                }
            }
        }
        if (verify)
        {
            pos_z = newposz;
            pos_x = newposx;
        }
        //if (State != PlayerMoveState.Stand)
        //{
        //    switch (State)
        //    {
        //        case PlayerMoveState.Up:
        //            dest = Vector3.forward + transform.position;
        //            break;
        //        case PlayerMoveState.Right:
        //            dest = Vector3.right + transform.position;
        //            break;
        //        case PlayerMoveState.Back:
        //            dest = Vector3.back + transform.position;
        //            break;
        //        case PlayerMoveState.Left:
        //            dest = Vector3.left + transform.position;
        //            break;
        //    }
        //}
    }


    void setState(PlayerMoveState _moveState)
    {
        int rotateValue = (_moveState - State) * 90;
        switch (_moveState)
        {
            case PlayerMoveState.Up:
                dest = Vector3.forward + transform.position;
                break;
            case PlayerMoveState.Right:
                dest = Vector3.right + transform.position;
                break;
            case PlayerMoveState.Back:
                dest = Vector3.back + transform.position;
                break;
            case PlayerMoveState.Left:
                dest = Vector3.left + transform.position;
                break;
        }
        transform.Rotate(Vector3.up, rotateValue);
        oldState = State;
        State = _moveState;
    }
    public bool CheckIsValid(int posx, int posz)
    {
        string data;
        if (MapManager.GetInstance.GameMap.GetDataPoint(posx, posz, out data))
        {
            if (data != "*")
            {
                return true;
            }
            return false;
        }
        return false;
    }
}