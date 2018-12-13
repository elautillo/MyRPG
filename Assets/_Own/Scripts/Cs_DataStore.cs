using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class Cs_DataStore : MonoBehaviour
{
	const string Cf_SCENE_ID_NAME = "sceneId";
    const string Cf_XPOS_NAME = "xPos";
    const string Cf_YPOS_NAME = "yPos";
    const string Cf_ZPOS_NAME = "zPos";
    const string Cf_INVENTORY_NAME = "savedInventory";
    const string Cf_ITEM_NAME = "Item ";
    const string Cf_SCORE_NAME = "savedScore";


	public static void StoreAll(
        Vector3 p_position,
        int p_score,
        string[] p_itemName,
        int p_inventoryLength)
	{
        StoreScene();
        StorePosition(p_position);
        StoreScore(p_score);

        for (int i = 0; i < p_inventoryLength; i++)
        {
            StoreItem(p_itemName[i], i);
        }
    }


    // public static void StoreData(string p_name, string p_data) // <Object> where Object : float, string, int
    // {
    //     if (p_data.GetType() == typeof(string))
    //     {
    //         PlayerPrefs.SetString(p_name, p_data.ToString());
    //     }
    //     else if (p_data.GetType() == typeof(float))
    //     {
    //         PlayerPrefs.SetString(p_name, p_data);
    //     }
    //     else if (p_data.GetType() == typeof(int))
    //     {
    //         PlayerPrefs.SetString(p_name, p_data.ToString());
    //     }
    //     else print("You tried yo store invalid data");
    // }


    public static void StoreScene()
	{
        PlayerPrefs.SetInt(
            Cf_SCENE_ID_NAME, SceneManager.GetActiveScene().buildIndex);

        PlayerPrefs.Save();
    }


    public static void StorePosition(Vector3 p_position)
	{
        PlayerPrefs.SetFloat(Cf_XPOS_NAME, p_position.x);
        PlayerPrefs.SetFloat(Cf_YPOS_NAME, p_position.y);
        PlayerPrefs.SetFloat(Cf_ZPOS_NAME, p_position.z);

        PlayerPrefs.Save();
    }


    public static void StoreItem(string p_itemName, int p_index)
	{
        PlayerPrefs.SetString(Cf_ITEM_NAME + p_index.ToString(), p_itemName);
        
        PlayerPrefs.Save();
    }


    public static void StoreScore(int p_score)
	{
        PlayerPrefs.SetInt(Cf_SCORE_NAME, p_score);

        PlayerPrefs.Save();
    }


    public static int GetSavedScene()
    {
        int v_savedScene = -1;

        if (PlayerPrefs.HasKey(Cf_SCENE_ID_NAME))
        {
            v_savedScene = PlayerPrefs.GetInt(Cf_SCENE_ID_NAME);
        }
        return v_savedScene;
    }


    public static void LoadSavedScene()
    {
        int v_savedScene = GetSavedScene();

        if (v_savedScene != -1)
        {
            SceneManager.LoadScene(v_savedScene);
        }
        else print("No saved scenes available");
    }


    public static Vector3 GetSavedPosition()
	{
        Vector3 v_position = new Vector3(
            GetSavedAxis(Cf_XPOS_NAME),
            GetSavedAxis(Cf_YPOS_NAME),
            GetSavedAxis(Cf_ZPOS_NAME));
        
        return v_position;
    }


    public static float GetSavedAxis(string p_axis)
    {
        float v_savedAxis = 0;

        if (PlayerPrefs.HasKey(p_axis))
        {
            v_savedAxis = PlayerPrefs.GetFloat(p_axis);
        }
        return v_savedAxis;
    }


    public static string GetSavedItem(int p_index)
    {
        string v_item = "";

        if (PlayerPrefs.HasKey(Cf_ITEM_NAME + p_index.ToString()))
        {
            v_item = PlayerPrefs.GetString(Cf_ITEM_NAME + p_index.ToString());
        }
        return v_item;
    }


    public static int GetSavedScore()
    {
        int v_savedScore = 0;

        if (PlayerPrefs.HasKey(Cf_SCORE_NAME))
        {
            v_savedScore = PlayerPrefs.GetInt(Cf_SCORE_NAME);
        }
        return v_savedScore;
    }


    public static void ClearData()
    {
        PlayerPrefs.DeleteAll();
    }
}
