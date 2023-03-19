#include<stdio.h>
#include<conio.h>
#include<graphics.h>
#include<time.h>
#include<dos.h>
#include<stdlib.h>

# define TIME_OVER 0
# define WIN 1
# define EXITS 2

//FUNCTION PROTOTYPES
void GetRandomValues();
void printbox(int,int,int,int);
void Fscreen(int,int,int,int);
void Sscreen(int,int,int,int);
void process(int,int);
void DisTime();
void select(int);
void Start();
void Exit();
void Gprint(int,int,int,int,int);
int check(int,int);
int match();

void click();
void Sound(int,int);
void erase(int,int,int,int);
void window(int,int,int,int);
void Button(int r,int c,int flag,char *msg);
void buttoneffect(int,int,int,int,int,char*);
void button(int,int ,int ,int ,int ,char *);
void lines(int,int,int,int);

void initmouse();
void showmouse();
void hidemouse();
void ZeroMouse();
void getmouse(int *,int *,int *);
void restrictmouse(int, int, int, int);
void restoremouse();

//VARIABLES
char *success[]={"1","2","3","4","5","6","7","8"," "};
char *caption[]={"0","0","0","0","0","0","0","0"," "};
int randomval[10];

int start,end;
int move=0;
int WX1=140,WY1=110,WX2=330,WY2=290;
int X1=75,Y1=75,X2=570,Y2=400;

union REGS i,o;

void GetRandomValues()
{
 int count=0,temp,i,flag;
 randomize();
 while(count < 8)
 {
  temp = rand()%9;
  flag=0;
  for(i=0;i<=count;i++)
  {
   if(randomval[i]==temp)
   {
    flag=1;
    break;
   }
  }
  if(flag!=1)
  {
    randomval[count]=temp;
    if(randomval[count]==0)
     strcpy(caption[count]," ");
    else
     itoa(randomval[count],caption[count],10);
    count++;
  }
 }
}


void main()
{
 int d=0,m=0,i,num;

 initgraph(&d,&m,"enter ur path of EGAVGA Driver here");
//"F:\turboc\bgi\"
 Fscreen(X1,Y1,X2,Y2);
 Sscreen(X1,Y1,X2,Y2);
 getch();
}

void Fscreen(int x1,int y1,int x2,int y2)
{
 int flag=0,Button[1],x[1],y[1],i;

 GetRandomValues();
 window(x1,y1,x2,y2);
 setcolor(1); settextstyle(1,0,4);
 outtextxy(x1+45,y1+100,"*******************************");
 outtextxy(x1+45,y1+185,"*******************************");
 printbox(x1+50,y1+130,x1+440,y1+190);

 setcolor(11); settextstyle(1,0,6);
 outtextxy(x1+60,y1+125,"SHUFFLE GAME");
 button(x1+100,y1+250,x1+400,y1+275,1,"Start");
 initmouse();
 showmouse();
 while(flag!=1)
 {
  getmouse(Button,x,y);
  if(*Button==1)
  {
   if(*x > (x1+100) && *x < (x1+400) && *y > (y1+250) && *y < (y1+275))
   {
    hidemouse();
    button(x1+100,y1+250,x1+400,y1+275,0,"Start");
    Sound(1,1);
    delay(350);
    button(x1+100,y1+250,x1+400,y1+275,1,"Start");
    showmouse();
    flag=1;
    break;
   }
  }
 }
 hidemouse();
// process(x1,y1);
}

void Sscreen(int x1,int y1,int x2,int y2)
{
 char *b[]={"PLAY","EXIT"};
 int MButton[1],x[1],y[1],i,j,count=0;

 hidemouse();
 window(x1,y1,x2,y2);
 lines(x1+325,y1+2,397,1);
 lines(x1+2,y1+250,400,0);

 button(x1+20,y1+270,x1+300,y1+310,1,b[0]);
 setcolor(0);
 settextstyle(7,0,1);
 outtextxy(x1+350,y1+25,"Start Time ");
 outtextxy(x1+358,y1+120,"  Moves");
 outtextxy(x1+350,y1+220,"Time Limit");
 printbox(75+350,75+50,75+455,75+75);
 printbox(75+350,75+145,75+455,75+170);
 printbox(75+350,75+245,75+455,75+270);

 window(WX1,WY1,WX2,WY2);
 for(i=0;i<3;i++)
  for(j=0;j<3;j++)
  {
   Button(i,j,1,caption[count]);
   count++;
  }
 initmouse();
 showmouse();
 while(1)
 {
  getmouse(MButton,x,y);
  if(*MButton==1)
  {
   if(*x > (x1+20) && *x < (x1+300) && *y > (y1+270) && *y < (y1+310))
   {
    hidemouse();
    button(x1+20,y1+270,x1+300,y1+310,0,b[0]);
    Sound(1,1);
    delay(50);
    button(x1+20,y1+270,x1+300,y1+310,1,b[0]);
    showmouse();
    break;
   }
  }
 }
 button((x1+20),y1+270,(x1+300),y1+310,1,b[1]);
 while(1)
 {
  if(match(caption,success))
   Exit(WIN);
   count=0;
   DisTime();
   getmouse(MButton,x,y);
   if(*MButton==1)
   {
    for(j=0;j<3;j++)
     for(i=0;i<3;i++)
     {
      if(*x > ((WX1+10)+(i*57)) && *x < ((WX1+60)+(i*57)) &&
*y>((WY1+10)+(j*55)) && *y < ((WY1+60)+(j*55)))
      {
       hidemouse();
       Button(j,i,0,caption[count]);
       Sound(2,1);
       select(count);
       Button(j,i,1,caption[count]);
       showmouse();
       break;
      }
     count++;
    }
   if(*x > (x1+20) && *x < (x1+300) && *y > (y1+270) && *y < (y1+310))
   {
     hidemouse();
     button((x1+20),y1+270,(x1+300),y1+310,0,b[1]);
     Sound(3,5);
     delay(250);
     button((x1+20),y1+270,(x1+300),y1+310,1,b[1]);
     showmouse();
     Exit(3);
   }
  }
 }
}

void DisTime()
{
 struct time t;

 gettime(&t);
 t.ti_hour = t.ti_hour%12;
 Gprint(500,130,t.ti_hour,t.ti_min,t.ti_sec);
}
void select(int count)
{
 int i,j;
 switch(count)
 {
  case 0:
	 if(check(1,0)) Button(0,1,1,caption[1]);
	 if(check(3,0)) Button(1,0,1,caption[3]);
	 break;
  case 1:
	 if(check(0,1)) Button(0,0,1,caption[0]);
	 if(check(2,1)) Button(0,2,1,caption[2]);
	 if(check(4,1)) Button(1,1,1,caption[4]);
	 break;
  case 2:
	 if(check(1,2)) Button(0,1,1,caption[1]);
	 if(check(5,2)) Button(1,2,1,caption[5]);
	 break;
  case 3:
	 if(check(0,3)) Button(0,0,1,caption[0]);
	 if(check(4,3)) Button(1,1,1,caption[4]);
	 if(check(6,3)) Button(2,0,1,caption[6]);
	 break;
  case 4:
	 if(check(1,4)) Button(0,1,1,caption[1]);
	 if(check(3,4)) Button(1,0,1,caption[3]);
	 if(check(5,4)) Button(1,2,1,caption[5]);
	 if(check(7,4)) Button(2,1,1,caption[7]);
	 break;
  case 5:
	 if(check(2,5)) Button(0,2,1,caption[2]);
	 if(check(4,5)) Button(1,1,1,caption[4]);
	 if(check(8,5)) Button(2,2,1,caption[8]);
	 break;
  case 6:
	 if(check(3,6)) Button(1,0,1,caption[3]);
	 if(check(7,6)) Button(2,1,1,caption[7]);
	 break;
  case 7:
	 if(check(4,7)) Button(1,1,1,caption[4]);
	 if(check(6,7)) Button(2,0,1,caption[6]);
	 if(check(8,7)) Button(2,2,1,caption[8]);
	 break;
  case 8:
	 if(check(5,8)) Button(1,2,1,caption[5]);
	 if(check(7,8)) Button(2,1,1,caption[7]);
	 break;
 }
}

int check(int choice,int c)
{
 int i,flag=0;
 char *temp;

   if(*caption[choice]==' ')
   {
    temp = caption[c];
    caption[c]=" ";
    caption[choice]=temp;
    flag=1;
    move++;
   }
  return flag;
}
int match()
{
  int flag,i;
  for(i=0;i<9;i++)
  {
   if(*caption[i] != *success[i])
   {
    flag=0;
    break;
   }
   else
   flag=1;
  }
  return flag;
}

void Exit(int flag)
{
 hidemouse();
 window(75,75,570,400);
 setcolor(1);
 setfillstyle(1,0);
 bar3d(125,200,520,275,0,0);
 setcolor(11);
 settextstyle(8,0,4);
 if(flag>=0&&flag<=1)
 {
  if(flag==0)
   outtextxy(200,215,"  TIME OVER");
  else if(flag==1)
   outtextxy(130,215,"  CONGRATS U WON!");
  delay(1000);
  setcolor(1);
  bar3d(125,200,520,275,0,0);
 }
 setcolor(11);
 outtextxy(200,215," THANK YOU");
 delay(1500);


 setcolor(1);
 bar3d(125,200,520,275,0,0);
 delay(1000);
 setcolor(11);
 settextstyle(8,0,3);
 outtextxy(185,220,"BY PACHIDHAMBARAM");
 delay(1500);
 erase(152,207,503,250);
 cleardevice();
 exit(1);
}

void Gprint(int x,int y,int h,int m,int s)
{
 static int flag,sprev,mprev,hprev,mov;
 static int temps,tempm,temph;
 char *msgs,*msgm,*msgh,*msg1,*msgmov;

  msgmov=(char*)malloc(10);
  if(flag!=1)
  {
   temps = s + 180;
   tempm = temps / 60;
   temps = temps % 60;
   tempm = m + tempm;
   temph = tempm / 60;
   tempm = tempm % 60;
   temph = temph + h;
   if(temps<10)
    sprintf(msg1,"0%d",temps);
   else
    sprintf(msg1,"%d",temps);
   moveto(x,y+195);
   setcolor(11);
   outtext(msg1);

   if(tempm<10)
    sprintf(msg1,"0%d",tempm);
   else
    sprintf(msg1,"%d",tempm);
   moveto(x-30,y+195);
   setcolor(11);
   outtext(msg1);

   if(temph<10)
    sprintf(msg1,"0%d",temph);
   else
    sprintf(msg1,"%d",temph);
   moveto(x-60,y+195);
   setcolor(11);
   outtext(msg1);
  }
  if(h<10)
   sprintf(msgh,"0%d",h);
  else
   sprintf(msgh,"%d",h);
  if(m<10)
   sprintf(msgm,"0%d",m);
  else
   sprintf(msgm,"%d",m);
  if(s<10)
   sprintf(msgs,"0%d",s);
  else
   sprintf(msgs,"%d",s);
  if(move<10)
   sprintf(msgmov,"0%d",move);
  else
   sprintf(msgmov,"%d",move);
  setcolor(11);
  outtextxy(490,129,":");
  outtextxy(460,129,":");
  setcolor(11);
  outtextxy(490,y+195,":");
  outtextxy(460,y+195,":");
  if(flag!=0)
  {
   if(sprev<10)
    sprintf(msg1,"0%d  ",sprev);
   else
    sprintf(msg1,"%d  ",sprev);
   if(sprev!=s)
   {
    moveto(x,y);
    setcolor(0);
    outtext(msg1);
   }
   if(mprev<10)
    sprintf(msg1,"0%d",mprev);
   else
    sprintf(msg1,"%d",mprev);
   if(mprev!=m)
   {
    moveto(x-30,y);
    setcolor(0);
    outtext(msg1);
   }
   if(hprev<10)
    sprintf(msg1,"0%d",hprev);
   else
    sprintf(msg1,"%d",hprev);
   if(hprev!=h)
   {
    moveto(x-60,y);
    setcolor(0);
    outtext(msg1);
   }
   if(mov<10)
    sprintf(msg1,"0%d",mov);
   else
    sprintf(msg1,"%d",mov);
   if(mov!=move)
   {
    moveto(x-30,y+96);
    setcolor(0);
    outtext(msg1);
   }
  }
  moveto(x,y);
  setcolor(11);
  outtext(msgs);
  moveto(x-30,y);
  setcolor(11);
  outtext(msgm);
  moveto(x-60,y);
  setcolor(11);
  outtext(msgh);
  moveto(x-30,y+96);
  setcolor(11);
  outtext(msgmov);

  delay(100);
  sprev=s;
  mprev=m;
  hprev=h;
  mov=move;
  flag=1;
  if(temps==s && tempm == m && temph == h)
  {
   Sound(4,5);
   Exit(TIME_OVER);
  }
 }
void printbox(int px1,int py1,int px2,int py2)
{
 setfillstyle(1,0);
 setcolor(8);
 bar3d(px1,py1,px2,py2,0,0);
}

//Function  Definitions
void window(int x1,int y1,int length,int width)
{
 setfillstyle(1,16);
 bar(x1-2,y1-2,length+2,width+2);
 setfillstyle(1,8);
 bar(x1-1,y1-1,length+1,width+1);
 setfillstyle(1,7);
 bar(x1,y1,length,width);
 setcolor(WHITE);
 line(x1,y1,length,y1);
 line(x1,y1,x1,width);
 setcolor(8);
 line(x1+2,y1+2,length-2,y1+2);
 line(x1+2,y1+2,x1+2,width-2);
 setcolor(16);
 line(x1+3,y1+3,length-4,y1+3);
 line(x1+3,y1+3,x1+3,width-3);
 setcolor(WHITE);
 line(length,y1,length,width);
 line(x1,width,length,width);
 setcolor(8);
 line(length-2,y1+2,length-2,width-2);
 line(x1+2,width-2,length-2,width-2);
 setcolor(16);
 line(length-3,y1+3,length-3,width-3);
 line(x1+3,width-3,length-4,width-3);
}

void button(int x1,int y1,int x2,int y2,int flag,char *bname)
{
 setfillstyle(1,7);
 bar(x1,y1,x2,y2);
 buttoneffect(x1,y1,x2,y2,flag,bname);
}

void buttoneffect(int x1,int y1,int x2,int y2,int flag,char *bname)
{
 int value=15;
  if(flag==1)
  {
   setcolor(15);
   line(x1,y1,x2,y1);
   line(x1,y1,x1,y2);
   setcolor(0);
   line(x1,y2,x2+1,y2);
   line(x2+1,y1,x2+1,y2);
   moveto(x1+12,y1);
   setcolor(0);
   settextstyle(2,0,5);
  }
  else
  {
   setcolor(0);
   line(x1,y1,x2,y1);
   line(x1,y1,x1,y2);
   setcolor(15);
   line(x1,y2,x2+1,y2);
   line(x2+1,y1,x2+1,y2);
   setcolor(0);
 }
 if(strlen(bname) < 2)
  value=0;
 if(flag==1)
   moveto((x1+x2)/2-value,((y1+y2)/2)-8);
 else
   moveto((x1+x2)/2+2-value,((y1+y2)/2)-5);
   settextstyle(2,0,5);
   outtext(bname);
}

void Button(int r,int c,int flag,char *msg)
{
 int X1=140,Y1=110;
// int X1=225,Y1=140;

 X1=X1+10;
 Y1=Y1+10;
 button(X1+(c*57),Y1+(r*55),(X1+50)+(c*57),(Y1+50)+(r*55),flag,msg);
}

void lines(int x1,int y1,int length,int flag)
{
if(flag==0)
{
 setcolor(16);
 line(x1,y1,length,y1);
 setcolor(8);
 line(x1,y1+1,length,y1+1);
 setcolor(7);
 line(x1-1,y1+2,length+1,y1+2);
 setcolor(WHITE);
 line(x1-2,y1+3,length+2,y1+3);
 setcolor(7);
 line(x1-1,y1+4,length+1,y1+4);
 setcolor(8);
 line(x1,y1+5,length,y1+5);
 setcolor(16);
 line(x1,y1+6,length,y1+6);
}
else
{
 setcolor(0);
 line(x1,y1,x1,length);
 setcolor(8);
 line(x1+1,y1,x1+1,length);
 setcolor(7);
 line(x1+2,y1,x1+2,length+1);
 setcolor(15);
 line(x1+3,y1-2,x1+3,length+3);
 setcolor(7);
 line(x1+4,y1,x1+4,length+1);
 setcolor(8);
 line(x1+5,y1,x1+5,length);
 setcolor(0);
 line(x1+6,y1,x1+6,length);
}
}

void erase(int x1,int y1,int x2,int y2)
{
   int i;

   for(i=y1-1;i<=y2;i++)
   {
   setviewport(x1-1,i,x2+1,i+1,1);
   clearviewport();
   delay(75);
   }
}
void process(int x1,int y1)
{
 int i;
 for(i=0;i<=400;i++)
 {
  putpixel(x1+50+i,y1+300,0);
  putpixel(x1+50+i,y1+301,8);
  putpixel(x1+50+i,y1+302,7);
  putpixel(x1+50+i,y1+303,15);
  putpixel(x1+50+i,y1+304,7);
  putpixel(x1+50+i,y1+305,8);
  putpixel(x1+50+i,y1+306,0);
  delay(30);
 }
}
void Sound(int flag,int n)
{
 int i;
 for(i=1;i<=n;i++)
 {
  switch(flag)
  {
   case 1:  sound(6000); break;
   case 2:  sound(4000); break;
   case 3:  sound(2000); break;
   case 4:  sound(1000); break;
   case 5:  sound(500); break;
  }
  delay(200);

  nosound();
 }
}

void initmouse()
{
   i.x.ax=0;
   int86(0x33,&i,&o);
}

void showmouse()
{
   i.x.ax=1;
   int86(0x33,&i,&o);
}

void hidemouse()
{
   i.x.ax=2;
   int86(0x33,&i,&o);
}
void ZeroMouse()
{
   i.x.ax=4;
   int86(0x33,&i,&o);
   o.x.cx=0;
   o.x.dx=0;
}

void getmouse(int button[1],int x[1],int y[1])
{
   i.x.ax=3;
   int86(0x33,&i,&o);
   button[0]=o.x.bx;
   x[0]=o.x.cx;
   y[0]=o.x.dx;
}
void restrictmouse(int x1, int y1, int x2, int y2)
{
   i.x.ax = 7;
   i.x.cx = x1;
   i.x.dx = x2;
   int86(0x33, &i, &o);
   i.x.ax = 8;
   i.x.cx = y1;
   i.x.dx = y2;
   int86(0x33, &i, &o);
}
void restoremouse()
{
   i.x.ax = 7;
   i.x.cx = 0;
   i.x.dx = 638;
   int86(0x33, &i, &o);
   i.x.ax = 8;
   i.x.cx = 0;
   i.x.dx = 478;
   int86(0x33, &i, &o);
}

