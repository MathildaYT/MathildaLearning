
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
    public float speed = 8;
    private Animator anim;
    void Start()
    {
      anim= transform.GetComponent<Animator>();

    }
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            setState(PlayerMoveState.Up);
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
        Vector3 transformValue = new Vector3();
        int rotateValue = (_moveState - State) * 90;
        anim.SetBool("walk", true);
        switch (_moveState)
        {
            case PlayerMoveState.Up:
                transformValue = Vector3.forward * Time.deltaTime * speed;
                break;
            case PlayerMoveState.Right:
                transformValue = Vector3.right * Time.deltaTime * speed;
                break;
            case PlayerMoveState.Back:
                transformValue = Vector3.back * Time.deltaTime * speed;
                break;
            case PlayerMoveState.Left:
                transformValue = Vector3.left * Time.deltaTime * speed;
                break;
        }
        transform.Rotate(Vector3.up, rotateValue);
        transform.Translate(transformValue, Space.World);
        oldState = State;
        State = _moveState;
    }

}