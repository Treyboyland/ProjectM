using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_STANDALONE
        if (Input.GetButtonDown("Quit"))
        {
            Application.Quit();
        }
#endif
    }


}
