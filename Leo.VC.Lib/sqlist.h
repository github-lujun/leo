#pragma once

#define LIST_INIT_SIZE 100
#define LISTINCREMENT 10

typedef int ElemType;

typedef struct
{
	ElemType *elem;
	int length;
	int listsize;
}SqList;

class _declspec(dllexport) Sq
{
	public:
		SqList sqList;

		Sq();
		ElemType getElem(int i);
		bool listInsert(int i, ElemType e);
		bool listDelete(int i, ElemType &e);
};
