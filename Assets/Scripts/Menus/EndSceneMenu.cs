using UnityEngine;
using UnityEngine.SceneManagement;

public class EndSceneMenu : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnApplicationQuit()
    {
        SceneManager.LoadScene("00_MenuScene");
    }
}
