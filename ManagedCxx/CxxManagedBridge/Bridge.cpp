#include "StdAfx.h"
#include "Bridge.h"

using namespace ManagedLibrary;

Bridge::Bridge(void)
{
}


Bridge::~Bridge(void)
{
}


CString Bridge::CrossTheBridge(CString &data)
{
	SimpleClass^ sc = gcnew SimpleClass();
	sc->DoSomething("Hello world!");
}
