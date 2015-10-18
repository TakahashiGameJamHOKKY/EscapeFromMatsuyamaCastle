using UnityEngine;
using System.Collections;

public class SatietyGauge : MonoBehaviour {
	private RectTransform rectTransform;
	private UnitychanCtrl unityChan;

	// Use this for initialization
	void Start () {
		rectTransform = GetComponent<RectTransform> () as RectTransform;
		unityChan = GameObject.FindGameObjectWithTag("UnityChan").GetComponent<UnitychanCtrl> () as UnitychanCtrl;
	}
	
	// Update is called once per frame
	void Update () {
		rectTransform.sizeDelta = new Vector2 (800 * unityChan.Satiety / 100f, 50);
	}
}
