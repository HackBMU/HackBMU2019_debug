﻿using UnityEngine;
using UnityEngine.UI;
using Firebase.Auth;
using Firebase;
using UnityEngine.SceneManagement;
using BayatGames.SaveGameFree;
public class FirebaseScript : MonoBehaviour
{
	public string[] tu, tp;
	int i = 0;
	public InputField email, password, confirmpassword;
	public InputField name, age;
    public void loginbutton()
	{
		FirebaseAuth.DefaultInstance.SignInWithEmailAndPasswordAsync(email.text, password.text).ContinueWith((obj) =>
		{
			SceneManager.LoadSceneAsync(4);
		});
	}

	public void signup_button()
	{
		if (password.text == confirmpassword.text)
		{
			if(SaveGame.Load<string[]>("usernames").Length != 0)
			{
				i = SaveGame.Load<string[]>("usernames").Length;
			}
			tu = SaveGame.Load<string[]>("usernames");
			Debug.Log(tu.Length);
			tu[i] = name.text.ToString();

			SaveGame.Save<string[]>("usernames", tu);
			tp = SaveGame.Load<string[]>("passwords");
			tp[i++] = password.text.ToString();

			FirebaseAuth.DefaultInstance.CreateUserWithEmailAndPasswordAsync(email.text, password.text).ContinueWith((obj) =>
			{
				SceneManager.LoadSceneAsync(3);
			});
		}
		else
		{
			Debug.Log("unsuccessful");
		}
	}
}
