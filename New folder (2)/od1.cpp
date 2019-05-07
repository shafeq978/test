#include <iostream>

using namespace std;

int main()
{
    int a =70 ;
    double b = 0.025;
    float d =0;
     for(int i =2001;i<2011;i++){
        d = a + (a*b);
        b = b +0.025;
       cout << "country population  of  "<<i<<" = "<<d <<endl;
     }
    return 0;
}

