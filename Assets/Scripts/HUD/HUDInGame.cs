using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class HUDInGame : MonoBehaviour {
	public Text scoreText;
	public Text timeText;
	public Text gotItemListText;
	public StopWatch stopWatch;
	public static Int32 scoreInt = 0;
	public static Int32 itemScore = 0;
	public static Int32 scoretimeBonus = 0;
	Hashtable gotItemNumberList;
	String gotItemListLabelString;
	String gotItemListString;
	Boolean isClear = false;

	// Use this for initialization
	void Start () {
		scoreText.text = "Score: 0";
		timeText.text = "Time: 0";
		stopWatch = new StopWatch ();//Default State is Zero.
		stopWatch.changeState ();//State: Zero to Play.

		//initialize of gotItemNumberList.
		this.gotItemNumberList = new Hashtable ();
		this.gotItemNumberList.Add ("yakisoba", 0);
		this.gotItemListString = "";
		this.gotItemListLabelString = "取得したアイテム\n\n";
		this.gotItemListString = this.gotItemListLabelString;
	}
	
	// Update is called once per frame
	void Update () {
		stopWatch.update ();
		UpdateTime ();
		UpdateScore ();
		UpdateGotItemList ();
	} 

	void UpdateTime(){
		timeText.text = "Time: " + stopWatch.getCurrentTimeString ();
	}

	void UpdateScore(){
		this.scoreText.text = "Score: " + HUDInGame.getCurrentTotalScore();
	}

	void UpdateGotItemList(){
		this.gotItemListText.text = this.gotItemListString;
	}

	void addYakisobaScore(){
		HUDInGame.addScore (1000);//Yakisoba is 1000Pt?
		HUDInGame.itemScore += 1000;
		incrementNumberOfGotYakisoba();
		if ((Int32)this.gotItemNumberList ["yakisoba"] != (Int32)0) {
			this.gotItemListString = this.gotItemListLabelString + "インディアン焼きそば " + (Int32)this.gotItemNumberList["yakisoba"] + " 個";
		}

	}

	void goal(){
		Debug.Log ("Goal!!!!!");
		Debug.Log(stopWatch.getTimeBonus());
		HUDInGame.scoretimeBonus = stopWatch.getTimeBonus ();
		HUDInGame.scoreInt += HUDInGame.scoretimeBonus;// Add TimeBonus.

		if (!isClear) {
			this.isClear = true;
			FadeManager.Instance.LoadLevel ("Clear", 0.5f);
		}
	}

	void incrementNumberOfGotYakisoba(){
		Int32 tmp = (Int32)this.gotItemNumberList["yakisoba"];
		tmp += 1;
		this.gotItemNumberList ["yakisoba"] = tmp;
	}

	public static int getCurrentTotalScore(){
		return HUDInGame.scoreInt;
	}
	public static void addScore(Int32 score){
		HUDInGame.scoreInt += score;
		Debug.Log(HUDInGame.scoreInt);
	}
}

public class StopWatch{
	public TextMesh timeText;
	public String timeString;
	StopwatchState state = StopwatchState.Zero;
	TimeSpan lastStopTimeSpan;
	DateTime startDateTime;
	Int32 timeBonus;

	enum StopwatchState {
		Zero,
		Play,
		Pause
	}

	public void update () {
		UpdateTime();
	}

	public void changeState() {
		if (state == StopwatchState.Pause) {
			lastStopTimeSpan = new TimeSpan(0);
			startDateTime = DateTime.UtcNow;
			state = StopwatchState.Zero;
		} else if (state == StopwatchState.Play) {
			TimeSpan ts = DateTime.UtcNow - startDateTime;
			lastStopTimeSpan = ts + lastStopTimeSpan;
			state = StopwatchState.Pause;
		} else {
			startDateTime = DateTime.UtcNow;
			state = StopwatchState.Play;
		}
	}
	void UpdateTime() {
		TimeSpan currentTs;
		if (state == StopwatchState.Play) {
			TimeSpan ts = DateTime.UtcNow - startDateTime;
			currentTs = ts + lastStopTimeSpan;
		} else {
			currentTs = lastStopTimeSpan;
		}
		this.timeString = ConvertTimeSpanToString(currentTs);
		this.timeBonus = (Int32)(500000/currentTs.TotalSeconds);
	}
	static public string ConvertTimeSpanToString(TimeSpan ts) {
		if (ts.Hours > 0 || ts.Days > 0) {
			return string.Format("{0}:{1:D2}:{2:D2}.{3}", ts.Days * 24 + ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds.ToString("000").Substring(0, 2));
		} else {
			return string.Format("{0}:{1:D2}.{2}", ts.Minutes, ts.Seconds, ts.Milliseconds.ToString("000").Substring(0, 2));
		}

	}
	public string getCurrentTimeString(){
		return this.timeString;
	}
	public Int32 getTimeBonus(){
		return this.timeBonus;
	}
}
