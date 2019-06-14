using Valve.VR;
using UnityEngine;

public class ViveInput : MonoBehaviour
{
    public SpawnFood foodSpawn;

    public SteamVR_ActionSet actionSet;

    public SteamVR_Action_Boolean booleanAction;

    private void Awake()
    {
        booleanAction = SteamVR_Actions._default.GrabPinch;
    }
    private void Start()
    {
        actionSet.Activate(SteamVR_Input_Sources.Any, 0, true);
    }

    private void Update()
    {
        //if (booleanAction.GetStateDown(SteamVR_Input_Sources.Any))
        //{

        //}
        if (booleanAction.GetStateUp(SteamVR_Input_Sources.Any))
        {
            Debug.Log("GiveFood");
            foodSpawn.FoodSpawn();
        }
    }
}
