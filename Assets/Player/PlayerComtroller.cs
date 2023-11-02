using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerComtroller : MonoBehaviour
{
    #region Singelton
    public static PlayerComtroller Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(Instance);
    }
    #endregion

    [Header("GAME SETUP")]
    public float speed;
    public float jump;
    public float gravity;
    public bool gameOver;
    public bool canJump;
    public float diePos;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    int score;
    int highScore;
    bool gameStarted;
    Rigidbody rb;
    void Start()
    {
        Physics.gravity = new Vector3(0, -gravity, 0);
        rb = GetComponent<Rigidbody>();
        score = -1;
        highScoreText.text = $"High: {PlayerPrefs.GetInt("HighScore")}";
    }

    void Update()
    {
        GameOver();

        if (Input.GetMouseButtonUp(0))
            gameStarted = true;

        if (!gameStarted)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            Jump();
            StartCoroutine("RestartGame");
        }

        Forward();
    }

    void Forward()
    {
        if (canJump && gameStarted)
        {
            rb.velocity = Vector3.forward * speed;

        }
    }

    void Jump()
    {
        if (canJump)
            rb.AddForce(Vector3.up * jump, ForceMode.Impulse);
        canJump = false;
    }

    void GameOver()
    {
        if (transform.position.y < diePos)
        {
            gameOver = true;
            canJump = false;
            speed = 0;
            jump = 0;
        }
    }

    IEnumerator RestartGame()
    {
        if (gameOver)
        {
            yield return new WaitForSeconds(1);
            SceneManager.LoadScene(0);
        }
    }

    void Score()
    {
        scoreText.text = $"{score}";

        if (score > PlayerPrefs.GetInt("HighScore"))
        {
            highScore = score;
            highScoreText.text = $"High: {highScore}";
            PlayerPrefs.SetInt("HighScore", highScore);
        }
    }



    private void OnCollisionEnter(Collision collision)
    {
        score++;
        Score();
        canJump = true;
        if (gameStarted)
            Destroy(collision.gameObject, 3);
    }


}
