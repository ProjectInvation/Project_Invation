using UnityEngine;
using System.Collections;

public class FadeManager : SingletonMonoBehaviour<FadeManager> {

	private Texture2D black_texture;

	private float fade_alpha;

	private bool is_fading = false;

	public void Awake()
	{
		if (this != Instance) {
			Destroy (this);
			return;
		}

		DontDestroyOnLoad (this.gameObject);

		this.black_texture = new Texture2D(32,32,TextureFormat.RGB24,false);
		this.black_texture.ReadPixels(new Rect(0,0,32,32),0,0,false);
		this.black_texture.SetPixel (0, 0, Color.white);
		this.black_texture.Apply ();
	}

	public void OnGUI ()
	{
		if (!this.is_fading)
			return;
		GUI.color = new Color (0, 0, 0, this.fade_alpha);
		GUI.DrawTexture(new Rect(0,0,Screen.width, Screen.height), this.black_texture);	
	}

	public void LoadLevel(string scene, float interval)
	{
		StartCoroutine (TransScene (scene, interval));
	}

	private IEnumerator TransScene(string scene, float interval)
	{
		this.is_fading = true;
		float time = 0;
		while (time <= interval)
		{
			this.fade_alpha = Mathf.Lerp(0f,1f,time/interval);
			time += Time.deltaTime;
			yield return 0;
		}

		Application.LoadLevel (scene);

		time = 0;
		while (time <= interval)
		{
			this.fade_alpha = Mathf.Lerp(1f,0f,time/interval);
			time += Time.deltaTime;
			yield return 0;
		}
		this.is_fading = false;
	}
}
