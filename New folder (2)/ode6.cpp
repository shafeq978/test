#include <iostream>

using namespace std;

int main()
{
	int n,i=1,sum=0;
	cout<<"enter number : ";
	cin>>n;
	if(n<10000){
	while(i<n){
		if(n%i==0)
		sum +=i;
		i++;
	}
	if(sum==n)
	cout<<"  "<< i <<"  is perfect number";
	else
	cout<<"  "<< i <<"  is not perfect number";
	}
	else
        cout<<"wrong number"<<endl;
    return 0;
}

