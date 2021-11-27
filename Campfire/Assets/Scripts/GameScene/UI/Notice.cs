using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notice : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float lifeTime = 3f;

    void OnEnable()
    {
        lifeTime = 3f;
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
    }

    
}
