using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MiniGameLabel : MonoBehaviour
{
    public string MiniGameName;
    public GameObject HG;
    public GameObject ST;
    public GameObject Scram;
    public UnityEvent DoThing;


    public void OnMouseDown()
    {
        if (GetComponent<MiniGameLabel>().MiniGameName == "hallucinationGas")
        {
            HG.SetActive(true);
            DoThing.Invoke();
            this.gameObject.SetActive(false);
        }
        if (GetComponent<MiniGameLabel>().MiniGameName == "storyTelling")
        {
            ST.SetActive(true);
            this.gameObject.SetActive(false);
            DoThing.Invoke();
        }
        if (GetComponent<MiniGameLabel>().MiniGameName == "scramble")
        {
            Scram.SetActive(true);
            DoThing.Invoke();
            this.gameObject.SetActive(false);
        }
    }

}
