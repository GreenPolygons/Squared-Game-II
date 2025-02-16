using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalScene : MonoBehaviour
{
    private bool changeTransparency;
    private SpriteRenderer sprite;
    float fadeAmount;
    [SerializeField] private GameObject theEnd;

    private void Update() {
        if(changeTransparency){
            fadeAmount += Time.deltaTime / 70;
            Debug.Log(fadeAmount);
            sprite.color = new Color(0,0,0,fadeAmount);
        }

        if(fadeAmount >= 1){
            theEnd.SetActive(true);
            StartCoroutine(LoadMenu());
        }
    }

    public void StartFading(){
        sprite = GameObject.FindGameObjectWithTag("Finish").GetComponent<SpriteRenderer>();
        changeTransparency = true;
    }

    IEnumerator LoadMenu(){
        GameObject SteamAchievementsManager = GameObject.FindGameObjectWithTag("MainCamera");
        SteamAchievementsManager.GetComponent<SteamAchievementsManager>().UnlockAchievement("finish_ach");
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(1);
    }
}
