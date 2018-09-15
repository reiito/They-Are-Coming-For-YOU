using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visibility : MonoBehaviour
{
    public Enemy parentScript;

    public bool canKill;

    SkinnedMeshRenderer meshRenderer;

    Coroutine visibilityRefresher;

    AudioSource ambientAudio;

    private void Start()
    {
        meshRenderer = GetComponent<SkinnedMeshRenderer>();
        parentScript.followPlayer = meshRenderer.isVisible;
        ambientAudio = GetComponent<AudioSource>();
        visibilityRefresher = StartCoroutine(RefreshVisibility());
    }

    private void Update()
    {
        if (parentScript.gameController.gameOver)
        {
            StopAllCoroutines();
            parentScript.animator.speed = 0;
            parentScript.followPlayer = false;
            ambientAudio.Stop();
        }
    }

    private void OnBecameVisible()
    {
        if (Random.Range(0f, 1f) < 0.1f)
        {
            canKill = true;
        }
        else
        {
            parentScript.animator.speed = 0;
            parentScript.followPlayer = false;
            ambientAudio.Pause();
        }
    }

    private void OnBecameInvisible()
    {
        parentScript.animator.speed = 1;
        canKill = false;
        parentScript.followPlayer = true;
        ambientAudio.UnPause();
    }

    IEnumerator RefreshVisibility()
    {
        if (meshRenderer.isVisible)
        {
            parentScript.animator.speed = 1;
            parentScript.followPlayer = true;
            ambientAudio.Pause();
        }
        else
        {
            parentScript.animator.speed = 0;
            parentScript.followPlayer = false;
            ambientAudio.UnPause();
        }

        yield return new WaitForSeconds(2.5f);
    }
}
