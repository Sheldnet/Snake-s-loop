using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System.Collections;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI speakerName, dialogue, navButtonText;
    public Image speakerSprite;

    private int currentIndex;
    private Conversation currentConvo;
    private static DialogueManager instance;
    private Animator anim;
    private Coroutine Typing;


    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
            anim = GetComponent<Animator>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static void StartConversation(Conversation convo)
    {
        instance.anim.SetBool("DialBool", true);
        instance.currentIndex = 0;
        instance.currentConvo = convo;
        instance.speakerName.text = "";
        instance.dialogue.text = "";
        instance.navButtonText.text = " ";

        instance.ReadNext();
    }

    public void ReadNext()
    {
        if (currentIndex > currentConvo.GetLength())
        {
            instance.anim.SetBool("DialBool", false);
            return;
        }
        speakerName.text = currentConvo.GetlineByIndex(currentIndex).speaker.GetName();

        if (Typing == null)
        {
            Typing = instance.StartCoroutine(TypeText(currentConvo.GetlineByIndex(currentIndex).dialogue));
        }
        else
        {
            instance.StopCoroutine(Typing);
            Typing = null;
            Typing = instance.StartCoroutine(TypeText(currentConvo.GetlineByIndex(currentIndex).dialogue)); 
        }

        speakerSprite.sprite = currentConvo.GetlineByIndex(currentIndex).speaker.GetSprite();
        currentIndex++;
    }

    private IEnumerator TypeText(string text)
    {
        dialogue.text = "";
        bool complete = false;
        int index = 0;
        while (!complete)
        {
            dialogue.text += text[index];
            index++;
            yield return new WaitForSeconds(0.03f);
            if (index == text.Length)
            {
                complete = true;
            }
        }

        Typing = null;
    }
}
