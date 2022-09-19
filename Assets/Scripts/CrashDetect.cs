using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetect : MonoBehaviour
{

    [SerializeField] float _reloadTime = 2f;
    [SerializeField] ParticleSystem _crashEffect;
    [SerializeField] AudioClip _crashSFX;

    bool hasCrashed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground" && !hasCrashed)
        {
            hasCrashed = true;
            FindObjectOfType<PlayerController>().DisableControls();
            _crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(_crashSFX);
            Invoke("ReloadScene", _reloadTime);
        }
    }
    private void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}