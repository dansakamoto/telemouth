// This #include statement was automatically added by the Particle IDE.
#include "simple-OSC/simple-OSC.h"

UDP udp;
#define LOCALPORT  8888
#define REMOTEPORT 8001

IPAddress outIp(128, 237, 247, 110);//your computer IP
unsigned int outPort = 8001; //computer incoming port

int button1 = D0;
int button2 = D1;
int button1Val;
int button2Val;

int state = 0;

void setup() {
  pinMode(button1, INPUT);
  pinMode(button2, INPUT);
  
  Serial.begin(115200);
  udp.begin(0);//necessary even for sending only.
  
   while (!WiFi.ready())
    {
        delay(500);
        Serial.print(".");
    }
    Serial.println("");
    Serial.println("WiFi connected");
  
}

void loop() {
    button1Val = digitalRead(button1);
    button2Val = digitalRead(button2);
    
    if(button1Val == HIGH && state != 1){ // smile
        state = 1;
    
       //SEND
        OSCMessage outMessage("/mc");
        outMessage.addInt(1);
        outMessage.send(udp,outIp,outPort);
    
    } else if(button2Val == HIGH && state != 2) { // frown
        state = 2;
    
        //SEND
        OSCMessage outMessage("/mc");
        outMessage.addInt(2);
        outMessage.send(udp,outIp,outPort);
        
    } else if(button1Val == LOW && button2Val == LOW && state != 0){ // neutral
        state = 0;
        
        //SEND
        OSCMessage outMessage("/mc");
        outMessage.addInt(0);
        outMessage.send(udp,outIp,outPort);
        
    }

    delay(100);
}
