using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CodePanel : MonoBehaviour
{

	[SerializeField]
	Text codeText;
	string codeTextValue = "";

	// Update is called once per frame
	void Update()
	{
		codeText.text = codeTextValue;

		if (codeTextValue == "12345")
		{
			Cat.isSafeOpened = true;
		}

		if (codeTextValue.Length >= 5)
			codeTextValue = "";
	}

	public void AddDigit(string digit)
	{
		codeTextValue += digit;
	}

}
