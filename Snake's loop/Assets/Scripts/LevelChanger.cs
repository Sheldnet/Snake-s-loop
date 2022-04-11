using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public Animator anim;
    public BoxCollider2D trig;
    public int scenIndex;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Snakeboi")
        {
            StartCoroutine(LoadScene());
        }
    }


    IEnumerator LoadScene()
    {
        anim.SetTrigger("End");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(scenIndex);
    }
}
