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

      //Calculate proportional term
      //This term does the bulk of the correction, by trying to proportionally correct for the error in the system
      proportional = Kp * errorValue;

      //Compute intergral term by adding up errors, as well as adding the previous integral term.
      //This term acrues errors to fix inaccuracy in the system over time
      integral = integral + 0.5f * Ki * sampleTime * (errorValue + previousError);

      /* Compute clamping values for the integral term, to counter integral windup
      (When there's a high error for a long time the integral term acrues too much error,
      and takes a while to wind back down once the system is back to being stable,
      and this prevents that windup) */
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

      //Actually do the integral value clamping
      integral = Mathf.Clamp(integral, limitMinIntergral, limitMaxIntegral);

      //This is the derivative calculation with a low pass filter, currently it doesn't work
      //derivative = -(2f * Kd * (actualPoint - previousMeasurement) + (2f * tau - sampleTime) * derivative) / (2f * tau + sampleTime);

      /* Derivative on measurement, without a low pass filter, since we have no noise in the signal.
      This term tries to keep the state of the system from moving, even with input, because it's on measurement instead of error.
      This does reduce derivative "kick" if there's a quick change in setpoint,
      but also causes changes in the setpoint to be more slowly realized in the ouput (less "snappy" control) */
      derivative = (Kd * (actualPoint - previousMeasurement)/ sampleTime);

      control = proportional + integral + derivative;

      //Clamp the output of the PID controller
      control = Mathf.Clamp(control, limitMinOutput, limitMaxOutput);

      //Set previous values for the intergral and derivative terms
      previousError = errorValue;
      previousMeasurement = actualPoint;
    }

    public float Output()
    {
      return control;
    }
}
