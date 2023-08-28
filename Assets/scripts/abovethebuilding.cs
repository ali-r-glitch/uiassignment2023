using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class abovethebuilding : MonoBehaviour
{
    public bool isontop;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("pleas sir");
        isontop = true;
    }
    private void OnTriggerExit(Collider other)
    {
        isontop = false;
    }
}
