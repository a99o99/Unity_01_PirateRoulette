using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIButton : MonoBehaviour
{
    public Button gameStart;

    void Start()
    {
        gameStart = GetComponent<Button>();
        gameStart.onClick.AddListener(InGame);
    }

    public void InGame()
    {
        SceneManager.LoadScene("InGame");
    }
}
