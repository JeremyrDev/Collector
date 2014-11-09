using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class objectScript : MonoBehaviour {
	public Text showText;
	Vector2 end;
	float randomX = 0;
	float opacity = 1;
	// Use this for initialization
	void Start () {
	
	}
	void OnEnable()
	{
		transform.position = new Vector2(1.5f,.85f);
		transform.localScale = new Vector3(1,1,1);
		showText.text = "+50";
		randomX = Random.Range(-1.8f,3.8f);
		Debug.Log(randomX.ToString());
		//end = new Vector2(Random.Range(-.8f,3.2f), Random.Range(1.8f,2.4f));//for higher pulse interval
		end = new Vector2(Random.Range(0f,3.0f), Random.Range(1.8f,2.4f));
		Invoke("remove", 10);
		opacity =1;
	}
	void remove()
	{
		gameObject.SetActive(false);
	}
	public void begin(float amount)
	{
		showText.text = amount.ToString("f0");
	}
	
	// Update is called once per frame
	void Update () 
	{
		opacity = Mathf.Lerp(opacity, 0, Time.deltaTime * 1.4f);
		showText.color =  new Color(.15f,.85f,.25f, opacity);
		transform.position = Vector3.Lerp(transform.position, end, Time.deltaTime * 10);
	}
}
