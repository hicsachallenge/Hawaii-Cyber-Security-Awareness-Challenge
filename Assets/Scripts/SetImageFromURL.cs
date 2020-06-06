using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class SetImageFromURL : MonoBehaviour{

	public Image img;
	public string url;

	IEnumerator Start()	{
		//Disable  annoying obsolete warning
		#pragma warning disable 0618		
		WWW www = new WWW(url);
		yield return www;
		img.sprite = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), new Vector2(0, 0));
		//Restore warnings
        #pragma warning restore 0618	
	}
}
