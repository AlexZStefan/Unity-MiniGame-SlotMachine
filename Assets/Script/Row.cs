using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Row : MonoBehaviour
{
    private int randomValue;
    private float timeInterval;

    public bool rowStopped;
    public string stoppedSlot; 

    // Start is called before the first frame update
    void Start()
    {
        rowStopped = true;
        GameControl.HandlePulled += StartRotating;
    }

    private void StartRotating()
    {
        stoppedSlot = "";
        StartCoroutine("Rotate");
    }
    
    private IEnumerator Rotate()
    {
        rowStopped = false;
        // speed at which the row move 
        timeInterval = 0.025f; 

        // changes the y position of the rows 
        // rotate the rows for i amount 
        for(int i = 0; i < 36; i++)
        { 
            if (transform.position.y <= -25f)
                // 59 max -25 min - 12 / each slot
                transform.position = new Vector2(transform.position.x, 59f);

            transform.position = new Vector2(transform.position.x, transform.position.y - 2.0f);

            yield return new WaitForSeconds(timeInterval);
        }

       
        randomValue = Random.Range(60,150);
     
        switch (randomValue % 6)
        {
            case 1:
                randomValue += 5;
                print("randomval added" + randomValue);
                break;
            case 2:
                randomValue += 4;
              
                break;
            case 3:
                randomValue += 3;
            
                break;
            case 4:
                randomValue += 2;
             
                break;
            case 5:
                randomValue += 1;
                break;
          
        }


        print("randomval aftermod" + randomValue);
        for (int i = 0; i < randomValue; i++)
        {

      
            if (transform.position.y <= -25f)
                transform.position = new Vector2(transform.position.x, 59f);

            transform.position = new Vector2(transform.position.x, transform.position.y - 2.0f);

            if (i > Mathf.RoundToInt(randomValue * 0.25f))
                timeInterval = 0.05f;

            if (i > Mathf.RoundToInt(randomValue * 0.5f))
                timeInterval = 0.07f;

            if (i > Mathf.RoundToInt(randomValue * 0.75f))
                timeInterval = 0.09f;

            if (i > Mathf.RoundToInt(randomValue * 0.95f))
                timeInterval = 0.14f;

            yield return new WaitForSeconds(timeInterval);
        }
        

        if (transform.position.y == -25f) 
            stoppedSlot = "Diamond";
        if (transform.position.y == -13.0f)
            stoppedSlot = "Crown";
        if (transform.position.y == -1.0f)
            stoppedSlot = "Melon";
        if (transform.position.y == 11.0f)
            stoppedSlot = "Bar";
        if (transform.position.y == 23.0f)
            stoppedSlot = "Seven";
        if (transform.position.y == 35.0f)
            stoppedSlot = "Cherry"; 
        if (transform.position.y == 47.0f)
            stoppedSlot = "Lemon";
        if (transform.position.y == 59f)
            stoppedSlot = "Diamond";
        rowStopped = true;
    }

    private void OnDestroy()
    {
        GameControl.HandlePulled -= StartRotating;
    }      
}
