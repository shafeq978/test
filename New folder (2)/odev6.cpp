
#include <iostream>
#include <math.h>
using namespace std;

int main()
{
    int a1;
     cout << "bir sayi giriniz  " << endl;
     cin>>a1;
     for(int i=0;i<3;i++){
         cout<< pow(10,i)<<"   lar/ler basamak :   "<<(a1%10)<<endl;
         a1/=10;
     }
    return 0;
}

