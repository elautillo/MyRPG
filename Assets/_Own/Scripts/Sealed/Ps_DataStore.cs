using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class Ps_DataStore : MonoBehaviour
{
	const string Cf_SCENE_ID_KEY = "sceneId";
    const string Cf_XPOS_KEY = "xPos";
    const string Cf_YPOS_KEY = "yPos";
    const string Cf_ZPOS_KEY = "zPos";
    const string Cf_INVENTORY_KEY = "savedInventory";
    const string Cf_ITEM_KEY = "Item";
    const string Cf_SCORE_KEY = "savedScore";


	public static void StoreAll(
        Vector3 p_position,
        int p_score,
        Cs_Item[] p_items,
        int p_inventoryLength)
	{
        StoreScene();
        StorePosition(p_position);
        StoreScore(p_score);

        for (int i = 0; i < p_inventoryLength; i++)
        {
            StoreItem(i, p_items[i].name);
        }
    }


    public static void StoreScene()
	{
        PlayerPrefs.SetInt(
            Cf_SCENE_ID_KEY, SceneManager.GetActiveScene().buildIndex);

        PlayerPrefs.Save();
    }


    public static int GetSavedScene()
    {
        int v_savedScene = -1;

        if (PlayerPrefs.HasKey(Cf_SCENE_ID_KEY))
        {
            v_savedScene = PlayerPrefs.GetInt(Cf_SCENE_ID_KEY);
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


    public static void StorePosition(Vector3 p_position)
	{
        PlayerPrefs.SetFloat(Cf_XPOS_KEY, p_position.x);
        PlayerPrefs.SetFloat(Cf_YPOS_KEY, p_position.y);
        PlayerPrefs.SetFloat(Cf_ZPOS_KEY, p_position.z);

        PlayerPrefs.Save();
    }


    public static Vector3 GetSavedPosition()
	{
        Vector3 v_position = new Vector3(
            GetSavedAxis(Cf_XPOS_KEY),
            GetSavedAxis(Cf_YPOS_KEY),
            GetSavedAxis(Cf_ZPOS_KEY));
        
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


    public static void StoreScore(int p_score)
	{
        PlayerPrefs.SetInt(Cf_SCORE_KEY, p_score);

        PlayerPrefs.Save();
    }


    public static int GetSavedScore()
    {
        int v_savedScore = 0;

        if (PlayerPrefs.HasKey(Cf_SCORE_KEY))
        {
            v_savedScore = PlayerPrefs.GetInt(Cf_SCORE_KEY);
        }
        return v_savedScore;
    }


    public static void StoreItem(int p_index, string p_itemName)
	{
        PlayerPrefs.SetString(Cf_ITEM_KEY + p_index.ToString(), p_itemName);
        
        PlayerPrefs.Save();
    }


    public static string GetSavedItem(int p_index)
    {
        string v_itemName = "";

        if (PlayerPrefs.HasKey(Cf_ITEM_KEY + p_index.ToString()))
        {
            v_itemName = PlayerPrefs.GetString(Cf_ITEM_KEY + p_index.ToString());
        }
        return v_itemName;
    }


    public static void ClearData()
    {
        PlayerPrefs.DeleteAll();
    }
}
