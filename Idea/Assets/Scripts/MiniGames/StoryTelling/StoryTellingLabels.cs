using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryTellingLabels : MonoBehaviour
{
    public GameObject ST;
    public string item;


    
    public void OnMouseDown()
    {
        ST.GetComponent<StoryTelling>().AddStoryItem(gameObject);
        
    }
}
