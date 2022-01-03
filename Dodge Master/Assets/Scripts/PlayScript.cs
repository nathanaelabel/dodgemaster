using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    // Pindahkan ke Main Scene untuk bermain Level 1
    public void startGame()
    {
        SceneManager.LoadScene("Main");
    }

    // Keluar dari aplikasi
    public void Exit()
    {
        Application.Quit();
    }
}
