using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HGIngredient : MonoBehaviour
{
    public GameObject HG;
    public string ingredientName;
    public MeshRenderer item;
    public Material materialToAssign, original;

    public void OnMouseDown()
    {
        HG.GetComponent<HallucinationGas>().AddToList(gameObject);
        ChangeItemColor();
       
    }
    void ChangeItemColor()
    {
        item.material = materialToAssign;
        StartCoroutine(ChangeOnClick());
    }

    public IEnumerator ChangeOnClick()
    {
        yield return new WaitForSeconds(0.5f);
        item.material = original;
    }

}
