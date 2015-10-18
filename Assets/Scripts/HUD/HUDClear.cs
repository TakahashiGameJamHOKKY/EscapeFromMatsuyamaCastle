using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUDClear : MonoBehaviour {
	public Text scoreText;
	public Text timeBonusText;
	public Text gotItemListText;
	public Text totalScore;

	// Use this for initialization
	void Start () {
		this.gotItemListText.text = "取得したアイテム\n\nインディアン焼きそば x 2\n\n" + HUDInGame.itemScore + " 点";

		HUDInGame.getCurrentTotalScore();
		this.timeBonusText.text = "クリアタイムボーナス\n\n" + HUDInGame.scoretimeBonus + " 点";

		this.totalScore.text = "合計　" + HUDInGame.scoreInt+ " 点";
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
