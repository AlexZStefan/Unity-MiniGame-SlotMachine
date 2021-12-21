using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameControl : MonoBehaviour
{
    public static event Action HandlePulled = delegate { };

    [SerializeField]
    private Text priv_PrizeText_text;

    [SerializeField]
    private Row[] priv_Rows;

    [SerializeField]
    private Transform priv_Handle_tran;

    private int priv_PrizeValue_int;

    private bool priv_HanndlePressed_bool;

    private bool happyHour = false;

    private bool priv_ResultsChecked_bool = false;

    // Update is called once per frame
    void Update()
    {
        if (!priv_Rows[0].pub_RowStopped_bool || !priv_Rows[1].pub_RowStopped_bool || !priv_Rows[2].pub_RowStopped_bool)
        {
            priv_PrizeValue_int = 0;
            priv_PrizeText_text.enabled = false;
            priv_ResultsChecked_bool = false;
        }
        //
        if (priv_Rows[0].pub_RowStopped_bool && priv_Rows[1].pub_RowStopped_bool && priv_Rows[2].pub_RowStopped_bool && !priv_ResultsChecked_bool)
        {
            CheckResults();
            priv_PrizeText_text.enabled = true;
            priv_PrizeText_text.text = priv_PrizeValue_int + "\n Coins Won!";

            if (happyHour == true)
            {
                // trigger HappyHour event
                print("HappyHour started. Drink Up!");
            }
        }
    }

    private void OnMouseDown()
    {
        if (priv_Rows[0].pub_RowStopped_bool && priv_Rows[1].pub_RowStopped_bool && priv_Rows[2].pub_RowStopped_bool) StartCoroutine("PullHandle");

        priv_HanndlePressed_bool = true;

        /*
        if (DrinkValues.pub_MONEYTOTAL_int > 10)
        {            
            DrinkValues.pub_MONEYTOTAL_int -= 10;
        }
        */

        /*
        if (priv_Rows[0].pub_RowStopped_bool && priv_Rows[1].pub_RowStopped_bool && priv_Rows[2].pub_RowStopped_bool) StartCoroutine("PullHandle");
        priv_HanndlePressed_bool = true;
         */
    }
    
    private IEnumerator PullHandle()
    {
        for (int i = 0; i < 15; i += 5)
        {
            priv_Handle_tran.Rotate(0f, 0f, i);
            yield return new WaitForSeconds(0.1f);
        }

        HandlePulled();

        for (int i = 0; i < 15; i += 5)
        {
            priv_Handle_tran.Rotate(0f, 0f, -i);
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void CheckResults()
    {
        if (priv_HanndlePressed_bool == true)
        {
            if (priv_Rows[0].pub_StoppedSlot_str == "Diamond" && priv_Rows[1].pub_StoppedSlot_str == "Diamond" && priv_Rows[2].pub_StoppedSlot_str == "Diamond")
                priv_PrizeValue_int = 200;

            else if (priv_Rows[0].pub_StoppedSlot_str == "Crown" && priv_Rows[1].pub_StoppedSlot_str == "Crown" && priv_Rows[2].pub_StoppedSlot_str == "Crown")
                priv_PrizeValue_int = 400;

            else if (priv_Rows[0].pub_StoppedSlot_str == "Melon" && priv_Rows[1].pub_StoppedSlot_str == "Melon" && priv_Rows[2].pub_StoppedSlot_str == "Melon")
                priv_PrizeValue_int = 600;

            else if (priv_Rows[0].pub_StoppedSlot_str == "Bar" && priv_Rows[1].pub_StoppedSlot_str == "Bar" && priv_Rows[2].pub_StoppedSlot_str == "Bar")
                priv_PrizeValue_int = 800;

            else if (priv_Rows[0].pub_StoppedSlot_str == "Seven" && priv_Rows[1].pub_StoppedSlot_str == "Seven" && priv_Rows[2].pub_StoppedSlot_str == "Seven")
                priv_PrizeValue_int = 1500;

            else if (priv_Rows[0].pub_StoppedSlot_str == "Cherry" && priv_Rows[1].pub_StoppedSlot_str == "Cherry" && priv_Rows[2].pub_StoppedSlot_str == "Cherry")
                priv_PrizeValue_int = 3000;

            else if (priv_Rows[0].pub_StoppedSlot_str == "Lemon" && priv_Rows[1].pub_StoppedSlot_str == "Lemon" && priv_Rows[2].pub_StoppedSlot_str == "Lemon")
                priv_PrizeValue_int = 4000;

            else if (priv_Rows[0].pub_StoppedSlot_str == "Crown" && priv_Rows[1].pub_StoppedSlot_str == "Crown" && priv_Rows[2].pub_StoppedSlot_str == "Crown")
                priv_PrizeValue_int = 400;

            else if (priv_Rows[0].pub_StoppedSlot_str == "Melon" && priv_Rows[1].pub_StoppedSlot_str == "Melon" && priv_Rows[2].pub_StoppedSlot_str == "Melon")
                priv_PrizeValue_int = 600;

            else if (priv_Rows[0].pub_StoppedSlot_str == "Bar" && priv_Rows[1].pub_StoppedSlot_str == "Bar" && priv_Rows[2].pub_StoppedSlot_str == "Bar")
                priv_PrizeValue_int = 800;

            else if (priv_Rows[0].pub_StoppedSlot_str == "Seven" && priv_Rows[1].pub_StoppedSlot_str == "Seven" && priv_Rows[2].pub_StoppedSlot_str == "Seven")
                priv_PrizeValue_int = 1500;

            else if (priv_Rows[0].pub_StoppedSlot_str == "Cherry" && priv_Rows[1].pub_StoppedSlot_str == "Cherry" && priv_Rows[2].pub_StoppedSlot_str == "Cherry")
                priv_PrizeValue_int = 3000;

            else if (priv_Rows[0].pub_StoppedSlot_str == "Lemon" && priv_Rows[1].pub_StoppedSlot_str == "Lemon" && priv_Rows[2].pub_StoppedSlot_str == "Lemon")
                priv_PrizeValue_int = 4000;

            else if (priv_Rows[0].transform.position.y == priv_Rows[1].transform.position.y &&
                priv_Rows[0].transform.position.y == priv_Rows[2].transform.position.y)
            {
                happyHour = true;
            }

            else if (priv_Rows[0].transform.position.y == priv_Rows[1].transform.position.y ||
                priv_Rows[0].transform.position.y == priv_Rows[2].transform.position.y ||
                priv_Rows[1].transform.position.y == priv_Rows[2].transform.position.y)
            {
                // half win
                priv_PrizeValue_int = 100;
            }

            priv_HanndlePressed_bool = false;
        }        
      
        priv_ResultsChecked_bool = true;
    }




    //DrinkValues.pub_MONEYTOTAL_int += priv_PrizeValue_int;


}

