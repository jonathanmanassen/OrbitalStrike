using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour {

    IEnumerator ShakeIt()
    {
        for (int i = 0; i < 5; i++)
        {
            transform.Rotate(0, 0, 5);
            yield return null;
        }
        for (int i = 0; i < 10; i++)
        {
            transform.Rotate(0, 0, -5);
            yield return null;
        }
        for (int i = 0; i < 5; i++)
        {
            transform.Rotate(0, 0, 5);
            yield return null;
        }
    }

    public void shakeF()
    {
        StartCoroutine(ShakeIt());
    }
}
