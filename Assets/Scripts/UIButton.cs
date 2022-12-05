using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIButton : MonoBehaviour
{
    public Button gameStart;
    [SerializeField]AudioSource audioSource;
    [SerializeField] AudioClip audioClip;

    void Start()
    {
        gameStart = GetComponent<Button>();
        gameStart.onClick.AddListener(InGame);
        audioSource = GetComponent<AudioSource>();
    }

    public void InGame()
    {
        StartCoroutine(LoadGame());
        
    }

    public IEnumerator LoadGame()
    {
        audioSource.Play();
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("InGame");
    }
}
