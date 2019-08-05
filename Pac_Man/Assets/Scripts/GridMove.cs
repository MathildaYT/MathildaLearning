
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMove : MonoBehaviour
{
    private  float Speed=4f;
    Vector3 m_direction;
   
    void Start()
    {
        
    }
    private void Update()
    {
      
    }
    public void Move(float t)
    {
        Vector3 pos = transform.position;
        pos += m_direction * Speed * t;
        bool across = false;
        if ((int)pos.x != (int)transform.position.x)
            across = true;
        if ((int)pos.z != (int)transform.position.z)
            across = true;
        

    }

}
