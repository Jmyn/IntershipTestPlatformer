using UnityEngine;
using System.Collections;

public class GUIDisplay : MonoBehaviour {

    private bool showHUD = true;
    private string msg = "";
    void OnGUI()
    {
        if(showHUD) {
            GUI.TextArea(new Rect(0, 0, 100, 70), "Time Left: " +
                (GameControl.current.gameDuration - GameControl.current.GetElaspedTime()) + 
                "\nHp: " + GameControl.current.GetPlayerCurrHp() + "/" + GameControl.current.GetPlayerMaxHp() +
                "\nKill Count: " + GameControl.current.killCnt);

        } else
        {
            GUI.TextArea(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 100, 200, 100), msg+ "\n"
            + "High Score: " + GameControl.current.GetHighScore() + "\n" + "Current Score: " +
            GameControl.current.killCnt);
            if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2, 100, 50), "Restart Level"))
            {
                Application.LoadLevel(0);
            }
        }
        
    }

    public void showEndGUI(string gameMsg)
    {
        msg = gameMsg;
        showHUD = false;
    }

}
