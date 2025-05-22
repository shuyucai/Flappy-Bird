using System.Collections;
using System.Collections.Generic;
using JetBrains.Rider.Unity.Editor;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    Rigidbody2D body;
    frame_anim anim;
    private game_ctrl gameCtrl;

    // Start is called before the first frame update
    void Start()
    {
        GameObject canvasObj = GameObject.Find("Canvas");
        gameCtrl = canvasObj.GetComponent<game_ctrl>();
        this.body = this.GetComponent<Rigidbody2D>();
        this.anim = this.GetComponent<frame_anim>();
    

    }

    public void startGame()
    {
        Vector2 v = this.body.velocity;
        v.x = 1;
        this.body.velocity = v;
        this.body.gravityScale = 1.0f;
        this.anim.play_loop();
        Debug.Log("GameStart!");
    }

    public void jump_player()
    {
        Vector2 v = this.body.velocity;
        v.y += 5;
        this.body.velocity = v;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collision");
        this.body = this.GetComponent<Rigidbody2D>();
        Vector2 v = this.body.velocity;
        v.x = 0;
        this.body.velocity = v;
        if (gameCtrl.is_game_win)
        {
            return;
        }
        switch (collision.collider.gameObject.layer)
        {
            case 7:
                Debug.Log("GameOver!");

                gameCtrl.GameOver();

                break;
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.layer)
        {
            case 8:
                Debug.Log("Win");
                gameCtrl.Win();

            break;

        }
    }
}
