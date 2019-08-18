    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using UnityEngine;

    public class GhostMove:MonoBehaviour
    {
        public GameObject[] wayPointGos;
        private List<Vector3> points = new List<Vector3>();
        int index = 0;
        float speed = 0.03f;
        void Start()
        {
            foreach (Transform item in wayPointGos[UnityEngine.Random.Range(0, 2)].transform)
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
                    points.Clear();
                    foreach (Transform item in wayPointGos[UnityEngine.Random.Range(0, 2)].transform)
                    {
                        points.Add(item.position);
                    }
                }
            }
            }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="player")
        {
            Destroy(other.gameObject);
        }
    }
}


