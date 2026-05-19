using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameLogic : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
         PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Dialogue");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
