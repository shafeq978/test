
#include <iostream>
#include <math.h>
using namespace std;

int main()
{
    int a1,a,c;
     cout << "bir sayi giriniz  " << endl;
     cin>>a1;
     for(int i=0;i<4;i++){
       a = pow(10,3);
        c = (a1%10);
		 a1/=10;
     }
     cout<< a<<"    basamak :   "<<c<<endl;
    return 0;
}

