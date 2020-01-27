using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DestroyByContact : MonoBehaviour
{
    public GameObject rock;
    public int scoreValue;
    private GameController gameController;


    private void Start()
    {
      GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)

            gameController = gameControllerObject.GetComponent<GameController>();

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Instantiate(rock, transform.position, transform.rotation);
        }
        gameController.AddScore(scoreValue);
        
    }
}
