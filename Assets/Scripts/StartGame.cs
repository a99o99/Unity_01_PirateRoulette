using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{

    void Start()
    {
        Object startScene = Resources.Load("CanvasStart");
        Instantiate(startScene);
    }

}
