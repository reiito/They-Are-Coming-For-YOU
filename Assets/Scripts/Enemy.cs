using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameController gameController;
    public GameObject player;
    public Animator animator;
    public RuntimeAnimatorController[] animations;

    public GameObject childMesh;

    public float speed;
    public bool followPlayer = true;

    Vector3 playerPosition;

    private void Awake()
    {
        animator.runtimeAnimatorController = animations[Random.Range(0, animations.Length)];
    }

    private void Start()
    {
        playerPosition = new Vector3(player.transform.position.x, player.transform.position.y - 6, player.transform.position.z);
        transform.LookAt(playerPosition);
    }

    private void Update()
    {
        if (gameController.gameOver)
        {
            animator.speed = 0;
            return;
        }

        if (followPlayer)
        {
            playerPosition = new Vector3(player.transform.position.x, player.transform.position.y - 6, player.transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, playerPosition, Time.deltaTime / speed);
            transform.LookAt(playerPosition);
        }
    }
}
