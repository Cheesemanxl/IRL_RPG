using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToWorldScript : MonoBehaviour
{
    public void BackToWorld()
    {
        SceneManager.LoadScene(0);
    }
}
