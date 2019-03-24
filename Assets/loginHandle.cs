using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BayatGames.SaveGameFree;
public class loginHandle : MonoBehaviour
{
	public InputField username, password;//, confirmpassword;
	string[] usernames, passwords;
	bool found = false;
	public void signin()
	{
		loadup();
		for (int i = 0; i < usernames.Length; i++)
		{
			if (username.text.ToString() == usernames[i])
			{
				found = true;
				if (password.text.ToString() == passwords[i])
				{
					Debug.Log("success");
				}
			}
		}
	}
	public void loadup()
	{
		usernames = SaveGame.Load<string[]>("usernames");
		passwords = SaveGame.Load<string[]>("passwords");
	}
}
