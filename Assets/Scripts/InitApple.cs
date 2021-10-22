using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitApple : MonoBehaviour
{
    public static int counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.name = (counter++).ToString();
    }
}
