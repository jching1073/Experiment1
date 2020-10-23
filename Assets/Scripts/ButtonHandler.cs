using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;

public class ButtonHandler : MonoBehaviour
{
   
    // Update is called once per frame
    public void ChangeScene(int sceneToChange)
    {
        Application.LoadLevel(sceneToChange);
    }
}
