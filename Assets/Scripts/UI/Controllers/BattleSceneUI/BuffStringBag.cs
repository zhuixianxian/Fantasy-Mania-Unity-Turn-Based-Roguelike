using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class BuffStringBag
{


    public string BuffDescription;
    public string BuffName;
    public string BuffDuration;

    public BuffStringBag(

        string _BuffDescription,
    string _BuffName,
    string _BuffDuration
        )
    {
        BuffDescription= _BuffDescription;
        BuffName= _BuffName;
        BuffDuration= _BuffDuration;
    }
}
