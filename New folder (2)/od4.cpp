#include <iostream>

using namespace std;

int main()
{
     	float viz[8] , fnal[8] ;
     	int x;
   	float sonuc[8];
	  char son[8];
   	 char a[8][20];
   		for (int i=0;i<8;i++)
		   {
   			
         cout<<" ders adi giriniz : ";
            cin>>a[i];
            cout<<"vize notu giriniz : ";
            cin>>viz[i];
               cout<<"fnal notu giriniz : ";
            cin>>fnal[i];
            sonuc[i]=viz[i]*0.4 + fnal[i]*0.6;
           }
           for(int i=0;i<8;i++){
           cout<<sonuc[i]<<endl;
           if(sonuc[i] >50)
           x++;}
           if (x==8)
           cout<<"  passed ";
           else
           cout<<" failed ";
    return 0;
}

