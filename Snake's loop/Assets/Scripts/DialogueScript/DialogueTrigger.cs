using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Conversation convo;
    public BoxCollider2D trigger;
    public bool CanMove;

    public void StartConvo()
    {
        DialogueManager.StartConversation(convo);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Snakeboi")
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                DialogueManager.StartConversation(convo);
            }
        }
    }
}
