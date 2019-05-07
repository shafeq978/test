#include <iostream>
using namespace std;

int main()
{
   int Num;
   cout<< "enter  number"<<endl;
   cin>>Num;
        if (Num == 1)
             cout<< " number is not primes"<<endl;
     else if ((Num == 2) | (Num == 3) | (Num == 5))
           cout<< " number is primes"<<endl;
     else if ((Num % 2 == 0) || (Num % 3 == 0) || (Num % 5 == 0)) {
             cout<< " number is not primes"<<endl;}
     else
     cout<< " number is primes"<<endl;
    return 0;
}


