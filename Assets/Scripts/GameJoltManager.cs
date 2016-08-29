using UnityEngine;
using System.Collections;

public class GameJoltManager : MonoBehaviour
{
    bool isSignedIn;
    public bool requestOnEnter;

    // Use this for initialization
    void Start()
    {
        isSignedIn = GameJolt.API.Manager.Instance.CurrentUser != null;

        if (!isSignedIn && requestOnEnter)
            SignIn();
    }

    void SignIn()
    {
        GameJolt.UI.Manager.Instance.ShowSignIn();
    }

    public void TrySignIn()
    {
        GameJolt.UI.Manager.Instance.ShowSignIn((bool success) =>
        {
            if (success)
            {
                Debug.Log("The user signed in!");
            }
            else
            {
                Debug.Log("The user failed to signed in or closed the window :(");
            }
        });
    }

    public void GameJoltButton()
    {
        if (!isSignedIn)
            SignIn();
    }
}
