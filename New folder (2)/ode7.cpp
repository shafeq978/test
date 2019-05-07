#include <cmath>
#include <cstring>
#include <iostream>
#include <stdlib.h>
#include<string>
using namespace std;
int main()
{
	int a,b,bol=2,obe=1,c,d;
	cin>>a>>b;
	c=a;
	d=b;
   while(a >1 || b>1)
{if (a% bol==0 && b% bol==0)
{obe *= bol;
a/=bol;
b/=bol;
}
else if(a%bol==0)
{a/=bol;
}
else if (b%bol==0){
b/=bol;}
else {
bol++;	
}	}	
cout<<" obeb  =  "<<obe<<endl; 

 for(int j= 1;j<=c*d;j++)
     {
     	if(j%c==0 && j%d==0){
	cout<<" okek  =  "<<j<<endl;
	break;}
	}   
    return 0;
}   
