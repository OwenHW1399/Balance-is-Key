using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR.Haptics;

public class ToggleAccessories : MonoBehaviour
{
    private GameObject child, hat, belt;

    public int player;
    // Start is called before the first frame update
    void Start()
    {
        child = gameObject;
        for (int i = 0; i < 1; i++)
        {
            // Debug.Log(child.name);
            child = child.transform.GetChild(0).gameObject;
        }
        child = child.transform.GetChild(1).gameObject;
        child = child.transform.GetChild(1).gameObject;
        child = child.transform.GetChild(0).gameObject;
        belt = child.transform.GetChild(0).gameObject;
        hat = child.transform.GetChild(1).gameObject;
        // Debug.Log(belt.name);
        // Debug.Log(hat.name);
    }

    public void ToggleHat()
    {
        StaticClass.hatEnabled[player] = !StaticClass.hatEnabled[player];
        hat.SetActive(StaticClass.hatEnabled[player]);
    }

    public void ToggleBelt()
    {
        StaticClass.beltEnabled[player] = !StaticClass.beltEnabled[player];
        belt.SetActive(StaticClass.beltEnabled[player]);
    }
}
