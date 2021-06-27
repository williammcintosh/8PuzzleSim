using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    public GameObject SimManager;
    SimManagerScript simScript;
    public GameObject mainMenuOverlay;
    // Start is called before the first frame update
    void Awake()
    {
        if (mainMenuOverlay != null)
            mainMenuOverlay.SetActive(true);
        if (SimManager != null)
            simScript = SimManager.GetComponent<SimManagerScript>();
    }
    public void StartSim()
    {
        if (mainMenuOverlay != null)
            mainMenuOverlay.SetActive(false);
        if (simScript != null)
            simScript.StartSim(this);
    }
    public void GoBack()
    {
        if (mainMenuOverlay != null)
            mainMenuOverlay.SetActive(true);
    } 
}
