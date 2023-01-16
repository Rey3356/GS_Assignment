using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Driver : MonoBehaviour
{
    public Sc_Ob scob;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < scob.TheList.Count; i++)
        {
            GameObject obj = new GameObject("obj" + i.ToString());//Creating parent object that will contain the image component and be positioned at vector 2 component.
            PrimObj(i, obj);// Providing transform values and adding sprite        

            GameObject obj_c = new GameObject("Tchild" + i.ToString());//Creating child object for the parent object
            obj_c.transform.parent = obj.transform;//Turning it into child object to contain textmeshpro.text Component to display int value
            childObj(i, obj_c);//Adding and adjusting the textmeshpro component
        }
    }

    void PrimObj(int i, GameObject obj)
    {
        obj.GetComponent<Transform>().position = scob.TheList[i].vec_2; //Inherits vector 2 value from list item
        obj.GetComponent<Transform>().rotation = Quaternion.identity; //Sets rotation to identity of the gameobject
        obj.AddComponent<SpriteRenderer>().sprite = scob.TheList[i].image; //adds sprite renderer to object and adds the inherited sprite image
    }

    void childObj(int i, GameObject obj_c)
    {
        obj_c.AddComponent<TextMeshPro>(); //Adds textmeshpro Component to child object
        obj_c.GetComponent<RectTransform>().sizeDelta = new Vector2(2, 2); // Adjusts the RectTranform height and width
        obj_c.GetComponent<RectTransform>().localPosition = new Vector3(-2.5f, -0.2f, 0f); //Adjust thes the local positions of the child object
        TextMeshPro tmp = obj_c.GetComponent<TextMeshPro>();
        tmp.SetText(scob.TheList[i].IntEger.ToString()); // Inputs the int value inherited from the list as text for TMP
        tmp.fontSize = 15f; //Sets font size.
    }
}
