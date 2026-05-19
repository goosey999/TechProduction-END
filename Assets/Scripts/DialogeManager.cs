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

    public GameObject Colin;
    public GameObject Phillip;

    void Start()
    {
        if(!PlayerPrefs.HasKey("currentDialogIndex"))
        {
             PlayerPrefs.SetInt("currentDialogIndex",currentDialogue);
           
        }


        currentDialogue =  PlayerPrefs.GetInt("currentDialogIndex");
    }

    // Update is called once per frame
    void Update()
    {
     DialogueText.text = dialogue[currentDialogue];

     if (dialogue[currentDialogue].Contains("Colin"))
        {
            Debug.Log("Colin!");
            Colin.SetActive(true);
            Phillip.SetActive(false);
            
        } else if (dialogue[currentDialogue].Contains("Phillip:"))
        {
            Debug.Log ("Phillip!");
            Colin.SetActive(false);
            Phillip.SetActive(true);
        }

    
    }

    public void NextDialogue()
    {
        if (currentDialogue < dialogue.Length - 1)
        {
            currentDialogue += 1;
            PlayerPrefs.SetInt("currentDialogIndex",currentDialogue + 1);
        } 
        
        if(currentDialogue > 4 && !mingamePlayed)
        {
            Debug.Log("Play Game");
            SceneManager.LoadScene(sceneName:"Card-Game");
        }
    }
}
