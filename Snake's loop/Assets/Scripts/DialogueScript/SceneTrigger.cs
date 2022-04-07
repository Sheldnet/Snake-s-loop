using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTrigger : MonoBehaviour
{
    public Conversation maintalk;
    public BoxCollider2D trigger;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Snakeboi")
        {
            DialogueManager.StartConversation(maintalk);
            trigger.enabled = false;
        }
    }
}