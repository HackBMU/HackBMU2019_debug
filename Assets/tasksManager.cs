﻿using UnityEngine;
using UnityEngine.UI;
using BayatGames.SaveGameFree;
public class tasksManager : MonoBehaviour
{
	public Text t, t1, t2, t3;
	public Text task, points, showdate, waittill;
	public string date = "MM-dd";
	public string timelimit = "In Minutes";
	public string task_description;
	public int pointsfortask = 2;
	public GameObject taskcompletedshow, content;

	public bool empty;
	public Text task_s, date_s;

	bool accepted = false;
	string time, endtime;
	int minutes;
	// Start is called before the first frame update
	void Start()
    {
		string day = System.DateTime.Now.ToString("MM-dd");
		if (day == date)
		{
			task.text = task_description;
			points.text = "GAIN " + pointsfortask.ToString() + " POINTS";
			showdate.text = day.Substring(3, 2) + " / " + day.Substring(0, 2);
			date_s.text = showdate.text;
			task_s.text = task_description;
			SaveGame.Save<int>("c", SaveGame.Load<int>("c",0) + 1);
			taskvalues();
		}
	}

	public void accepted_function()
	{
		time = System.DateTime.Now.ToString("HH:mm");
		accepted = true;
		endtime = time.Substring(0,2)+":"+(int.Parse(time.Substring(3, 2))+int.Parse(timelimit)).ToString("#00");
		Debug.Log("endtime" + endtime + " currenttime" + System.DateTime.Now.ToString("HH:mm"));
		waittill.text = endtime;
		SaveGame.Save<int>("c1", SaveGame.Load<int>("c1", 0) + 1);
		taskvalues();
	}

	private void Update()
	{
		if (accepted == true)
		{
			if (System.DateTime.Now.ToString("HH:mm").ToString() == endtime)
			{
				Debug.Log("did you complete the task?");
				taskcompletedshow.SetActive(true);
				content.SetActive(false);
				accepted = false;
			}
		}
	}

	public void taskvalues()
	{
		t.text = SaveGame.Load<int>("c", 0).ToString();
		t1.text = SaveGame.Load<int>("c1", 0).ToString();
		t3.text = SaveGame.Load<int>("c3", 0).ToString();
		t2.text = ((float)SaveGame.Load<int>("c3", 0) / SaveGame.Load<int>("c", 0) *100).ToString("f2") + "%";
	}

}
