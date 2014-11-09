using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class panelScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void OnClick(string type) // what to populate the panel with
	{
		if(gameObject.activeSelf)
			gameObject.SetActive(false);
		else 
			gameObject.SetActive(true);
		Debug.Log(type);
	}
}
