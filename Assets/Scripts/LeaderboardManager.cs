using UnityEngine;
using UnityEngine.UI;
using GooglePlayGames;
using GooglePlayGames.BasicApi;

public class LeaderboardManager : MonoBehaviour
{
    private void Awake()
    {
        SetupSingleton();
    }

    // Start is called before the first frame update
    void Start()
    {
        // Create client configuration
        PlayGamesClientConfiguration config = new
            PlayGamesClientConfiguration.Builder()
            .Build();

        // Initialize and activate the platform
        PlayGamesPlatform.InitializeInstance(config);

        // Enable debugging output (recommended)
        PlayGamesPlatform.DebugLogEnabled = true;

        PlayGamesPlatform.Activate();
        // END THE CODE TO PASTE INTO START

        // Try silent sign-in (second parameter is isSilent)
        PlayGamesPlatform.Instance.Authenticate(SignInCallback, false);
    }

    private void SetupSingleton()
    {
        int numberOfGameServices = FindObjectsOfType<LeaderboardManager>().Length;
        if (numberOfGameServices > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void SignInCallback(bool success)
    {
        if (success)
        {
            Debug.Log("(Lollygagger) Signed in!");

            //// Change sign-in button text
            //signInButtonText.text = "Sign out";

            //// Show the user's name
            //signInButtonText.text = "Signed in as: " + Social.localUser.userName;
            //authStatus.text = "Signed in as: " + Social.localUser.userName;
        }
        else
        {
            Debug.Log("(Lollygagger) Sign-in failed...");

            // Show failure message
            //signInButtonText.text = "Sign in";
            //signInButtonText.text = "Sign-in failed";
            //authStatus.text = "Sign-in failed";
        }
    }

    public void SignIn()
    {
        // authenticate user:
        PlayGamesPlatform.Instance.Authenticate(SignInInteractivity.CanPromptOnce, (result) => {
            // handle results
            //signInButtonText.text = result.ToString();
        });


        //if (!PlayGamesPlatform.Instance.localUser.authenticated)
        //{
        //    // Sign in with Play Game Services, showing the consent dialog
        //    // by setting the second parameter to isSilent=false.
        //    PlayGamesPlatform.Instance.Authenticate(SignInCallback, false);
        //}
        //else
        //{
        //    // Sign out of play games
        //    PlayGamesPlatform.Instance.SignOut();

        //    // Reset UI
        //    //signInButtonText.text = "Sign In";
        //    //authStatus.text = "";
        //}
    }

    #region Leaderboards

    public void AddScoreToLeaderboard(string leaderboardId, long score)
    {
        Social.ReportScore(score, leaderboardId, (bool success) => {
            //if (success) Time.timeScale = 0f;
            // handle success or failure
            //if (success) debugText.text ="added success";
            //else debugText.text = "added failed";
        });
    }

    public void addAAAA()
    {
        AddScoreToLeaderboard(GPGSIds.leaderboard_high_score, 100);
    }

    public void ShowLeaderboards()
    {

        // show leaderboard UI

        if (Social.localUser.authenticated)
        {
            Social.ShowLeaderboardUI();
        }
        else
        {
            SignIn();
        }
        //if (PlayGamesPlatform.Instance.localUser.authenticated)
        //{
        //    PlayGamesPlatform.Instance.ShowLeaderboardUI();
        //}
        //else
        //{
        //    PlayGamesPlatform.Instance.Authenticate(SignInCallback, false);
        //    Debug.Log("Cannot show leaderboard: not authenticated");
        //}
    }

    #endregion
}
