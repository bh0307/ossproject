using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Notice : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float lifeTime = 3f;
    [SerializeField]
    private Image img;
    
    [SerializeField]
    private Text txt;
    [SerializeField]
    Color newColor;

    bool isTurn = false;
    void OnEnable()
    {
        lifeTime = 3f;
        newColor = new Vector4(255/255f, 255/255f, 255/255f, 0/255f);
        img.color = newColor;
        txt.color = newColor;
        isTurn = false;
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lifeTime -= Time.deltaTime;
        if(lifeTime <= 0)
        {
            gameObject.SetActive(false);
        }

        if(isTurn)
        {
            newColor.a -= 0.005f;
            img.color = newColor;
            txt.color = newColor;
        }
        else
        {
            newColor.a += 0.01f;
            img.color = newColor;
            txt.color = newColor;

            if(newColor.a >= 250/255f)
            {
                isTurn=true;
            }
        }
        

        
    }

    
}
