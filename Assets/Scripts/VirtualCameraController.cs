using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class VirtualCameraController : MonoBehaviour
{
    public List<GameObject> virtualCameras;
    // Start is called before the first frame update
    void Start()
    {
        virtualCameras.Clear();
        for (int i = 0; i < transform.childCount; i++) 
        {
            virtualCameras.Add(transform.GetChild(i).gameObject);
        }
    }

  public void TransitionTo(GameObject cameraToTransitionTo)
    {
        foreach (GameObject g in virtualCameras)
        {
            if(g == cameraToTransitionTo)
            {
                //transition to that camera
                g.GetComponent<CinemachineVirtualCamera>().Priority = 11;
            }
            else
            {
                // Deprirotixe camera
                g.GetComponent<CinemachineVirtualCamera>().Priority = 5;
            }
        }
    }
}
