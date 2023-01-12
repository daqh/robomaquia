using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private AudioClip gameOverClip;

    [SerializeField]
    private AudioClip afterGameOverClip;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private bool gameOver = false;

    void Update()
    {
        if(player == null && !gameOver) {
            SceneManager.LoadScene("Game Over", LoadSceneMode.Additive);
            audioSource.loop = false;
            audioSource.clip = gameOverClip;
            audioSource.Play();
            gameOver = true;
        }
        if(gameOver) {
            if(!audioSource.isPlaying) {
                audioSource.loop = true;
                audioSource.clip = afterGameOverClip;
                audioSource.Play();
            }
            if(Input.GetKey(KeyCode.Space)) {
                SceneManager.LoadScene("Arena", LoadSceneMode.Single);
            }
        }
    }

}
