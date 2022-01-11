using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Row : MonoBehaviour
{
    private int priv_RandomValue_int;
    private float priv_TimeInterval_f;
  
    public bool pub_RowStopped_bool;
    public string pub_StoppedSlot_str;

    // Start is called before the first frame update
    void Start()
    {
        pub_RowStopped_bool = true;
        GameControl.HandlePulled += StartRotating;
    }

    private void StartRotating()
    {
        pub_StoppedSlot_str = "";
        StartCoroutine("Rotate");
    }

    private IEnumerator Rotate()
    {
        pub_RowStopped_bool = false;
        // speed at which the row move 
        priv_TimeInterval_f = 0.025f;

        // changes the y position of the rows 
        // rotate the rows for i amount 
        for (int i = 0; i < 36; i++)
        {
            if (transform.position.y <= -25f)
                // 59 max -25 min - 12 / each slot
                transform.position = new Vector2( transform.position.x, 59f);

            transform.position = new Vector2(transform.position.x, transform.position.y - 2.0f);

            yield return new WaitForSeconds(priv_TimeInterval_f);
        }

        // random range that will decide how many times the row will spin
        priv_RandomValue_int = Random.Range(60, 150);
        switch (priv_RandomValue_int % 6)
        {
            case 1:
                priv_RandomValue_int += 5;

                break;
            case 2:
                priv_RandomValue_int += 4;
                break;
            case 3:
                priv_RandomValue_int += 3;
                break;
            case 4:
                priv_RandomValue_int += 2;
                break;
            case 5:
                priv_RandomValue_int += 1;
                break;
        }

        for (int i = 0; i < priv_RandomValue_int; i++)
        {
            // rotates slots 6 * 2f per i
            if (transform.position.y <= -25f)
                transform.position = new Vector2(transform.position.x, 59f );

            transform.position = new Vector2(transform.position.x, transform.position.y - 2f);

            if (i > Mathf.RoundToInt(priv_RandomValue_int * 0.25f))
                priv_TimeInterval_f = 0.05f;

            if (i > Mathf.RoundToInt(priv_RandomValue_int * 0.5f))
                priv_TimeInterval_f = 0.07f;

            if (i > Mathf.RoundToInt(priv_RandomValue_int * 0.75f))
                priv_TimeInterval_f = 0.09f;

            if (i > Mathf.RoundToInt(priv_RandomValue_int * 0.95f))
                priv_TimeInterval_f = 0.14f;

            yield return new WaitForSeconds(priv_TimeInterval_f);
        }


        if (transform.position.y == -25f)
            pub_StoppedSlot_str = "Diamond";
        if (transform.position.y == -13.0f)
            pub_StoppedSlot_str = "Crown";
        if (transform.position.y == -1.0f)
            pub_StoppedSlot_str = "Melon";
        if (transform.position.y == 11.0f)
            pub_StoppedSlot_str = "Bar";
        if (transform.position.y == 23.0f)
            pub_StoppedSlot_str = "Seven";
        if (transform.position.y == 35.0f)
            pub_StoppedSlot_str = "Cherry";
        if (transform.position.y == 47.0f)
            pub_StoppedSlot_str = "Lemon";
        if (transform.position.y == 59f)
            pub_StoppedSlot_str = "Diamond";
        pub_RowStopped_bool = true;
    }

    private void OnDestroy()
    {
        GameControl.HandlePulled -= StartRotating;
    }
}

