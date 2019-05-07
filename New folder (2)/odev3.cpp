#include <iostream>

using namespace std;

int main()
{
   	float a,b,c;
	cout << "  enter the same equations" <<endl;
    cout<<"       A(x*x) + BX + C = 0   "  <<endl;
    cout<<"  OR   A(x*x) - BX - C = 0   "<<endl;
    cout<<"  OR   A(x*x) - BX + C = 0   "<<endl;
    cout<<"  OR   A(x*x) + BX - C = 0   "<<endl;
	cout << "enter A : " ; 
	cin >>a;
	cout << "enter B : " ;
	cin >>b;
	cout << "enter C : " ;
	cin >>c;
	cout << "x =  "<<-1*c << "  or  x =  "<< (-1*b)/a;
    return 0;
}

