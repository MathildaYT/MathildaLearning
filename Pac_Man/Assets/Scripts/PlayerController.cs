
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum PlayerMoveState
{
    Up,
    Right,
    Back,
    Left
}
public class PlayerController : MonoBehaviour
{
    private PlayerMoveState State;//角色状态
    private PlayerMoveState oldState = 0;//前一次角色的状态
    public float speed = 3f;
    private Animator anim;
    private Vector3 dest;
    public int pos_x;
    public int pos_z;

    void Start()
    {
      anim= transform.GetComponent<Animator>();
        dest = transform.position;
    }
    void Update()
    {
        string data;
        int newposz;
        if (MapManager.GetInstance.GameMap.GetDataPoint(pos_x, newposz, out data))
        {
            if (data == "c")
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, dest, speed);
                this.GetComponent<Rigidbody>().MovePosition(temp);
            }
            //Debug.Log(data);
        }
        if (Input.GetKey(KeyCode.W))
        {
           setState(PlayerMoveState.Up);
           newposz = pos_z - 1;
          
        }
        else if (Input.GetKey(KeyCode.S))
        {
            setState(PlayerMoveState.Back);
        }

        if (Input.GetKey(KeyCode.A))
        {
            setState(PlayerMoveState.Left);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            setState(PlayerMoveState.Right);
        }

    }


    void setState(PlayerMoveState _moveState)
    {
        int rotateValue = (_moveState - State) * 90;
        switch (_moveState)
        {
            case PlayerMoveState.Up:
                dest = Vector3.forward+transform.position;
                break;
            case PlayerMoveState.Right:
                dest = Vector3.right+ transform.position;
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

}