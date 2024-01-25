using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyGuardStanding : MonoBehaviour
{
private Rigidbody2D enemyRigidbody;
private Transform currentPoint;
public float speed;

public GameObject failedText;

public Player player;

    void Start()
    {
        enemyRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" && Player.invisible == 0 && Player.hasMask == 0)
        {
            GetCaught();
        }
        else if (other.tag == "Player" && (Player.invisible == 1 || Player.hasMask == 1))
        {
            Debug.Log("I don't see you!");
        }
    }

    void GetCaught()
    {
        Debug.Log("See you!");
        failedText.SetActive(true);
        Player.freeze = true;
        Invoke("RestartGame",3);
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
