#include <fstream>
#include <iostream>
#include <math.h>
#include <stdio.h>

#define Pi 3.1415926
#define grad 180 / Pi

#define C 0.2

using namespace std;

double f(double x) //начальные условия U(x,0) = f(x) в виде кинка
{
	double result = 4 * atan(exp(x / (sqrt(1 - C * C))));
	return result;
}

double g(double x)	//начальные условия dU/dt = g(x) в виде кинка
{
	double result = (- C / (sqrt(1 - C * C)) ) * (1 / (exp(x / sqrt(1 - C * C)) + exp(-x / sqrt(1 - C * C))) );
	return result;
}

int main() {

	setlocale(LC_ALL, "Russian");

	ofstream file;
	file.open("result.txt");
	file << std::fixed << 221414252135125453453245325234.0 << std::endl;

	/*cout << "При каких t записывать в файл значения? (max - 4 числа, 0 - закончить ввод)" << endl;
	int* time = new int[8];
	for (int k = 0; k < 8; k++)
	{
		cin >> time[k];
		if (time[k] == 0)
			break;
	}*/

	int a = -10, b = 10;				//отрезок на котором ищем функцию
	int length = b - a;
	double dx = 0.05;					//step on x
	double dt = 0.02;					//step on t 51 102 153 204
	double alfa = dt / dx;
	int T = 100;						//time
	int n = int(length / dx) + 1;		//количество точек по х

	double *u = new double[n];
	double *u1 = new double[n];			// j -й временной слой
	double *u2 = new double[n];			// j+1 временной слой

	double x = a + dx;
	for (int i = 0; i < n; i++, x += dx /*делаем шаг по х*/)			//заполняем значения начального (первого) временного слоя
		u1[i] = f(x);

	x = double(a) + dx;
	for (int i = 0; i < n; i++, x += dx) 						//заполняем значения второго врменного слоя
		u2[i] = g(x) * dt + u1[i];
	
	//file << "t = 2" << endl;
	for (int i = 0; i < n; i++)
		file << "(" << a + dx * i << ";" << u2[i] << ") ";
	file << endl;
	
	double temp = 0;
	
	//каждую итерацию находим новый временной слой, на основе двух предыдущих слоев u и u1
	//после нахождения нового слоя, j-1 слой (массив u) не нужен, и поэтому новые данные записываем в u
	for(int counter = 0; counter < T/dt + 1; counter++) {
		for (int i = 1, x = a + dx; i < n - 1; i++, x += dx) 		//u(j+1) - temp, u(j) - u2[], u(j-1) - u1[]
			u[i] = 2 * u2[i] - u1[i] + alfa * alfa * (u2[i + 1] - 2 * u2[i] + u2[i - 1]) - dt * dt * sin(u2[i]);			//нахождение нового врменного слоя j+1
		
		u[0] = u1[1];
		u[n - 1] = u2[n - 2];
		
		for (int j = 0; j < n; j++) {
			u1[j] = u2[j];
			u2[j] = u[j];
		}
		
		//if (counter == time[0] || counter == time[1] || counter == time[2] || counter == time[3] || counter == time[4] || counter == time[5] || counter == time[6] || counter == time[7]) {
			//file << "t = " << counter << endl;
		for (int j = 0; j < n; j++)
			file << "(" << a + dx * j << ";" << u[j] << ") ";
		file << endl;
		//}
	}
	file.close();
}