#pragma once

#ifdef __NODLL__
		#define SPC_MANAGED_CLASS
		#define SPC_MANAGED_API
#else
	#ifdef BUILDMANAGEDAPIDLL
		#define SPC_MANAGED_CLASS _declspec(dllexport)
		#define SPC_MANAGED_API _declspec(dllexport)
	#else
		#define SPC_MANAGED_CLASS _declspec(dllimport)
		#define SPC_MANAGED_API _declspec(dllimport)
	#endif
#endif

#ifndef VC_EXTRALEAN
#define VC_EXTRALEAN            // Exclude rarely-used stuff from Windows headers
#endif

#define _ATL_CSTRING_EXPLICIT_CONSTRUCTORS      // some CString constructors will be explicit

#include <afxwin.h>         // MFC core and standard components
