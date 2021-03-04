using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loops : MonoBehaviour
{
    public string[] List;
    public int countIterations;
    public int whileCounter;

    void Start()
    {
      int i2 = 0;
      foreach(string i in List)
      {
        Debug.Log(i);
      }
      for(int i=0;i < countIterations+1;i++)
      {
        Debug.Log(countIterations-i);
      }
      while(i2 < whileCounter)
      {
        Debug.Log("While = "+i2);
        i2 ++;
      }
    }
}
