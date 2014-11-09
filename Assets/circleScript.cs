using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class circleScript : MonoBehaviour {
	public GameObject canvas;
	public GameObject o;
	List<GameObject> objects;
	public int numberOfObjects = 20;

	public GameObject animatedCircle;
	public GameObject animatedCircleOut;
	public GUIText scoreText;
	public GUIText infoText;
	float amountToShow = 0;

	float timer = 0;
	//float pulseTimer = 0;
	float interval = 2.5f;
	float score = 0;
	float scoreCounter = 0;
	float toVal = 0;
	float tempCounter = 0;

	bool starttParamCounter = false;
	float lerpSpeed = .5f;
	float tParam = 0;
	int multiplier = 1;
	Vector3 scaleTo = new Vector3(0,0,0);
	Vector3 scaleToOut = new Vector3(3,3,3);
	float opacity = 1;
	Color greenish = new Vector4(.5f,1,.1f,1);
	Color blue = new Vector4(.1f,.75f,1f,1);
	Color blue2 = new Vector4(.05f,.9f,1f,1);
	Color circleColor;
	void Start () 
	{
		circleColor = blue2;
		objects = new List<GameObject>();
		for(int i = 0; i < numberOfObjects; i++)
		{
			GameObject obj = (GameObject)Instantiate(o);
			obj.SetActive(false);
			obj.transform.SetParent(canvas.transform);
			objects.Add(obj);
		}
	}

	void Update () 
	{
		if(Input.GetKeyUp(KeyCode.U))
			multiplier+=1;
		if(Input.GetKeyUp(KeyCode.D))
			if(infoText.enabled)
				infoText.enabled = false;
			else
				infoText.enabled = true;
		scoreText.text = score.ToString("n0");
		infoText.text = tempCounter+"\n"+tParam+"\n"+score+"\n"+toVal+"\n"+multiplier+"\n"+numberOfObjects;

		//tempCounter += 1*multiplier;
		timer+=1*Time.deltaTime;
//		pulseTimer+=1*Time.deltaTime;
//		if(pulseTimer > .25f)
//		{
//			pulseTimer = 0;
//			pulse();
//		}
		if(timer >= interval)
		{
			tempCounter +=50*multiplier;
			starttParamCounter = true;
			toVal = tempCounter;
			animatedCircle.transform.localScale = new Vector3(1f, 1f, 1f);
			animatedCircleOut.transform.localScale = new Vector3(1f, 1f, 1f);
			timer = 0;
			opacity = 1;
			//scoreText.transform.position = new Vector3(.5f, .905f, 0);
			scoreText.color = Color.green;
			amountToShow = toVal;
			pulse();
		}
		//scoreText.transform.position = Vector3.Lerp(scoreText.transform.position, new Vector3(.5f, .9f, 0), Time.deltaTime * 10);
		animatedCircle.transform.localScale = Vector3.Lerp(animatedCircle.transform.localScale, scaleTo, 1.8f*Time.deltaTime);
		animatedCircleOut.transform.localScale = Vector3.Lerp(animatedCircleOut.transform.localScale, scaleToOut, .5f*Time.deltaTime);
		//scoreText = Mathf.Lerp(score, toVal, Time.deltaTime * 2);
		score = Mathf.Lerp(score, toVal, Time.deltaTime * 2);
		opacity = Mathf.Lerp(opacity, 0, Time.deltaTime * 20);
		animatedCircleOut.renderer.material.color =  new Color(1, 1, 1, opacity);
		scoreText.color = Color.Lerp(scoreText.color, blue, Time.deltaTime * 5);
		renderer.material.color = Color.Lerp(renderer.material.color, circleColor, Time.deltaTime * 2);
		//animatedCircle.renderer.material.color =  new Color(1, 1, 1, opacity);
		/*
		if(tParam >= 1)
		{
			tParam = 0;
			score = toVal;
			starttParamCounter = false;
		}
		if(tParam < 1)
		{
			if(starttParamCounter)
				tParam += Time.deltaTime * lerpSpeed;
			scoreCounter = Mathf.Lerp(score, toVal, tParam);
		}*/
	}
	void OnMouseDown()
	{
		tempCounter += 1*multiplier;
		pulse ();
	}
	void OnMouseOver()
	{
		circleColor = greenish;
	}
	void OnMouseExit()
	{
		circleColor = blue2;
	}
	public void pulse()
	{
		int counter = 0;
		for(int i = 0; i < numberOfObjects;i++)
		{
			if(!objects[i].activeInHierarchy)
			{
				//objects[i].transform.position = new Vector3(0, 10, -1);
				//objects[i].begin(amountToShow); // starts begin function in object with the amount of points gained to show
				objects[i].SetActive(true);
				return;
			}
			counter++;
			if(counter == numberOfObjects)
			{
				GameObject obj = (GameObject)Instantiate(o);
				obj.SetActive(false);
				obj.transform.SetParent(canvas.transform);
				objects.Add(obj);
				numberOfObjects++;
				obj.SetActive(true);
				return;
			}
		}
	}
}
