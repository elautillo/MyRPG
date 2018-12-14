using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class Ps_GameController : MonoBehaviour
{
	private static bool Sf_playing;


	public static bool IsPlaying()
    {
        return Sf_playing;
    }


    public static void SetPlay(bool p_isPlaying)
    {
        Sf_playing = p_isPlaying;
    }


	public static void LoadNextScene()
    {
        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex + 1);
    }
}
