using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SendToGoogleForm : MonoBehaviour {

	public InputField nameField;
	public InputField emailField;
	public InputField passwordField;
	public InputField phoneField;
	// Use this for initialization

	private string name;
	private string email;
	private string password;
	private string phone;

	[SerializeField]
	private string Base_Url="https://docs.google.com/forms/d/e/1FAIpQLScwI1QHYZ2q0ukqHzkU_LCEMd8N3tXLs9iyELO8r8ohxiEhuA/formResponse";


	public void SendToForm()
	{
		name = nameField.text;
		email = emailField.text;
		password = passwordField.text;
		phone = phoneField.text;
		StartCoroutine (Post (name, email, password, phone));
	}

	IEnumerator Post(string _name,string _email,string _password,string _phone)
	{
		WWWForm wwwForm = new WWWForm ();
		wwwForm.AddField ("entry.517888982", _name);
		wwwForm.AddField ("entry.1977940867", _email);
		wwwForm.AddField ("entry.1411039564", _password);
		wwwForm.AddField ("entry.1932588167", _phone);
		byte[] formData = wwwForm.data;
		WWW www = new WWW (Base_Url, formData);
		yield return www;
	}
}

