using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCanvas : MonoBehaviour
{
    [SerializeField] private GameObject normalCrosshair;
    [SerializeField] private GameObject interactCrosshair;

    
    public void InteractCrosshair(bool interact)
    {
        normalCrosshair.SetActive(!interact);
        interactCrosshair.SetActive(interact);
    }

    public void NormalCrosshair(bool state)
    {
        normalCrosshair.SetActive(state);
    }
}
