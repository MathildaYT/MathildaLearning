using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class GhostMove:MonoBehaviour
{
    public GameObject wayPointGo;
    private List<Vector3> points = new List<Vector3>();
    int index = 0;
    float speed = 0.03f;
    void Start()
    {
        foreach (Transform item in wayPointGo.transform)
        {
            points.Add(item.position);
        }
    }
    private void FixedUpdate()
    {
        if (transform.position!=points[index])
        {
            Vector3 temp = Vector3.MoveTowards(transform.position, points[index], speed);
            this.GetComponent<Rigidbody>().MovePosition(temp);
        }
        else
        {
            index++;
            if (index==points.Count)
            {
                index = 0;
            }
        }
    }
}

