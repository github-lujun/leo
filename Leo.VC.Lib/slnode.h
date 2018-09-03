#pragma once

#define MAXSIZE 1000

typedef int ElemType;

typedef struct
{
	ElemType data;
	int cur;
}component, SLinkList[MAXSIZE];

__declspec(dllexport) int locateElem(SLinkList s, ElemType e);