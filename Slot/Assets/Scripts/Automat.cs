using UnityEngine;
using System.Collections;

public class Automat : MonoBehaviour {

	public enum PanelTypes{
		Logo = 0, Zubr = 1, Forbes = 2
	}

	private const float blinkInterval = 0.25f;
	private const int pocetPanelu = 3;
	private float c;
	private Renderer[] panely;

	void Start () {
		panely = new Renderer[pocetPanelu];
		panely[(int)PanelTypes.Logo]=transform.FindChild("Logo").GetComponent<Renderer>();
		panely[(int)PanelTypes.Zubr]=transform.FindChild("Zubr").GetComponent<Renderer>();
		panely[(int)PanelTypes.Forbes]=transform.FindChild("Forbes").GetComponent<Renderer>();
		ZapniVypniPanel(PanelTypes.Logo,false);
		ZapniVypniPanel(PanelTypes.Zubr,true);
		ZapniVypniPanel(PanelTypes.Forbes,true);
		c=0f;
	}

	public void ZapniVypniPanel(PanelTypes panel, bool on){
		panely[(int)panel].enabled=on;
	}
	
	void Update () {
		c+=Time.deltaTime;
		if (c>blinkInterval){
			for (int i = 0; i < pocetPanelu; i++)
				panely[i].enabled=!panely[i].enabled;
			c-=blinkInterval;
		}
	}
}
