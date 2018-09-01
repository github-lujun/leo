#pragma once

#define LIST_INIT_SIZE 100
#define LISTINCREMENT 10

typedef int ElemType;

typedef struct
{
	ElemType *elem;
	int length;
	int listsize;
} SqList;

typedef void(*action)(ElemType e);

__declspec(dllexport) bool initList(SqList &sqList);
__declspec(dllexport) bool destroyList(SqList &sqList);
__declspec(dllexport) bool emptyList(SqList sqList);
__declspec(dllexport) bool clearList(SqList &sqList);
__declspec(dllexport) int listLength(SqList sqList);
__declspec(dllexport) void travelList(SqList sqList,action action);
__declspec(dllexport) ElemType getElem(SqList sqList, int i);
__declspec(dllexport) int locateElem(SqList sqList, ElemType e);
__declspec(dllexport) ElemType preElem(SqList sqList, int i);
__declspec(dllexport) ElemType nextElem(SqList sqList, int i);
__declspec(dllexport) bool listInsert(SqList &sqList, int i, ElemType e);
__declspec(dllexport) bool listDelete(SqList &sqList, int i, ElemType &e);

__declspec(dllexport) bool listUnion(SqList &sqList1, SqList sqList2);
__declspec(dllexport) bool listMerge(SqList sqList1, SqList sqList2, SqList &sqList3);