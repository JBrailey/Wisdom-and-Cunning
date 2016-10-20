using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    public Sprite fox, owl;
    public Transform leftAlignDialogue, rightAlignDialogue;

    Text leftAlignText, rightAlignText;
    Image leftAlignImage, rightAlignImage;

	// Use this for initialization
	void Start () {
        leftAlignText = leftAlignDialogue.GetChild(2).GetComponent<Text>();     // child 2 is text
        rightAlignText = rightAlignDialogue.GetChild(2).GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void UpdateDialogue(bool isFox, string text)
    {
        if (isFox)
        {
            ToggleAlignment(true);
            leftAlignText.text = text;
        }
        else if (!isFox)
        {
            ToggleAlignment(false);
            rightAlignText.text = text;
        }
    }

    public void CloseDialogue()
    {
        leftAlignDialogue.gameObject.SetActive(false);
        rightAlignDialogue.gameObject.SetActive(false);
    }

    void ToggleAlignment(bool isLeft)
    {
        if (isLeft) //Turn left on and right off
        {
            leftAlignDialogue.gameObject.SetActive(true);
            rightAlignDialogue.gameObject.SetActive(false);
        }
        else if (!isLeft) //Turn Right on & Left Off
        {
            leftAlignDialogue.gameObject.SetActive(false);
            rightAlignDialogue.gameObject.SetActive(true);
        }
    }
}
