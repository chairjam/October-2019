#define PIN_TRIG1 12
#define PIN_ECHO1 11
#define PIN_FAN1 10

//int led = 9;           // the PWM pin the LED is attached to
//int brightness = 0;    // how bright the LED is

/*
#define PIN_TRIG2 9
#define PIN_ECHO2 8
#define PIN_FAN2 7

#define PIN_TRIG3 6
#define PIN_ECHO3 5
#define PIN_FAN3 4
*/
float cm1;
float temp1;

/*
float cm2;
float temp2;

float cm3;
float temp3;
*/
float maximumRange = 120.0;
float minimumRange = 10.0;
  
void setup() {  
  Serial.begin(9600);  
  pinMode(PIN_TRIG1, OUTPUT);  
  pinMode(PIN_ECHO1, INPUT);  
  pinMode(PIN_FAN1, OUTPUT); // To change FAN SPEED 

//   pinMode(led, OUTPUT);
/*
  pinMode(PIN_TRIG2, OUTPUT);  
  pinMode(PIN_ECHO2, INPUT);  
  pinMode(PIN_FAN2, OUTPUT); 

  pinMode(PIN_TRIG3, OUTPUT);  
  pinMode(PIN_ECHO3, INPUT);  
  pinMode(PIN_FAN3, OUTPUT); 
  */
}  
  
void loop() {  
  digitalWrite(PIN_TRIG1, LOW);
  delayMicroseconds(2);
  digitalWrite(PIN_TRIG1, HIGH);
  delayMicroseconds(2);
  digitalWrite(PIN_TRIG1, LOW);
  
/*
  digitalWrite(PIN_TRIG2, LOW);
  delayMicroseconds(2);
  digitalWrite(PIN_TRIG2, HIGH);
  delayMicroseconds(2);
  digitalWrite(PIN_TRIG2, LOW);

  digitalWrite(PIN_TRIG3, LOW);
  delayMicroseconds(2);
  digitalWrite(PIN_TRIG3, HIGH);
  delayMicroseconds(2);
  digitalWrite(PIN_TRIG3, LOW);
   */ 
  temp1 = float(pulseIn(PIN_ECHO1, HIGH));
  cm1 = (temp1 * 17 )/1000;

/*
  temp2 = float(pulseIn(PIN_ECHO2, HIGH));
  cm2 = (temp2 * 17 )/1000;

  temp3 = float(pulseIn(PIN_ECHO3, HIGH));
  cm3 = (temp3 * 17 )/1000;

 float temp_motor_val2;
  float temp_motor_val3;
 temp_motor_val2 = map(cm2, minimumRange, maximumRange, 255, 0);
  temp_motor_val3 = map(cm3, minimumRange, maximumRange, 255, 0);
   */ 
  float temp_motor_val1;
  float temp_delay;

  temp_motor_val1 = map(cm1, minimumRange, maximumRange, 255, 0);  
  //brightness= map(cm1, minimumRange, maximumRange, 200, 0); 
  temp_delay = map(temp_motor_val1,0, 255, 1500, 300);
  
  if (cm1 > minimumRange && cm1 < maximumRange) {
    
    analogWrite(PIN_FAN1, temp_motor_val1);
    //analogWrite(led, brightness);
    delay(temp_delay);
    analogWrite(PIN_FAN1, 0);
    //analogWrite(led, 0);
    delay(temp_delay);
  
    
    
  } else if (cm1 <= minimumRange) {
    
    analogWrite(PIN_FAN1, 255);
    //analogWrite(led, 255);
    delay(temp_delay);
    analogWrite(PIN_FAN1, 0);
    //analogWrite(led, 0);
    delay(temp_delay);
    
    

  } else {
   
    analogWrite(PIN_FAN1, 0); 
    //analogWrite(led, 0); 
    delay(temp_delay);
    analogWrite(PIN_FAN1, 0);  
    //analogWrite(led, 0);
    delay(temp_delay);
   
  }

/*
  if(cm2 > minimumRange && cm2 < maximumRange) {
    analogWrite(PIN_FAN2, temp_motor_val2);
  } else if (cm2 <= minimumRange){
    analogWrite(PIN_FAN2,255);  
  } else {
    analogWrite(PIN_FAN2,0);  
  }

  if(cm3 > minimumRange && cm3 < maximumRange) {
    analogWrite(PIN_FAN3, temp_motor_val3);
  } else if (cm3 <= minimumRange) {
    analogWrite(PIN_FAN3,255);  
  } else {
    analogWrite(PIN_FAN3,0);  
  }
  */ 
  
  Serial.print("Echo = ");  
  Serial.print(temp1);
  Serial.print(",  Distance = ");  
  Serial.print(cm1);
  Serial.println("cm");  
  Serial.print(",  Motorval = ");  
  Serial.print(temp_motor_val1);
  delay(50);  
} 

