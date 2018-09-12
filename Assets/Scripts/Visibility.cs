using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visibility : MonoBehaviour
{
    public Enemy parentScript;

    public bool canKill;

    SkinnedMeshRenderer meshRenderer;

    Coroutine visibilityRefresher;

    public AudioSource[] ambientAudio;

    private void Start()
    {
        meshRenderer = GetComponent<SkinnedMeshRenderer>();
        parentScript.followPlayer = meshRenderer.isVisible;
        visibilityRefresher = StartCoroutine(RefreshVisibility());
    }

    private void Update()
    {
        if (parentScript.gameController.gameOver)
        {
            StopAllCoroutines();
            parentScript.animator.speed = 0;
            parentScript.followPlayer = false;
            ambientAudio[0].Pause();
        }

        // Just in case
        //if (meshRenderer.isVisible)
        //{
        //    parentScript.animator.speed = 0;
        //    parentScript.followPlayer = false;
        //    audioSource.Pause();
        //}
        //else if (meshRenderer.isVisible)
        //{
        //    parentScript.animator.speed = 1;
        //    parentScript.followPlayer = true;
        //    audioSource.UnPause();
        //}
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
            ambientAudio[0].Pause();
        }
    }

    private void OnBecameInvisible()
    {
        parentScript.animator.speed = 1;
        canKill = false;
        parentScript.followPlayer = true;
        ambientAudio[0].UnPause();
    }

    IEnumerator RefreshVisibility()
    {
        if (meshRenderer.isVisible)
        {
            parentScript.animator.speed = 1;
            parentScript.followPlayer = true;
        }
        else
        {
            parentScript.animator.speed = 0;
            parentScript.followPlayer = false;
        }

        yield return new WaitForSeconds(2.5f);
    }
}
