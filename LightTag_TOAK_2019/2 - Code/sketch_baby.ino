int led = 7;
int len = 2;
int threshold = 100;

void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600); 
  pinitialize();
}

void loop() {
  // put your main code here, to run repeatedly:
  Serial.println();
  int sens[len];
  for(int i = 0; i < len; i++)
  {
    sens[i] = analogRead(i);
    Serial.println(sens[i]);
  }
  int val = minInArray(sens, len);
  if(val < threshold)
  {
    Serial.println("LIGHT GO ON");
    hit();
  }
  else
  {
    lightsOff();
    noTone(4);
  }
}

void hit()
{
  lightsOn();
  tone(4, 1000);
  delay(1500);
}

void pinitialize()
{
  pinMode(5, OUTPUT);
  pinMode(6, OUTPUT);
  pinMode(7, OUTPUT);
  pinMode(4, OUTPUT);
}

void lightsOn()
{
  digitalWrite(5, HIGH);
  digitalWrite(6, HIGH);
  digitalWrite(7, HIGH);
}

void lightsOff()
{
  digitalWrite(5, LOW);
  digitalWrite(6, LOW);
  digitalWrite(7, LOW);
}

int maxInArray(int arr[], int len)
{
  int index = 0;
  for(int j = 0; j < len; j++)
  {
    if(arr[j] > arr[index])
      index = j;
  }

  return arr[index];
}

int minInArray(int arr[], int len)
{
  int index = 0;
  for(int j = 0; j < len; j++)
  {
    if(arr[j] < arr[index])
      index = j;
  }

  return arr[index];
}
