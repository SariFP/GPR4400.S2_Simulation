using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public enum Variations { T1, T2, T3, T4 }

public class LSystem2 : MonoBehaviour
{

    public int Iterations = 4;
    public float Length = 2f;
    public float Width = 1f;
    public float Angle = 30f;
    public float Variance = 120f;

    //public GameObject Tree;
    public GameObject TreeParent;
    public GameObject Branch;
    public GameObject BranchWithFruit;

    private Dictionary<char, string> rules;
    private Stack<NexusPoint> nexusStack;
    private const string axiom = "X";
    private string currentString = string.Empty;
    private Vector3 currentPosition = Vector3.zero;
    public Variations id;

    void Start()
    {
        nexusStack = new Stack<NexusPoint>();

        PicVariations();
        Generate();
    }

    //private void Update()
    //{
    //    if (Input.GetButtonDown("Jump"))
    //    {
    //        Generate();
    //    }
    //}

    private void Generate()
    {
        //Tree = Instantiate(TreeParent);

        currentString = axiom;

        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < Iterations; i++)
        {
            foreach (char c in currentString)
            {
                if (rules.ContainsKey(c))
                {
                    sb.Append(rules[c]);
                }
                else
                {
                    sb.Append(c.ToString());
                }
            }

            currentString = sb.ToString();
            sb = new StringBuilder();
        }

        StartCoroutine(GenerateTree());
    }

    IEnumerator GenerateTree()
    {
        for (int i = 0; i < currentString.Length; i++)
        {

            switch (currentString[i])
            {
                case 'X':
                    break;
                case 'F':
                    Vector3 initPos = transform.position;
                    transform.Translate(Vector3.up * Length);

                    if (currentString[(i + 1) % currentString.Length] == 'X')
                    {
                        GameObject fruit = Instantiate(BranchWithFruit, transform.position, transform.rotation);
                        fruit.transform.SetParent(TreeParent.transform);
                    }
                    else
                    {
                        GameObject branch = Instantiate(Branch, transform.position, transform.rotation);
                        branch.transform.SetParent(TreeParent.transform);
                    }
                    break;
                case '[':
                    nexusStack.Push(new NexusPoint(transform.position, transform.rotation));
                    break;
                case ']':
                    NexusPoint np = nexusStack.Pop();
                    transform.position = np.position;
                    transform.rotation = np.rotation;
                    break;
                case '+':
                    transform.Rotate(Vector3.back * Angle);
                    break;
                case '-':
                    transform.Rotate(Vector3.forward * Angle);
                    break;
                case '*':
                    transform.Rotate(Vector3.up * Variance);
                    break;
                case '/':
                    transform.Rotate(Vector3.down * Variance);
                    break;
                default:
                    break;
            }
            yield return new WaitForSeconds(.1f);
        }
    }

    public void PicVariations()
    {
        switch (id)
        {
            case Variations.T1:
                rules = new Dictionary<char, string>
                {   /*schräger, aber normaler Baum*/
                    {'X', "[F[-X+F[+FX]][/-X+F[+FX]-X]]" },
                    {'F', "FF" }
                };
                break;

            case Variations.T2:
                rules = new Dictionary<char, string>
                {   /*sehr einfacher Baum*/
                    {'X', "F[+FX][*+FX][/+FX]" },
                    {'F', "FF" }
                };
                break;

            case Variations.T3:
                rules = new Dictionary<char, string>
                {   /*Busch*/
                    {'X', "[*+FX]X[+FX][/+F-FX]" },
                    {'F', "FF" }
                };
                break;
            case Variations.T4:
                rules = new Dictionary<char, string>
                {
                    //proppenvoller Baum
                    { 'X', "[F[-X + F[+FX]][*-X + F[+FX]][/ -X + F[+FX] - X]]" },
                    {'F', "FF" }
                };
                break;
        }
    }
}

public struct NexusPoint
{
    public Vector3 position;
    public Quaternion rotation;

    public NexusPoint(Vector3 pos, Quaternion rot)
    {
        position = pos;
        rotation = rot;
    }
}



