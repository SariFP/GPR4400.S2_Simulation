using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private static PlayerManager instance;

    public static PlayerManager Instance { get { return instance; } }

    public LayerMask TerrainLayer;
    private RaycastHit hit;
    private float x;
    private float y;
    private float z;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    private void Start()
    {
       
    }  

    public void CheckY()
    {
        x = transform.position.x;
        z = transform.position.z;
        if (Physics.Raycast(new Vector3(0, 1000, 0), Vector3.down, out hit, Mathf.Infinity, TerrainLayer))
        {
            y = hit.point.y;
        }
        transform.Translate(new Vector3(0, y, 0));
        Debug.Log(y);
    }
}
