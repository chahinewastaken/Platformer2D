using UnityEngine;
using UnityEngine.UI;
public class GetScore : MonoBehaviour
{
    public Text score;
    public Text highscore;
    void Update()
    {
        score.text = PlayerPrefs.GetInt("savedscore").ToString();
        highscore.text = PlayerPrefs.GetInt("Highscore").ToString();
    }
}
