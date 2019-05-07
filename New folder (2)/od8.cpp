#include <iostream>
#include <time.h>
#include <stdlib.h>
using namespace std;

int main()
{
	int n,s;
	do{
	
		int v = rand() % 100 + 1;
	cout<<" enter number : ";
	cin>>n;
	if(n>v){
	  cout<<"number is Large   "<<endl;
	    cout<< "random number is : "<<v<<endl ;
	}
	else
    {
      cout<<"number is Small    "<<endl;
    	cout<< "random number is : "<<v<<endl;
    }
	cout<<"enter 1 to Repeat the process  : "<<endl;
	cin>>s;
	}
    while(s==1);
    return 0;
}

