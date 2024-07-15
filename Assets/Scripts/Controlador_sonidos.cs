using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controlador_sonidos : MonoBehaviour
{
    // Start is called before the first frame update
    public static Controlador_sonidos instance;
    private AudioSource audioSource;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        audioSource = GetComponent<AudioSource>();
    }

    public void ejecutarSonido(AudioClip sonido)
    {
        audioSource.PlayOneShot(sonido);
    }
}
