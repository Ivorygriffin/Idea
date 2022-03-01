using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryTellingLabels : MonoBehaviour
{
    public StoryTelling ST;
    public string item;


    void Start()
    {
        ST = FindObjectOfType<StoryTelling>();
    }

    public void OnMouseDown()
    {
        ST.AddStoryItem(gameObject);
        
    }
}
