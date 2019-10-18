using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushRoom : MonoBehaviour
{
    // Start is called before the first frame update

    Vector2 pos;
    bool leftToRight;
    float spaceRun;
    float startPos;
    void Start()
    {
        pos = transform.position;
        leftToRight = true;
        spaceRun = 2;
        startPos = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (leftToRight)
        {
            if (startPos < spaceRun)
            {
                pos.x += 0.1f;
                startPos += 0.1f;
                transform.position = pos;
            }else
            {
                leftToRight = false;
            }
        }
        else
        {
            if (startPos > 0)
            {
                pos.x -= 0.1f;
                startPos -= 0.1f;
                transform.position = pos;
            }else
            {
                leftToRight = true;
            }
        }

        //if (leftToRight)
        //{
        //    if (pos.x > 3.49 && pos.x < 5.2)
        //    {
        //        pos.x += 0.1f;
        //        transform.position = pos;
        //    }
        //    else
        //    {
        //        leftToRight = false;
        //    }
        //}
        //else
        //{
        //    if (pos.x > 3.6 && pos.x < 5.3)
        //    {
        //        pos.x -= 0.1f;
        //        transform.position = pos;
        //    }
        //    else
        //    {
        //        leftToRight = true;
        //    }
        //}
    }
}
