using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tester : MonoBehaviour
{
    public Conversation convo;
    public void StartConvo()
    {
        DialogueManager.StartConversation(convo);
    }

    //private void OnTriggerStay2D(Collider2D collision)
    //{
     //   if (collision.gameObject.name )
    //}
}
