
void setup() {
  pinMode(13, OUTPUT);
  Serial.begin(9600);
  Serial.setTimeout(100);
  digitalWrite(13, HIGH);
  delay(1000);
  digitalWrite(13, LOW);
}

// the loop routine runs over and over again forever:
void loop() {
  if (Serial.available() > 0) 
  {
    String incoming = Serial.readString();
    if(incoming[0] == '1' && incoming[1] == '3') digitalWrite(13, HIGH);
    else digitalWrite(13, LOW);    
  }
  Serial.println("La la la");
  _delay_ms(1000);
}
