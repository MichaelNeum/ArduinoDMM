#include "namespaces.h"

bool notSent = true;
String message = "";

void setup() 
{
  Serial.begin(9600);
}

void loop() 
{
  int voltage = map(analogRead(definitions::VoltagePin), 0, 1023, 0, 180);
  String message = "VoltDeg/" + String(voltage);
  if(millis()%definitions::WaitTime < definitions::WaitTime/2){
    if(notSent) Serial.println(message);
    notSent = false;
  }
  else notSent = true;
}
