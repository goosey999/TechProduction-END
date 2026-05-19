using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement; // Required for Scene switching


public class DialogeManager : MonoBehaviour
{
    public string[] dialogue = {};
    public int currentDialogue;

    public bool mingamePlayed = false;

    public TextMeshProUGUI DialogueText;

    void Start()
    {
     //Debug.Log(dialogue.Length);  

    }

    // Update is called once per frame
    void Update()
    {
     DialogueText.text = dialogue[currentDialogue];
    }

    public void NextDialogue()
    {
        if (currentDialogue < dialogue.Length - 1)
        {
            currentDialogue += 1;
        } 
        
        if(currentDialogue >= 4 && !mingamePlayed)
        {
            Debug.Log("Play Game");
            //SceneManager.LoadScene(sceneName:"Card-Game");
        }
    }
}
