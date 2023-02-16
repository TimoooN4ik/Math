#include <iostream> 
#include <stdlib.h> 
#include "mpi.h" 

using namespace std;

int main(int argc, char* argv[])
{
    int m = 3, n = 4;   //размеры матрицы

    int **array = new int*[m];
    for (int i = 0; i < m; i++)
    {
        array[i] = new int[n];
        for (int j = 0; j < n; j++)
        {
            array[i][j] = rand() % 100;
            //cout << a[i][j] << " ";
        }
        //cout << endl;
    }

    int rank, numtasks;

    MPI_Init(&argc, &argv);
    MPI_Comm_rank(MPI_COMM_WORLD, &rank);           //номер текущего потока
    MPI_Comm_size(MPI_COMM_WORLD, &numtasks);       //количество потоков

    int tmpSlider = rank, max = 0, column = 0, line = 0, countOfMax = 0;

    int* buf = (int*)calloc(1, sizeof(int));                //буфер для отправки сообщения
    int* recvBuf = (int*)calloc(1 * numtasks, sizeof(int)); //буфер приема сообщений

    if (rank < n)
    {
        column = 0;
        line = rank;
    }

    max = array[column][line];

    while (tmpSlider < m * n)
    {
        if ((n - 1) < tmpSlider)
        {
            line = tmpSlider % n;
            column = (tmpSlider - line) / n;
        }
        else
        {
            column = 0;
            line = tmpSlider;
        }

        if (array[column][line] > max)
            max = array[column][line];

        tmpSlider += numtasks;
    }

    buf[0] = max;   //получив максимальный элемент, для потока - записываем его для отправки
    
    MPI_Allgather(buf, 1, MPI_INT, recvBuf, 1, MPI_INT, MPI_COMM_WORLD);    //отправка сообщений от всех ко всем

    for(int i = 0; i < numtasks; i += 1)
    {
        if (max < recvBuf[i])
            max = recvBuf[i];               //ищем максимальный среди всех
    }
    printf("proc %d find max element = %i\n", rank, max);
    
    tmpSlider = rank;

    while (tmpSlider < m * n)               //ищем количество повторений максимального элемента
    {
        if ((n - 1) < tmpSlider)
        {
            line = tmpSlider % n;
            column = (tmpSlider - line) / n;
        }
        else
        {
            column = 0;
            line = tmpSlider;
        }

        if (array[column][line] == max)
            countOfMax++;

        tmpSlider += numtasks;
    }

    printf("proc %d find max element %i times\n\n", rank, countOfMax);

    MPI_Finalize();

    for (int i = 0; i < m; i++)
        delete[] array[i];
    delete[] array;

    return 0;
}