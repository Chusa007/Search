// �����.cpp: ���������� ����� ����� ��� ����������� ����������.
//

#include "stdafx.h"
#include <iostream>
#include  <math.h> 
#include  <stdio.h>
#include <cstdlib>


double circle(double x, double radius) 
{ 
	double y=radius*radius-x*x; 
	return y; 
}

int _tmain(int argc, _TCHAR* argv[])
{
	double x,y,Pi; 
	long long int a = 5;//������� ���������
	long long int i=0;//������� 
	double Ncirc=0;//���������� �����, �������� � ���� 
	const double Nmax=250000; //����� ���������� �����

	Ncirc=0; i=0; 
	while (i<Nmax) 
	{ 
		x = (rand() % (a * 1000))/1000;  
		y = (rand() % (a * 1000))/1000;  
		if (y*y<=circle(x,(a/2)))  //������� �������������� ����� � �����
		{ 
			Ncirc++; 
		} 
		i++; 
	} 
	std::cout << "��������� ��������� � ���� � ���������� � ������� = " << Ncirc/Nmax;
	
} 


