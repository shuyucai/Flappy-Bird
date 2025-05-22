using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(UnityEngine.UI.Image))]
public class frame_anim : MonoBehaviour
{
    public Sprite[] anims;
    public float duration = 0.1f;
    public bool is_loop = false;
    public bool play_onwake = false;
    private bool is_playing = false;
    private float curr_time = 0;
    private UnityEngine.UI.Image img = null;

    // Start is called before the first frame update

    delegate void on_play_end();
    on_play_end callbacks;

    void play_once(on_play_end end_func)
    {
        if (this.anims.Length <= 0)
        {
            return;
        }
        this.callbacks = end_func;
        this.is_loop = false;
        this.is_playing = true;
        this.curr_time = 0;

        this.img.sprite = anims[0];

    }

    public void play_loop()
    {
        if (this.anims.Length <= 0)
        {
            return;
        }
        this.is_loop = true;
        this.is_playing = true;
        this.curr_time = 0;

        this.img.sprite = anims[0];


    }
    void Awake()
    {
        this.img = this.GetComponent<UnityEngine.UI.Image>();
        
    }
    void Start()
    {

        if (this.play_onwake)
        {
            if (this.is_loop == false)
            {
                this.play_once(null);

            }
            else
            {
                this.play_loop();
            }
        }



    }

    // Update is called once per frame
    void Update()
    {
        if (this.is_playing == false)
        {
            return;
        }

        this.curr_time += Time.deltaTime;
        int index = (int)(this.curr_time / this.duration);
        if (this.is_loop == false)
        {
            
            if (index >= this.anims.Length)
            {
                this.is_playing = false;
                if (this.callbacks != null)
                {
                    this.callbacks();
                }
                return;
            }

            this.img.sprite = anims[index];
        }
        else
        {   if (index >= this.anims.Length)
            {
                while (this.curr_time >= this.anims.Length * this.duration)
                {
                    this.curr_time -= this.anims.Length * this.duration;
                    index -= this.anims.Length;

                }
            }

            this.img.sprite = anims[index];

        }


    }

}
