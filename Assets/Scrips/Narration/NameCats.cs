using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameCats : MonoBehaviour
{
    public TextScroller textScroller;
    public GameObject catsObject;
    public GameObject catNamePanel;

    int currentCatIndex = 0;
    private List<Transform> catsObjectsList = new List<Transform>();

    void Start() 
    {
        // Inputpanel for setting names of cats
        catNamePanel.SetActive(false);
        foreach (Transform cat in catsObject.transform)
        {
            catsObjectsList.Add(cat);
            cat.gameObject.SetActive(false);
        }
        textScroller.AddScrollText("...");
        textScroller.AddScrollText("Well hello there, young one...");
        textScroller.AddScrollText("This one is yours, right?\n What's its name?");
        StartCoroutine(WaitThenActivateCat(3.8f, 0));
        
    }

    IEnumerator WaitThenActivateCat(float seconds, int catIndex) 
    {   
        this.currentCatIndex  = catIndex;
        yield return new WaitForSeconds(seconds);
        catsObjectsList[catIndex].gameObject.SetActive(true);
        this.catNamePanel.SetActive(true);
    }

    public void AddCatWithName(string name)
    {
        CatsData.catList.Add(new Cat(name));
        if (CatsData.catList.Count < 3)
        {
            catsObjectsList[currentCatIndex].gameObject.SetActive(false);
            this.catNamePanel.SetActive(false);
            textScroller.AddScrollText("What about this one?");
            StartCoroutine(WaitThenActivateCat(1.0f, this.currentCatIndex + 1));
        }
        else 
        {
            textScroller.AddScrollText("Wonderful...");
            GameObject.Find("IntroCanvas").SetActive(false);
        }
    }

    IEnumerator WaitThenDeactivateScene(float seconds, int catIndex) 
    {   
        this.currentCatIndex  = catIndex;
        yield return new WaitForSeconds(seconds);
        catsObjectsList[catIndex].gameObject.SetActive(true);
        this.catNamePanel.SetActive(true);
    }

}
