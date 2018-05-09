using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour {

    // Use this for initialization
    virtual public void OnStart() { }
	
	// Update is called once per frame
	virtual public bool OnUpdate() { return false; }

    virtual public void OnEnd() { }
}
