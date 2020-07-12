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
  double resistorVoltage1 = map(analogRead(definitions::ResistorPin1), 0.0, 1023.0, 0.0, 5.0);
  double resistorVoltage2 = map(analogRead(definitions::ResistorPin2), 0.0, 1023.0, 0.0, 5.0);
  Serial.println(resistorVoltage1);
  Serial.println(resistorVoltage2);
  double resistance = 0.0;
  if(resistorVoltage1 > 0) resistance = resistorVoltage2 * definitions::BuiltInResistor / resistorVoltage1;
  if(millis()%definitions::WaitTime < definitions::WaitTime/2){
    if(notSent){ 
      Serial.println(createMessage(voltage, 'V'));
      Serial.println(createMessage(resistance, 'r'));
    }
    notSent = false;
  }
  else notSent = true;
}

template<typename T>
String createMessage(T value, char type) {
  if(type == 'r') return "Res/" + String(value);
  if(type == 'V') return "VoltDeg/" + String(value);
  return "";
}
