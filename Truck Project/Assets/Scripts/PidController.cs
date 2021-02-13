using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PidController
{
    private float errorValue;
    private float previousError,previousMeasurement;
    private float control;
    private float proportional,integral,derivative;
    private float limitMinIntergral,limitMaxIntegral;

    public void Reset(){
      errorValue = 0;
      previousError = 0;
      previousMeasurement=0;
      control=0;
      proportional=0;
      integral=0;
      derivative=0;
    }

    public void Update(float setPoint,float actualPoint,float Kp,float Ki,float Kd, float sampleTime, float limitMaxOutput, float limitMinOutput)
    {
      errorValue = actualPoint - setPoint;
      proportional = Kp * errorValue;
      integral = integral + 0.5f * Ki * sampleTime * (errorValue + previousError);

      if(limitMaxOutput > proportional)
      {
        limitMaxIntegral = limitMaxOutput - proportional;
      }
      else
      {
        limitMaxIntegral = 0f;
      }

      if(limitMinOutput < proportional)
      {
        limitMinIntergral = limitMinOutput - proportional;
      }
      else
      {
        limitMinIntergral = 0f;
      }

      if (integral > limitMaxIntegral)
      {
        integral = limitMaxIntegral;
      }
      if (integral < limitMinIntergral)
      {
        integral = limitMinIntergral;
      }


      //derivative = -(2f * Kd * (actualPoint - previousMeasurement) + (2f * tau - sampleTime) * derivative) / (2f * tau + sampleTime);
      derivative = (Kd * (actualPoint - previousMeasurement)/ sampleTime);

      control = proportional + integral + derivative;
      if (control > limitMaxOutput)
      {
        control = limitMaxOutput;
      }
      if (control < limitMinOutput)
      {
        control = limitMinOutput;
      }

      previousError = errorValue;
      previousMeasurement = actualPoint;
    }

    public float Output()
    {
      return control;
    }
}
