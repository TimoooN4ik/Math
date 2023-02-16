#include <iostream>
#include <fstream>

using namespace std;

double T = 50, N = 100, n = 6;
double* x1 = new double[n];
double* x2 = new double[n];

void X1()
{
    ofstream out;
    out.open("result.txt");
    out << "X1:" << endl;
    double x01 = 0, h = T/N, k1 = 0, a = 2000, v1 = 10.84;

    x1[0] = x01;

    for (int i = 1; i < n; i++)
    {
        x1[i] = x1[i - 1] * (1 - k1 * (T / N));
        x1[i] += (T / N) * (a - v1);
        //out << "t = " << i << ", x1 = " << x1[i] << endl;
        //out << "(" << i << "; " << x1[i] << ")" << endl;
        out << x1[i] << endl;
    }
    out.close();
}

void X2()
{
    ofstream out;
    out.open("result.txt", ios::app);
    out << "\nX2:" << endl;
    double x02 = 0, k2 = 0, b = 18.4, v2 = 6.04, v1 = 10.84;

    x2[0] = x02;

    for (int i = 1; i < n; i++)
    {
        x2[i] = x2[i - 1] * (1 - k2 * (T / N));
        x2[i] += (T / N) * v1;
        //out << "t = " << i << ", x1 = " << x2[i] << endl;
        //out << "(" << i << "; " << x2[i] << ")" << endl;
        out << x2[i] << endl;
    }
    out.close();
}

int main()
{
    setlocale(LC_ALL, "Russian");

    double v2 = 6.04, u2 = 3;
    double sumX1 = 0, sumX2 = 0;
    X1();
    X2();

    cout << "Результаты вычислений сохранены в файл result.txt" << endl;

    for (int i = 0; i < n; i++)
    {
        sumX1 += x1[i] * u2 * (T / N);
        sumX2 += x2[i] * v2 * (T / N);
    }

    ofstream out;
    out.open("summ.txt");
    out << "Sum of X1: " << sumX1 << ", sum of X2: " << sumX2;
    out.close();

    cout << "Sum of X1: " << sumX1 << ", sum of X2: " << sumX2;
    cin.get();
}