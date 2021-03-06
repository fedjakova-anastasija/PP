#include "pch.h"
#include <ctime>
#include <fstream>
#include <iostream>
#include <string>
#include <vector>
#include <windows.h>

template <class T>
using Matrix = std::vector<std::vector<T>>;

void MatrixOperations(std::istream& input, int threadCount);
int Rank();

int StringToInt(const char* str, bool& err)
{
	char* pLastChar = NULL;
	int param = strtol(str, &pLastChar, 10);
	err = ((*str == '\0') || (*pLastChar != '\0'));

	return param;
}

bool IsNumberInBounds(int number)
{
	if ((number < 1) || (number > 16))
	{
		std::cout << "Input must be in range [0, 16]" << std::endl;
		return false;
	}

	return true;
}

int main(int argc, char* argv[])
{
	HANDLE process = GetCurrentProcess();
	SetProcessAffinityMask(process, 0b1111);
	clock_t start = clock();
	if (argc != 3)
	{
		std::cout << "Wrong number of arguments." << std::endl;
		std::cout << "Usage: RankMatrix.exe <input file> <tread number>" << std::endl;
		return 1;
	}

	const std::string inputFileName = argv[1];
	std::ifstream inputFile(inputFileName);
	if (!inputFile.is_open())
	{
		std::cout << "Input file cannot be opened." << std::endl;
		return 1;
	}

	bool wasErr;
	int threadNumber = StringToInt(argv[2], wasErr);
	if (wasErr)
	{
		std::cout << "Input is not a number." << std::endl;
		return 1;
	}

	if (!IsNumberInBounds(threadNumber))
	{
		return 1;
	}

	MatrixOperations(inputFile, threadNumber);
	std::cout << Rank() << std::endl;

	clock_t end = clock();
	clock_t clockTicksTaken = end - start;
	double timeInSeconds = clockTicksTaken / (double)CLOCKS_PER_SEC;
	std::cout << "Time: " << timeInSeconds << " s";
	return 0;
}

Matrix<float> mainMatrix;
int matrixSize;
int threadNumber;
const double EPS = 1E-9;

struct MatrixStruct
{
	std::istream* data;
	Matrix<float>* matrix;
	int start, end, row, col, size;
};

DWORD WINAPI GetMatrix(PVOID pvParam)
{
	auto matrixStruct = (MatrixStruct*)pvParam;
	float number;
	std::vector<float> line;
	for (int i = 0; i < matrixStruct->size; i++)
	{
		line.clear();
		for (int j = 0; j < matrixStruct->size; j++)
		{
			(*(matrixStruct->data)) >> number;
			line.push_back(number);
		}

		(*(matrixStruct->matrix)).push_back(line);
	}

	ExitThread(0);
}

DWORD WINAPI WorkMatrix(PVOID pvParam)
{
	auto matrixStruct = (MatrixStruct*)pvParam;
	int j = matrixStruct->row;
	int i = matrixStruct->col;

	for (int k = matrixStruct->start; k < matrixStruct->end; ++k)
	{
		if (k != j && abs((*matrixStruct->matrix)[k][i]) > EPS)
		{
			for (size_t p = i + 1; p < (*(matrixStruct->matrix)).size(); ++p)
			{
				(*(matrixStruct->matrix))[k][p] -= (*(matrixStruct->matrix))[j][p] * (*(matrixStruct->matrix))[k][i];
			}
		}
	}

	ExitThread(0);
}

void MatrixOperations(std::istream& input, int threads)
{
	input >> matrixSize;
	threadNumber = threads > matrixSize ? matrixSize : threads;
	auto* matrixStruct = new MatrixStruct;
	matrixStruct->data = &input;
	matrixStruct->matrix = &mainMatrix;
	matrixStruct->size = matrixSize;
	HANDLE* hTread = new HANDLE;
	*hTread = CreateThread(NULL, 0, &GetMatrix, (PVOID)matrixStruct, 0, NULL);
	WaitForMultipleObjects(1, hTread, true, INFINITE);
}

int Rank()
{
	Matrix<float> matrix(mainMatrix);
	int rank = matrixSize;
	std::vector<char> str(matrixSize);

	for (int i = 0; i < matrixSize; i++)
	{
		int j;
		for (j = 0; j < matrixSize; j++)
		{
			if (!str[j] && (abs(matrix[j][i]) > EPS))
				break;
		}

		if (j == matrixSize)
		{
			--rank;
		}
		else
		{
			str[j] = true;
			for (int p = i + 1; p < matrixSize; p++)
			{
				matrix[j][p] /= matrix[j][i];
			}

			int step = matrixSize / threadNumber;
			int threadCounter = threadNumber;
			HANDLE* hTread = new HANDLE[threadNumber];

			for (int k = 0; threadCounter != 0; k += step)
			{
				--threadCounter;
				auto* matrixStruct = new MatrixStruct;
				matrixStruct->matrix = &matrix;
				matrixStruct->col = i;
				matrixStruct->row = j;
				matrixStruct->start = k;

				matrixStruct->end = (threadCounter != 0) ? k + step : matrixSize;

				hTread[threadCounter] = CreateThread(NULL, 0, &WorkMatrix, (PVOID)matrixStruct, 0, NULL);
			}

			WaitForMultipleObjects(threadNumber, hTread, true, INFINITE);
		}
	}
	return rank;
}