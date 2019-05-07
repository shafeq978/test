#include <iostream>

using namespace std;

int main()
{
   	int x,y;
	cout << "enter x : ";
	cin >>x;
	cout << "enter y : " ;
	cin >>y;
	x+=y;
	x-=y;
	x*=y;
	x+=-y;
	 x-=-y;
	 x*=-y;
    cout << "x is  " <<x  << "  "<<"y is "<<y<< endl;
    return 0;
}
