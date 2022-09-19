using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float _reloadTime = 2f;
    [SerializeField] ParticleSystem _finishEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            _finishEffect.Play();
            GetComponent<AudioSource>().Play();
            Invoke("ReloadScene", _reloadTime);
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
