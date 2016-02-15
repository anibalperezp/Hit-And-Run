using UnityEngine;
using UnityEngine;
using System.Collections;
using _Logica;
public class HSController : MonoBehaviour
{
    private string secretKey = "mySecretKey"; // Edit this value and make sure it's the same as the one stored on the server
    private string addScoreURL = "http://dalequetepega.260mb.net/Ranking/addScore.php?";  // "http://dalequetepega.260mb.net/Ranking/addScore.php?";//"http://localhost/Ranking/addScore.php?"; //be sure to add a ? to your url
    private string highscoreURL = "http://dalequetepega.260mb.net/Ranking/verificID.php?";//"http://dalequetepega.260mb.net/Ranking/verificID.php?";//"http://localhost/Ranking/verificID.php?";
    private string result = "";
    void Start()
    {
				
    } 

    void Update()
    {
        //addScoreURL = Camera.main.GetComponent<GuiRanking> ().AddScore;
        //highscoreURL = Camera.main.GetComponent<GuiRanking> ().DisplayScore;
    }
	
    // remember to use StartCoroutine when calling this function!
	    
    IEnumerator PostScores(string name, int score, string id, string person)
    {
        //This connects to a server side php script that will add the name and score to a MySQL DB.
        // Supply it with a string representing the players name and the players score.
        //string hash = name + score + secretKey;


        string post_url = addScoreURL + "&id=" + id + "&name=" + WWW.EscapeURL(name) + "&score=" + score + "&person=" + person;
		
        // Post the URL to the site and create a download object to get the result.
        WWW hs_post = new WWW(post_url);

        yield return hs_post; // Wait until the download is done
		
        if (hs_post.error != null)
        {
            print("There was an error posting the high score: " + hs_post.error);
        }
    }
	
    // Get the scores from the MySQL DB to display in a GUIText.
    // remember to use StartCoroutine when calling this function!
    IEnumerator GetScores(string id, int score)
    {
        //gameObject.guiText.text = "Loading Scores";
        string idDevice = SystemInfo.deviceUniqueIdentifier;
        highscoreURL = highscoreURL + "&id=" + id + "&score=" + score.ToString();
      
        WWW hs_get = new WWW(highscoreURL);

        yield return hs_get;

        if (hs_get.error != null)
        {
            print("There was an error getting the high score: " + hs_get.error);
            Camera.main.GetComponent<GUI_Play>().estadoCnexion = "not internet conection";

        } else
        {
            result = hs_get.text;	
            Camera.main.GetComponent<GUI_Play>().resultado = result;
        }
    }








    public void addScore(string name, int score, string id, string person)
    {

        StartCoroutine(PostScores(name, score, id, person));


    }


    public string DisplayScore(string id, int score)
    {

        StartCoroutine(GetScores(id, score));

        return result;

    }






}