using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{
    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    public void RestartLevel()
    {
        int sceneBuildIndex = SceneManager.GetActiveScene().buildIndex; ;
        SceneManager.LoadScene(sceneBuildIndex);
    }             
}
