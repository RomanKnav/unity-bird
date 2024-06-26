using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// WE WILL BE MANAGING SCENES WITH THIS:
using UnityEngine.SceneManagement;

public class startLogic : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
