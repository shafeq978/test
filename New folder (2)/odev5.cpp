#include <iostream>

using namespace std;

int main()
{
    float a1,b1,a2,b2,a3,b3,c1,c2,c3;
    
     cout << "enter speed" << endl;
     cin>>a1;
     cout << "enter time in minute" << endl;
     cin>>b1;
     cout << "enter speed" << endl;
     cin>>a2;
      cout << "enter time in minute" << endl;
     cin>>b2;
     cout << "enter speed" << endl;
     cin>>a3;
       cout << "enter time in minute" << endl;
     cin>>b3;
     cout << "Average speed  = " <<(a1+a2+a3)/((b1+b2+b3)/60)<<" km/h"<< endl;
 
    return 0;
}

