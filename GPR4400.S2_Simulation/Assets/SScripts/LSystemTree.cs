using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LSystemTree : MonoBehaviour
{
    public GameObject Prefab;
    public Vector3 currentPosition;
    public float currentDirection;
    public float rotationDelta;

    private Vector3 position;
    private float direction;

    public Variable[] variables;

    [SerializeField]
    string source = "";

    [SerializeField]
    string destination = "";

    private void Start()
    {
        Clear();
        Debug.Log(source);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Replace();
            Debug.Log(source);
        }
    }

    public void Replace()
    {
        ClearStructure();

        destination = string.Empty;

        for (int i = 0; i < source.Length; i++)
        {
            string temp = source.Substring(i, 1);

            foreach (Variable v in variables)
            {
                if (temp != v.symbol)
                    continue;

                destination += v.replacement;

                DoStuff(v.action);
            }
        }
        source = destination;
    }

    public void DoStuff(Action action)
    {
        switch (action.id)
        {
            case Actions.DRAW_LINE:
                GameObject temp = Instantiate(Prefab, Vector3.zero, Quaternion.Euler(0, 0, currentDirection), transform);
                temp.transform.position = currentPosition;
                currentPosition += Quaternion.Euler(0, 0, currentDirection) * Vector3.up;
                break;
            case Actions.LOAD_POS_DIR:
                currentPosition = position;
                currentDirection = direction;
                break;
            //case Actions.LOAD_POS_DIR_DIVIDE:
            //    currentPosition = position;
            //    currentDirection = direction;
            //    break;
            case Actions.MOVE_FWD:
                currentPosition += Quaternion.Euler(0, 0, currentDirection) * Vector3.up;
                break;
            case Actions.SAVE_POS_DIR:
                position = currentPosition;
                direction = currentDirection;
                break;
            //case Actions.SAVE_POS_DIR_MULTIPLY:
            //    position = currentPosition;
            //    direction = currentDirection;
            //    break;
            case Actions.TURN_LEFT:
                currentDirection = rotationDelta;
                break;
            case Actions.TURN_RIGHT:
                currentDirection = -rotationDelta;
                break;
            default:
                break;
        }
    }

    public void Clear()
    {
        source = variables[0].symbol;
        destination = string.Empty;

        ClearStructure();
    }

    public void ClearStructure()
    {
        int children = transform.childCount - 1;

        while (children >= 0)
        {
            DestroyImmediate(transform.GetChild(children).gameObject);
            children--;
        }

        currentDirection = 0;
        currentPosition = Vector3.zero;
    }

    [Serializable]
    public struct Variable
    {
        public string symbol;
        public Action action;
        public string replacement;
    }

    [Serializable]
    public struct Action
    {
        public Actions id;
    }

    public enum Actions { DRAW_LINE, MOVE_FWD, TURN_LEFT, TURN_RIGHT, SAVE_POS_DIR, LOAD_POS_DIR/*, SAVE_POS_DIR_MULTIPLY, LOAD_POS_DIR_DIVIDE*/ }
}
