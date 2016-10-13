using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    public Sprite foxLeft, foxRight, owlLeft, owlRight;
    public Transform leftAlignDialogue, rightAlignDialogue;

    Text leftAlignText, rightAlignText;
    Image leftAlignImage, rightAlignImage;

	// Use this for initialization
	void Start () {
        leftAlignImage = leftAlignDialogue.GetChild(1).GetComponent<Image>();   // child 1 is Image
        rightAlignImage = rightAlignDialogue.GetChild(1).GetComponent<Image>();
        leftAlignText = leftAlignDialogue.GetChild(2).GetComponent<Text>();     // child 2 is text
        rightAlignText = rightAlignDialogue.GetChild(2).GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void UpdateDialogue(bool isLeft, bool isFox, string text)
    {
        if (isLeft)
        {
            ToggleAlignment(true);
            leftAlignImage.sprite = ReturnSprite(isLeft, isFox);
            leftAlignText.text = text;
        }
        else if (!isLeft)
        {
            ToggleAlignment(false);
            rightAlignImage.sprite = ReturnSprite(isLeft, isFox);
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

    Sprite ReturnSprite(bool isLeft, bool isFox)
    {
        if (isLeft)
        {
            if (isFox)
            {
                return foxLeft;
            }
            else
            {
                return owlLeft;
            }
        }
        else
        {
            if (isFox)
            {
                return foxRight;
            }
            else
            {
                return owlRight;
            }
        }
    }
}
