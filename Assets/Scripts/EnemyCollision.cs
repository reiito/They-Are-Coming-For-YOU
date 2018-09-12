using UnityEngine;

public class EnemyCollision : MonoBehaviour
{

    GameController gameController;
    AudioSource deathAudio;

    private void Start()
    {
        gameController = GetComponentInParent<Enemy>().gameController;
        deathAudio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            gameController.gameOver = true;
            gameController.ShowEndUI();
            gameController.StopAllCoroutines();
            deathAudio.Play();
        }
    }
}
