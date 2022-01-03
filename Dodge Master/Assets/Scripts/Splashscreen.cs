using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Splashscreen : MonoBehaviour
{
    // Start is called before the first frame update
    // Mengatur durasi Splashscreen untuk tampil selama 3 detik
    public float time = 3f;
    void Start()
    {
        
    }

    // Update is called once per frame
    // Pindahkan ke Menu Scene setelah Splashscreen selesai tampil
    void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
        }
        else
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
