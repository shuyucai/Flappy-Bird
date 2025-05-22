using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow_target : MonoBehaviour
{
    public Transform target;

    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        if (this.target)
        {
            this.offset = this.transform.position - this.target.position;
            
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.target == null)
        {
            return;
        }
        Vector3 pos = this.transform.position;
        pos.x = this.target.position.x + this.offset.x;

        this.transform.position = pos;
        
    }
}
