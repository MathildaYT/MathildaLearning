using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum WalkState
{
   F,
   B,
   L,
   R
}

public class EnemyController : MonoBehaviour
{
    public int pos_x;
    public int pos_z;
    int newposx;
    int newposz;
    WalkState state;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        ChangeValue(Random.Range(1, 5));
    }
    public void RandomWalk(WalkState state)
    {
        newposx = pos_x;
        newposz = pos_z;
        switch (state)
        {
            case WalkState.F:
                newposx = pos_x;
                newposz = pos_z+1;
                if (CheckIsValid(newposx, newposz))
                {
                    transform.position = new Vector3(newposx, 0, newposz);
                }
                break;
            case WalkState.B:
                newposx = pos_x;
                newposz = pos_z - 1;
                if (CheckIsValid(newposx, newposz))
                {
                    transform.position = new Vector3(newposx, 0, newposz);
                }
                break;
            case WalkState.L:
                newposx = pos_x - 1;
                newposz = pos_z;
                if (CheckIsValid(newposx, newposz))
                {
                    transform.position = new Vector3(newposx, 0, newposz);
                }
                break;
            case WalkState.R:
                newposx = pos_x + 1;
                newposz = pos_z;
                if (CheckIsValid(newposx, newposz))
                {
                    transform.position = new Vector3(newposx, 0, newposz);
                }
                break;
            default:
                break;
        }
        pos_x = newposx;
        pos_z = newposz;

    }
    public void ChangeValue(int value)
    {
        switch (value)
        {
            case 1:
                state = WalkState.F;
                break;
            case 2:
                state = WalkState.B;
                break;
            case 3:
                state = WalkState.L;
                break;
            case 4:
                state = WalkState.R;
                break;
            default:
                break;
        }
        RandomWalk(state);

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
