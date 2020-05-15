using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using UnityEngine.SceneManagement;
using System;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public static int result = 0;
    public GameObject player;
    private Rigidbody2D rb;
    Vector2 speed = new Vector2(0, 0);
    private float speedUpdate = 3.00000f;
    Vector2 jumpForce = new Vector2(0, 120);
    bool hitGreen = false;
    bool hitNonGreen = false;
    bool isDead = false;
    public static Sprite spriteToUse;
    private int coins;
    private bool isActive = false;
    private float gravity = 4f;
    private float mass = 8f;


    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            rb.AddForce(jumpForce, ForceMode2D.Impulse);
        }
    }

    //Kill the player and load the Game Over Scene
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Obstacle" || col.gameObject.tag == "NonGreen")
        {
            Destroy(player);
            isDead = true;
            SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        //Color pink = new Vector4(0.900f, 0.200f, 0.500f, 1f);

        //Destroy Obstacle and update Score
        if (col.gameObject.tag == "Obstacle")
        {
            hitGreen = true;
            Destroy(col.gameObject);
            result++;

            //Update coins to shop
            coins = PlayerPrefs.GetInt("Coins");
            coins++;
            PlayerPrefs.SetInt("Coins", coins);

        }
    }





    // Start is called before the first frame update
    void Start()
    {
        player = new GameObject();
        player.AddComponent<SpriteRenderer>();
        rb = this.GetComponent<Rigidbody2D>();

        //Assign another sprite than the original one to the player

        if (SelectSkinBall.counter == 1)
        {
            this.GetComponent<SpriteRenderer>().sprite = spriteToUse;
            Debug.Log("bought == true");
        }

        isActive = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            isActive = true;
        }

        if (isActive)
        {
            rb.gravityScale = gravity;
            rb.mass = mass;
            speedUpdate += (((0.0000000001f / 90000) - (1 / 90000)) / 90000) / 90000;
            speed = new Vector2(speedUpdate, 0);

            Task.Delay(10000);

            rb.AddForce(speed, ForceMode2D.Force);
            Jump();
        }
        else
        {
            rb.gravityScale = -0.00f;
            rb.mass = 0f;
            speed = new Vector2(0, 0);
            rb.AddForce(speed, ForceMode2D.Force);
        }
    }
}
