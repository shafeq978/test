#include <cmath>
#include <cstring>
#include <iostream>
#include <stdlib.h>
#include<string>
using namespace std;
int main()
{
	char a[55];
	cin>>a;
	int b= strlen(a);
    int x=0;
    for(int i= 0;i<b/3;i++)
     {
	cout<<"  ";
	for(int j=0;j<3;j++)	
	  {
      cout<<a[x];
      x++;
	  }
    }
}   
