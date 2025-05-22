using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class sky : MonoBehaviour
{
    RawImage bg;
    public float speed = 0.1f;


    // Start is called before the first frame update
    void Start()
    {
        this.bg = this.GetComponent<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {
        Rect uv_rect = this.bg.uvRect;
        uv_rect.x += this.speed * Time.deltaTime;
        this.bg.uvRect = uv_rect;
        
    }
}
