using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class CutsceneChanger : MonoBehaviour
{
    public Animator anim;
    public int scenIndex;
    public GameObject scenebox;

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if (scenebox.activeSelf==false)
            {
                StartCoroutine(LoadScene());
            }
        }
    }


    IEnumerator LoadScene()
    {
        anim.SetTrigger("End");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(scenIndex);
    }
}