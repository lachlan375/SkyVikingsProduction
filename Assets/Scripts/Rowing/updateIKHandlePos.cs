using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class updateIKHandlePos : MonoBehaviour {

	public Transform handlePos;

	// Update is called once per frame
	void Update () {
		transform.position = handlePos.position;
	}
}
