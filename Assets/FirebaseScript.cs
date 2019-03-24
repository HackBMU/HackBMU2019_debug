using UnityEngine;
using UnityEngine.UI;
using Firebase.Auth;
using Firebase;
using UnityEngine.SceneManagement;
using BayatGames.SaveGameFree;
public class FirebaseScript : MonoBehaviour
{
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
		SaveGame.Save<int>("age", int.Parse(age.text.ToString()));
		SaveGame.Save<string>("name", name.ToString());
		if (password.text == confirmpassword.text)
		{
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
