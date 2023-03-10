#include <iostream>
#include "windows.h"

void main()
{
	HANDLE hHeap;			// указатель на частную кучу
	int n;
	std::cin >> n;	// указатель на кучу по умолчанию
	size_t size = n * sizeof(int);
	hHeap = HeapCreate(0, 0, 0);	// создать частную кучу

	int* intName = NULL;			// указатель на память
	intName = (int*)HeapAlloc(hHeap, 0, size);	// выделить в нашей памяти место

	int* intName2 = NULL;			// указатель на память
	intName2 = (int*)HeapAlloc(GetProcessHeap(), 0, size);	// выделить в нашей памяти место

	int k;
	std::cin >> k;
	size_t size2 = k * sizeof(int);
	if (size2 > size) 
	{
		intName = (int*)HeapReAlloc(hHeap, 0, intName, size2);
		intName2 = (int*)HeapReAlloc(GetProcessHeap(), 0, intName2, size2);
	}
	std::cout << "extra heap" << std::endl;
	for (int i = 0; i < (k-1); i++) {
		intName[i] = i * i;
		std::cout << intName[i] << std::endl;
	}

	std::cout << "default heap" << std::endl;
	for (int i = 0; i < (k-1); i++) {
		intName2[i] = i * 3;
		std::cout << intName2[i] << std::endl;
	}
	
	HeapFree(GetProcessHeap(), 0, intName2);
	HeapFree(hHeap, 0, intName);
}