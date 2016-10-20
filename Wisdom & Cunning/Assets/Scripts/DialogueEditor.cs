using UnityEngine;
using System.Collections;

[System.Serializable]
public class Dialogue : System.Object
{
    public bool isFox;
    public string text;
}

public class DialogueEditor : MonoBehaviour
{

    public Dialogue[] dialogue;
    bool isShowingDialogue = false;
    bool isWritingText = false;
    bool isLeft;
    int dialogueIndex = 0;
    int length;

    int textIndex = 0;

    public GameObject dialogueManagerObject;
    DialogueManager dialogueManager;

    // Use this for initialization
    void Start()
    {
        dialogueManager = dialogueManagerObject.GetComponent<DialogueManager>();
        length = dialogue.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (isShowingDialogue)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                // If Text is being Written, Skip to end of Text
                if (isWritingText)
                {
                    textIndex = dialogue[dialogueIndex].text.Length;
                    dialogueManager.UpdateDialogue(dialogue[dialogueIndex].isFox, dialogue[dialogueIndex].text);
                    isWritingText = false;
                }
                // If Text is done being Written, Go to next Dialogue
                else
                {
                    if (dialogueIndex < length - 1)
                    {
                        dialogueIndex++;
                        if (isLeft)
                        {
                            isLeft = false;
                        }
                        else
                        {
                            isLeft = true;
                        }
                        // Write Dialogue
                        StartCoroutine(WriteDialogue());
                    }
                    else
                    {
                        dialogueManager.CloseDialogue();
                        gameObject.SetActive(false);
                    }
                }
            }
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (!isShowingDialogue)
        {
            if (col.gameObject.tag.Equals("Fox"))
            {
                StartDialogue();
            }
        }
    }

    public void StartDialogue()
    {
        //Just in case old Dialogue is on the screen
        dialogueManager.CloseDialogue();

        // Makes Dialogue Appear on Aligned to the Left
        isShowingDialogue = true;
        isLeft = true;
        StartCoroutine(WriteDialogue());
    }

    IEnumerator WriteDialogue()
    {
        // Set Length to 0
        textIndex = 0;

        // Set Writing Text to ture
        isWritingText = true;

        // Type Text one char at a time.
        string currentText = "";
        while (textIndex < dialogue[dialogueIndex].text.Length)
        {
            currentText += dialogue[dialogueIndex].text[textIndex++];
            dialogueManager.UpdateDialogue(dialogue[dialogueIndex].isFox, currentText);
            yield return new WaitForSeconds(0.0225f);
        }
        isWritingText = false;
    }
}
