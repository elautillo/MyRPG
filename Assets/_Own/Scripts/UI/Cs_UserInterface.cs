using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cs_UserInterface : MonoBehaviour
{
    [SerializeField] Slider f_slider;
    [SerializeField] Cs_Player f_player;

    void Update()
    {
        f_slider.value = f_player.M_GetHealth();
    }
}
