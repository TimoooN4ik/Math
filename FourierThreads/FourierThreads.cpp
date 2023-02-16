#include <stdio.h>
#include <iostream>
#include <math.h>
#include <windows.h>
#include <time.h>

#define Pi 3.14

using namespace std;

int n = 4;
double* result = new double[n];

//Функция для запуска в потоке
DWORD WINAPI seriesSumm(LPVOID lpdwParam)			//эта функция запускается столько раз, сколько потоков мы используем
{
	int sign = 1;
	int *i = (int*)lpdwParam;
	double x = x = (-1 * Pi) + (2 * Pi / n) * i[0];
	double summ = 0;
	for (int j = 1; j < 100000; j++)
	{
		if (j % 2 == 0)
			sign = 1;
		else
			sign = -1;

		summ += (sign * sin(j * x)) / j;			//делаем расчет суммы ряда
	}

	result[i[0]] = 1 - 2 * summ;					//и записываем сумму в глабоальную переменную, т.к. из функции запускаемой в потоке нет возможности возвращать значения

	ExitThread(0);
}

int main()
{
	setlocale(LC_ALL, "Russian");
	cout << "Для функции х+1, при разложении в ряд Фурье, получаем коэффициенты a0 = 2, an = 0, bn = -(2 * (-1)^n) / n" << endl;
	//int number[10] = { 0, 1, 2,3,4,5,6,7,8,9 };
	int* number = new int[n];
	
	HANDLE* hThread = new HANDLE[n];				//объявляем массив потоков. Количество потоков равно количеству точек. И парарллелизация программы идет по точкам
													//Т.к. каждой точке для расчета суммы ряда мы запускаем отдельный поток
	
	int start = clock();
	for (int i = 0; i < n; i++)
	{
		number[i] = i;								//записываем номер потока (от 0 до н - количества потоков). По номеру будет определяться точка по Х, для которой будем считать сумму ряда
		hThread[i] = CreateThread(NULL, 0, &seriesSumm, &number[i], 0, NULL);	//создаем запуск потока hThread[i], отправляем туда имя функции, и номер потока
	}

	WaitForMultipleObjects(n, hThread, TRUE, INFINITE);							//запускаем ожидания окончания каждого из потоков
	int finish = clock();
	
	cout << "\nЗначения ряда для точек от -Pi до Pi: ";
	for (int i = 0; i < n; i++)
		cout << result[i] << " ";												//по итогу для каждой точки в этом массиве значение суммы ряда

	cout << endl << endl << n << " потоков, с частотой сетки 10 и длиной ряда 100000 выполняеются за " << finish - start << " тиков\n";
	cin.get();

}