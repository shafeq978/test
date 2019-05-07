#include <iostream>

using namespace std;

int main()
{
   int a,b;
   char c;

   do {
         cout<< "enter first number"<<endl;
   cin>>a;
    cout<< "enter second number"<<endl;
   cin>>b;
    cout<<" collecting is : "<<a+b<<endl;
       cout<<"enter char : ";
   cin>>c;
   }
   while(c == 'e' || c == 'E');

 return 0;
     }
