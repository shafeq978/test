#include <iostream>

using namespace std;

int main()
{
	
     	float viz , fnal;
   	float sonuc[8];
   	 char  a[8][8];
   		for (int i=0;i<8;i++){
         cout<<" ders adi giriniz : ";
            cin>>a[i];
            cout<<"vize notu giriniz : ";
            cin>>viz;
               cout<<"fnal notu giriniz : ";
            cin>>fnal;
            sonuc[i]=viz*0.4 + fnal*0.6;
   		}
   		for (int i=0;i<8;i++){
            cout<<"denin gecme notu :   " << a[i] <<"   "  << sonuc[i] << endl;
   		}
    return 0;
}
