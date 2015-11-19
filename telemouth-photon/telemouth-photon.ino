UDP myUDP;
#define LOCALPORT  8888
#define REMOTEPORT 9999

const char moodChange0[] = "/mc 0";
const char moodChange1[] = "/mc 1";
const char moodChange2[] = "/mc 2";

int button1 = D2;
int button2 = D1;
int button1Val;
int button2Val;

int state = 0;

void setup() {
  pinMode(button1, INPUT);
  pinMode(button2, INPUT);
}

void loop() {
    button1Val = digitalRead(button1);
    button2Val = digitalRead(button2);
    
    if(button1Val == HIGH && state != 1){ // smile
        state = 1;
    
        myUDP.begin(LOCALPORT);
        uint8_t buf[32];
        memcpy(buf,moodChange1,strlen(moodChange1)+1);
        buf[5] = '\0';
        buf[6] = '\0';
        buf[7] = '\0';
        buf[8] = ',';
        buf[9] = '\0';
        buf[10] = '\0';    
        buf[11] = '\0';

        myUDP.beginPacket(IPAddress(10,0,0,7),REMOTEPORT);
        myUDP.write(buf,12);
        myUDP.endPacket();
        myUDP.stop();
    
    } else if(button2Val == HIGH && state != 2) { // frown
        state = 2;
    
        myUDP.begin(LOCALPORT);
        uint8_t buf[32];
        memcpy(buf,moodChange2,strlen(moodChange2)+1);
        buf[5] = '\0';
        buf[6] = '\0';
        buf[7] = '\0';
        buf[8] = ',';
        buf[9] = '\0';
        buf[10] = '\0';    
        buf[11] = '\0';

        myUDP.beginPacket(IPAddress(10,0,0,7),REMOTEPORT);
        myUDP.write(buf,12);
        myUDP.endPacket();
        myUDP.stop();
        
    } else if(button1Val == LOW && button2Val == LOW && state != 0){ // neutral
        state = 0;
        
        myUDP.begin(LOCALPORT);
        uint8_t buf[32];
        memcpy(buf,moodChange0,strlen(moodChange0)+1);
        buf[5] = '\0';
        buf[6] = '\0';
        buf[7] = '\0';
        buf[8] = ',';
        buf[9] = '\0';
        buf[10] = '\0';    
        buf[11] = '\0';

        myUDP.beginPacket(IPAddress(10,0,0,7),REMOTEPORT);
        myUDP.write(buf,12);
        myUDP.endPacket();
        myUDP.stop();
        
    }

    delay(100);
}




