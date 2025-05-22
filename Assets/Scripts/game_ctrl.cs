using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;


//bird-player  pipe-obs
//trigger for start new game (delete the previous one)
public class game_ctrl : MonoBehaviour
{
    public player bird;

    private bool is_game_over = false;

    public bool is_game_win = false;
    private bool is_game_start = false;
    public UnityEngine.UI.Image gameOverImg;

    public Transform cameraTransform;


    // Start is called before the first frame update
    void Start()
    {
        if (gameOverImg)
        {
            gameOverImg.enabled = false;
        }
        is_game_start = false;

    }

    // Update is called once per frame
    void Update()
    {
        //gameover case
        if (is_game_over && gameOverImg)
        {
            gameOverImg.enabled = true;
            RectTransform rt = gameOverImg.GetComponent<RectTransform>();
            Vector3 screenPos = cameraTransform.position;
            rt.position = new Vector3(screenPos.x, rt.position.y, 0f);
        }

        //start game
        if ((!this.is_game_start) && (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)))
        {
            is_game_start = true;
            this.bird.startGame();
        }

        //jump update
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            this.bird.jump_player();
            return;
        }



    }

    public void GameOver()
    {
        this.is_game_over = true;

    }

    public void Win()
    {
        this.is_game_win = true;
    }
}
