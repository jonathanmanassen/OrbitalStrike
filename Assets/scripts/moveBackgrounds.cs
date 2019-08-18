using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBackgrounds : MonoBehaviour {

    public Transform Higher;
    public Transform Lower;
    [Range(0f, 7f)]
    public float speed = 0.1f;

    public bool twoD;

	void Update ()
    {
        if (speed > 7f)
            speed = 7f;
        if (speed < 0f)
            speed = 0f;
        Vector3 move;
        if (twoD)
            move = new Vector3(0, -speed / 10f, 0);
        else
            move = new Vector3(0, 0, -speed / 10f);
        Lower.transform.localPosition += move;
        Higher.transform.localPosition += move;
		if ((twoD && Lower.localPosition.y < -8) || (!twoD && Lower.localPosition.z < -8))
        {
            Transform tmp;
            if (twoD)
                Lower.transform.localPosition += new Vector3(0, 20, 0);
            else
                Lower.transform.localPosition += new Vector3(0, 0, 20);
            tmp = Higher;
            Higher = Lower;
            Lower = tmp;
        }
	}
}
