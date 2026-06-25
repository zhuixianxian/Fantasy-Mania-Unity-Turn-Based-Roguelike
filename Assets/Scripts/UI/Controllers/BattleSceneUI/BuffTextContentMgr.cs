using System.Collections;
using System.Collections.Generic;

using TMPro;

using UnityEngine;

public class BuffTextContentMgr : MonoBehaviour
{
    public TextMeshProUGUI BuffDescription;
    public TextMeshProUGUI BuffName;
    public TextMeshProUGUI BuffDuration;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetText(
     string _BuffDescription,
    string _BuffName,
        string _BuffDuration

        )
    {
        BuffDescription.text = _BuffDescription;
        BuffName.text = _BuffName;
        BuffDuration.text = _BuffDuration;
    }
}
