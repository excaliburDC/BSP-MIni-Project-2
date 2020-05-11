using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class DialogueManager : MonoBehaviour
{
    public GameObject DialogueButtons;
    public Text speakerText;
    public Text dialogueText;
    public Animator Anim;
    private Queue<string> sentences;

     void Start()
    {
        sentences = new Queue<string>();
        DialogueButtons.SetActive(true);
    }
   
    public void StartDialogue(Dialogue dialogue)
    {
        DialogueButtons.SetActive(false);
        Anim.SetBool("IsOpen", true);
        speakerText.text = dialogue.name;
        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }
    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
        
    }
    void EndDialogue()
    {
        Anim.SetBool("IsOpen", false);
        Debug.Log("End of dialogue");
        SceneManager.LoadSceneAsync("MainMenu");
        
    }
    public void skipStory()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
