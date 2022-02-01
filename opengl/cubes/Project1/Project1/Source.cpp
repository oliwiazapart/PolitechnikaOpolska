#define WIN32_LEAN_AND_MEAN				// "odchudza" aplikacj� Windows

// Pliki nag��wkowe
#include <windows.h>					// standardowy plik nag��wkowy Windows
#include <gl/gl.h>						// standardowy plik nag��wkowy OpenGL
#include <gl/glu.h>						// plik nag��wkowy biblioteki GLU
#include <gl/glaux.h>					// funkcje pomocnicze OpenGL 

#pragma comment(lib, "legacy_stdio_definitions.lib")
#pragma warning(disable:4996)
#pragma comment(lib,"opengl32.lib") //informuje konsolidator, aby doda� bibliotek� do listy zale�no�ci bibliotek
#pragma comment(lib,"glu32.lib")

// Zmienne globalne
HDC g_HDC;								// globalny kontekst urz�dzenia
bool fullScreen = false;	// true = tryb pe�noekranowy; false = tryb okienkowy
bool keys[256];
DWORD tickCount, lasttickCount;

GLint numberCubesPerLine = 3;			// ilosc szescian�w w linii
int mode = 3;							//tryb 1- size, 2- obr�t ca�., 3-obr�t poj., 4- kolory
bool extend = true;						//powi�ksz/zmniejsz
GLfloat angleAll = 1.0f;				//kat obrotu szescianow
GLfloat angleSingle = 0.0f;			    //kat obrotu pojedynczego szescianu
GLfloat space = 1.8f;				    //odleg�o�� mi�dzy sze��
GLfloat spaceMin = 1.2f;			// minimalna odleg�o�� mi�dzy sze��
GLfloat spaceMax = 2.0f;			//maksymalna odleg�o�� mi�dzy sze��

//Kolory do zmiany
GLfloat orangeColor[3] = { 1.0f, 0.5f, 0.0f };
GLfloat pinkColor[3] = { 2.0f, 0.5f, 1.0f };
GLfloat greenColor[3] = { 0.0f, 1.0f, 0.0f };
GLfloat baseColor[3] = { 0.0f, 0.0f, 1.0f };
bool colorChanged = false;
// Parametry o�wietlenia
float ambientLight[] = { 0.2f, 0.2f, 0.2f, 1.0f };	    // �wiat�o otoczenia
float diffuseLight[] = { 1.0f, 1.0f, 1.0f, 1.0f };	    // �wiat�o rozproszone
float lightPosition[] = { 1.0f, 0.0f, 1.0f, 0.0f };	    // po�o�enie �r�d�a �wiat�a

// Parametry materia�u
float ambientMaterial[] = { 0.5f, 0.0f, 0.0f, 1.0f };
float diffuseMaterial[] = { 0.3f, 0.5f, 0.7f, 1.0f };


void Initialize()       // Inicjacja OpenGL
{
	glClearColor(0.0f, 0.0f, 0.0f, 0.0f);		// czarny kolor t�a

	glShadeModel(GL_SMOOTH);					// cieniowanie g�adkie
	glEnable(GL_DEPTH_TEST);					// w��czenie bufora g��bi
	glEnable(GL_CULL_FACE);						// ukrywanie tylnych stron wielok�t�w
	glFrontFace(GL_CCW);						// porz�dek wierzcho�k�w przeciwny do kierunku ruchu wskaz�wek zegara
	glEnable(GL_LIGHTING);						// w��czenie o�wietlenia
	glEnable(GL_COLOR_MATERIAL);				// W��CZENIE uwzgl�dniania kolor�w wierzcho�k�w przy o�wietlaniu
												// nieistotne s� wtedy poni�sze instrukcje ustawiaj�ce w�a�ciwo�ci materia�u i �r�d�a �wiat�a
	glClearDepth(1.0f);
	glDepthFunc(GL_LEQUAL);
	glHint(GL_PERSPECTIVE_CORRECTION_HINT, GL_NICEST);


	// Ustawienie w�a�ciwo�ci materia�u dla pierwszego �r�d�a �wiat�a LIGHT0
	glMaterialfv(GL_FRONT, GL_AMBIENT, ambientMaterial);
	glMaterialfv(GL_FRONT, GL_DIFFUSE, diffuseMaterial);

	// Ustawienie �r�d�a �wiat�a GL_LIGHT0
	glLightfv(GL_LIGHT0, GL_AMBIENT, ambientLight);		// sk�adowa otoczenia
	glLightfv(GL_LIGHT0, GL_DIFFUSE, diffuseLight);		// sk�adowa rozproszona
	glLightfv(GL_LIGHT0, GL_POSITION, lightPosition);	// po�o�enie �r�d�a �wiat�a

	// W��czenie �r�d�a �wiat�a
	glEnable(GL_LIGHT0);
}

void DrawCube(GLfloat rotation) //Narysowanie sze�cianu w xPos,yPos,zPos
{
	glPushMatrix();
	glRotatef(rotation, 0.0f, 1.0f, 0.0f);
	glBegin(GL_POLYGON);
	glNormal3f(0.0f, 1.0f, 0.0f);	// g�rna �ciana (w p�aszczy�nie XZ)
	glVertex3f(0.5f, 0.5f, 0.5f);
	glVertex3f(0.5f, 0.5f, -0.5f);
	glVertex3f(-0.5f, 0.5f, -0.5f);
	glVertex3f(-0.5f, 0.5f, 0.5f);
	glEnd();
	glBegin(GL_POLYGON);
	glNormal3f(0.0f, 0.0f, 1.0f);	// przednia �ciana (w p�aszczy�nie XY)
	glVertex3f(0.5f, 0.5f, 0.5f);
	glVertex3f(-0.5f, 0.5f, 0.5f);
	glVertex3f(-0.5f, -0.5f, 0.5f);
	glVertex3f(0.5f, -0.5f, 0.5f);
	glEnd();
	glBegin(GL_POLYGON);
	glNormal3f(1.0f, 0.0f, 0.0f);	// prawa �ciana (w p�aszczy�nie YZ)
	glVertex3f(0.5f, 0.5f, 0.5f);
	glVertex3f(0.5f, -0.5f, 0.5f);
	glVertex3f(0.5f, -0.5f, -0.5f);
	glVertex3f(0.5f, 0.5f, -0.5f);
	glEnd();
	glBegin(GL_POLYGON);
	glNormal3f(-1.0f, 0.0f, 0.0f);	// lewa �ciana (w p�aszczy�nie YZ)
	glVertex3f(-0.5f, 0.5f, 0.5f);
	glVertex3f(-0.5f, 0.5f, -0.5f);
	glVertex3f(-0.5f, -0.5f, -0.5f);
	glVertex3f(-0.5f, -0.5f, 0.5f);
	glEnd();
	glBegin(GL_POLYGON);
	glNormal3f(0.0f, -1.0f, 0.0f);	// dolna �ciana (w p�aszczy�nie XZ)
	glVertex3f(-0.5f, -0.5f, 0.5f);
	glVertex3f(-0.5f, -0.5f, -0.5f);
	glVertex3f(0.5f, -0.5f, -0.5f);
	glVertex3f(0.5f, -0.5f, 0.5f);
	glEnd();
	glBegin(GL_POLYGON);
	glNormal3f(0.0f, 0.0f, -1.0f);	// tylna �ciana (w p�aszczy�nie XY)
	glVertex3f(0.5f, -0.5f, -0.5f);
	glVertex3f(-0.5f, -0.5f, -0.5f);
	glVertex3f(-0.5f, 0.5f, -0.5f);
	glVertex3f(0.5f, 0.5f, -0.5f);
	glEnd();
	glPopMatrix();
}


void Render()   // Renderowanie sceny
{
	glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);		// Opr�nienie bufora ekranu i bufora g��bi
	glLoadIdentity();										// Zresetowanie macierzy modelowania


	glTranslatef(0.0f, 0.0f, -12);					//przeson w prz�d
	glRotatef(20, 1.0f, 0.0f, 0.0f);					//obr�c o 20stopni w d�


	glRotatef(angleAll, 0.0f, 1.0f, 0.0f);				//obr�� ca�y szyk o k�t ca�o�ci

	glTranslatef(-(numberCubesPerLine - 1) * space / 2,
		-(numberCubesPerLine - 1) * space / 2, -(numberCubesPerLine - 1) * space / 2);  //przesun calosc tak, zeby srodek szyku byl w srodku obrotu


	for (int i = 0; i < numberCubesPerLine; i++)
	{
		glPushMatrix();							//wrzucam akturalne po�o�enie na stos
		glTranslatef(i * space, 0.0f, 0.0f);   // przesuwam w osi x
		for (int j = 0; j < numberCubesPerLine; j++)
		{
			glPushMatrix();						//wrzucam aktualne po�o�enie na stos
			glTranslatef(0.0f, j * space, 0.0f); //przesuwam w osi y
			for (int k = 0; k < numberCubesPerLine; k++)
			{
				glPushMatrix();						//wrzucam aktualne po�o�enie na stos
				glTranslatef(0.0f, 0.0f, k * space); //przesuwam w osi x
				if (i == 2 && j == 2 && k == 2)			//pocz�tek robienia przek�tnej kolorowej
					glColor3f(orangeColor[0], orangeColor[1], orangeColor[2]);
				else if (i == 1 && j == 2 && k == 1)
					glColor3f(pinkColor[0], pinkColor[1], pinkColor[2]);
				else if (i == 0 && j == 2 && k == 0)
					glColor3f(greenColor[0], greenColor[1], greenColor[2]);
				else
					glColor3f(baseColor[0], baseColor[1], baseColor[2]);
				DrawCube(angleSingle);
				glPopMatrix();		//sciagnij polozenie ze stosu
			}						
			glPopMatrix();        //sciagnij polozenie ze stosu
		}					
		glPopMatrix();			//sciagnij polozenie ze stosu
	}

	if (mode == 1)
	{
		if (extend)
			space += 0.007f;
		else
			space -= 0.007f;

		if (space >= spaceMax || space <= spaceMin)
			extend = !extend;
	}
	
	if (mode == 2)
	{
		angleAll += 0.2f;
		if (angleAll > 360)
			angleAll -= 360;
		if (angleAll < 0)
			angleAll += 360;
	}

	if (mode == 3)
	{
		angleSingle += 0.4f;
		if (angleSingle > 360)
			angleSingle -= 360;
		if (angleSingle < 0)
			angleSingle += 360;
	}

	if (mode == 4)
	{

		if (!colorChanged)
		{
			//orange
			while (orangeColor[0] > 0.0f)
			{
				orangeColor[0] -= 0.002f;

			}
				
			while (orangeColor[1] > 0.0f)
			{
				orangeColor[1] -= 0.002f;
			}

			while (orangeColor[2] < 1.0f)
			{
				orangeColor[2] += 0.002f;
			}

			//pink
			while (pinkColor[0] > 0.0f)
			{
				pinkColor[0] -= 0.002f;

			}

			while (pinkColor[1] > 0.0f)
			{
				pinkColor[1] -= 0.002f;
			}

			while (pinkColor[2] < 1.0f)
			{
				pinkColor[2] += 0.002f;
			}

			//green
			while (greenColor[0] > 0.0f)
			{
				greenColor[0] -= 0.002f;

			}

			while (greenColor[1] > 0.0f)
			{
				greenColor[1] -= 0.002f;
			}

			while (greenColor[2] < 1.0f)
			{
				greenColor[2] += 0.002f;
			}
	
			colorChanged = true;
			
		}

	}

	if (mode == 5)
	{

		if (colorChanged)
		{
			//oragne
			while (orangeColor[0] < 1.0f)
			{
				orangeColor[0] += 0.002f;

			}

			while (orangeColor[1] < 0.5f)
			{
				orangeColor[1] += 0.002f;
			}

			while (orangeColor[2] > 0.0f)
			{
				orangeColor[2] -= 0.002f;
			}

			//pink
			while (pinkColor[0] < 2.0f)
			{
				pinkColor[0] += 0.002f;

			}

			while (pinkColor[1] < 0.5f)
			{
				pinkColor[1] += 0.002f;
			}

			while (pinkColor[2] > 1.0f)
			{
				pinkColor[2] += 0.002f;
			}

			//green
			while (greenColor[0] > 0.0f)
			{
				greenColor[0] -= 0.002f;

			}

			while (greenColor[1] < 1.0f)
			{
				greenColor[1] += 0.002f;
			}

			while (greenColor[2] > 0.0f)
			{
				greenColor[2] -= 0.002f;
			}

			colorChanged = false;
		}

	}
		

	glFlush();								// Zrzucenie bufora graficznego na ekran

	SwapBuffers(g_HDC);						// Prze��czenie bufor�w
}


void SetupPixelFormat(HDC hDC)  // Funkcja okre�laj�ca format pikseli
{
	int nPixelFormat;					// indeks formatu pikseli

	static PIXELFORMATDESCRIPTOR pfd = {
		sizeof(PIXELFORMATDESCRIPTOR),	// rozmiar struktury
		1,								// domy�lna wersja
		PFD_DRAW_TO_WINDOW |			// grafika w oknie
		PFD_SUPPORT_OPENGL |			// grafika OpenGL 
		PFD_DOUBLEBUFFER,				// podw�jne buforowanie
		PFD_TYPE_RGBA,					// tryb kolor�w RGBA 
		32,								// 32-bitowy opis kolor�w
		0, 0, 0, 0, 0, 0,				// nie specyfikuje bit�w kolor�w
		0,								// bez bufora alfa
		0,								// nie specyfikuje bitu przesuni�cia
		0,								// bez bufora akumulacji
		0, 0, 0, 0,						// ignoruje bity akumulacji
		16,								// 16-bitowy bufor Z
		0,								// bez bufora powielania
		0,								// bez bufor�w pomocniczych
		PFD_MAIN_PLANE,					// g��wna p�aszczyzna rysowania
		0,								// zarezerwowane
		0, 0, 0 };						// ignoruje maski warstw

	nPixelFormat = ChoosePixelFormat(hDC, &pfd);	// wybiera najbardziej zgodny format pikseli 
	SetPixelFormat(hDC, nPixelFormat, &pfd);		// okre�la format pikseli dla danego kontekstu urz�dzenia
}


LRESULT CALLBACK WndProc(HWND hwnd, UINT message, WPARAM wParam, LPARAM lParam)  // Procedura okienkowa
{
	static HGLRC hRC;					// kontekst tworzenia grafiki
	static HDC hDC;						// kontekst urz�dzenia
	int width, height;					// szeroko�� i wysoko�� okna

	switch (message)						// obs�uga komunikat�w
	{
	case WM_CREATE:					// Utworzenie okna
		hDC = GetDC(hwnd);			// pobiera kontekst urz�dzenia dla okna
		g_HDC = hDC;
		SetupPixelFormat(hDC);		// wywo�uje funkcj� okre�laj�c� format pikseli
		// tworzy kontekst grafiki i czyni go bie��cym
		hRC = wglCreateContext(hDC);
		wglMakeCurrent(hDC, hRC);
		return 0;
		break;

	case WM_CLOSE:					// Zamkni�cie okna
		wglMakeCurrent(hDC, NULL);  // usuwa kontekst renderowania okna
		wglDeleteContext(hRC);
		PostQuitMessage(0);			// wysy�a WM_QUIT do kolejki komunikat�w
		return 0;
		break;

	case WM_SIZE:					// Zmiana wymiar�w okna
		height = HIWORD(lParam);
		width = LOWORD(lParam);
		if (height == 0)				// zabezpieczenie przed dzieleniem przez 0
			height = 1;
		glViewport(0, 0, width, height);		// nadanie nowych wymiar�w okna OpenGL
		glMatrixMode(GL_PROJECTION);			// prze��czenie macierzy rzutowania
		glLoadIdentity();						// zresetowanie macierzy rzutowania
		gluPerspective(45.0f, (GLfloat)width / (GLfloat)height, 1.0f, 1000.0f);  // wyznaczenie proporcji obrazu i ustawienie rzutowania perspektywicznego
		glMatrixMode(GL_MODELVIEW);				// prze��czenie macierzy modelowania
		glLoadIdentity();						// zresetowanie macierzy modelowania
		return 0;
		break;

	case WM_KEYDOWN:							// Is A Key Being Held Down?
	{
		keys[wParam] = TRUE;					// If So, Mark It As TRUE
		return 0;								// Jump Back
	}

	case WM_KEYUP:								// Has A Key Been Released?
	{
		keys[wParam] = FALSE;					// If So, Mark It As FALSE
		return 0;								// Jump Back
	}

	default:
		break;
	}

	return (DefWindowProc(hwnd, message, wParam, lParam));
}

// Funkcja g��wna, od kt�rej rozpoczyna si� wykonywanie aplikacji
int WINAPI WinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance, LPSTR lpCmdLine, int nShowCmd)
{
	WNDCLASSEX windowClass;		// klasa okna
	HWND	   hwnd;			// uchwyt okna
	MSG		   msg;				// komunikat
	bool	   done;			// znacznik zako�czenia aplikacji
	DWORD	   dwExStyle;		// rozszerzony styl okna
	DWORD	   dwStyle;			// styl okna
	RECT	   windowRect;		// rozmiar okna

	// parametry okna
	int width = 800;
	int height = 600;
	int bits = 32;

	// fullScreen = TRUE/FALSE;		// Prze��cznik aplikacja okienkowa/aplikacja pe�noekranowa

	windowRect.left = (long)0;						// struktura okre�laj�ca rozmiary okna
	windowRect.right = (long)width;
	windowRect.top = (long)0;
	windowRect.bottom = (long)height;

	// definicja klasy okna
	windowClass.cbSize = sizeof(WNDCLASSEX);
	windowClass.style = CS_HREDRAW | CS_VREDRAW;
	windowClass.lpfnWndProc = WndProc;
	windowClass.cbClsExtra = 0;
	windowClass.cbWndExtra = 0;
	windowClass.hInstance = hInstance;
	windowClass.hIcon = LoadIcon(NULL, IDI_APPLICATION);	// domy�lna ikona
	windowClass.hCursor = LoadCursor(NULL, IDC_ARROW);		// domy�lny kursor
	windowClass.hbrBackground = NULL;								// bez t�a
	windowClass.lpszMenuName = NULL;								// bez menu
	windowClass.lpszClassName = "MojaKlasa";
	windowClass.hIconSm = LoadIcon(NULL, IDI_WINLOGO);		// logo Windows

	// zarejestrowanie klasy okna
	if (!RegisterClassEx(&windowClass))
		return 0;

	if (fullScreen)								// W��czenie trybu pe�noekranowego
	{
		DEVMODE dmScreenSettings;						// tryb urz�dzenia
		memset(&dmScreenSettings, 0, sizeof(dmScreenSettings));
		dmScreenSettings.dmSize = sizeof(dmScreenSettings);
		dmScreenSettings.dmPelsWidth = width;			// szeroko�� ekranu
		dmScreenSettings.dmPelsHeight = height;			// wysoko�� ekranu
		dmScreenSettings.dmBitsPerPel = bits;			// ilo�� bit�w na piksel
		dmScreenSettings.dmFields = DM_BITSPERPEL | DM_PELSWIDTH | DM_PELSHEIGHT;

		// je�eli prze��czenie trybu na pe�noekranowy nie powiod�o si�, prze��czenie z powrotem na tryb okienkowy
		if (ChangeDisplaySettings(&dmScreenSettings, CDS_FULLSCREEN) != DISP_CHANGE_SUCCESSFUL)
		{
			MessageBox(NULL, "Prze��czenie trybu wyswietlania nie powiod�o si�", NULL, MB_OK);
			fullScreen = FALSE;
		}
	}

	if (fullScreen)								// Tryb pe�noekranowy?
	{
		dwExStyle = WS_EX_APPWINDOW;				// rozszerzony styl okna
		dwStyle = WS_POPUP;						// styl okna
		ShowCursor(FALSE);						// ukrycie kursora myszy
	}
	else										// Tryb okienkowy?
	{
		dwExStyle = WS_EX_APPWINDOW | WS_EX_WINDOWEDGE;	// definicja klasy okna
		dwStyle = WS_OVERLAPPEDWINDOW;					// styl okna
	}

	AdjustWindowRectEx(&windowRect, dwStyle, FALSE, dwExStyle);		// skorygowanie rozmiaru okna
	// utworzenie okna
	hwnd = CreateWindowEx(NULL,									// styl rozszerzony
		"MojaKlasa",							// nazwa klasy
		"Przyk�ad pierwszy: sze�cian",		// nazwa aplikacji
		dwStyle | WS_CLIPCHILDREN |
		WS_CLIPSIBLINGS,
		0, 0,								// wsp�rz�dne x,y
		windowRect.right - windowRect.left,
		windowRect.bottom - windowRect.top,	// szeroko��, wysoko��
		NULL,									// uchwyt okna nadrz�dnego
		NULL,									// uchwyt menu
		hInstance,							// instancja aplikacji
		NULL);

	if (!hwnd)	// sprawdzenie, czy utworzenie okna nie powiod�o si� (wtedy warto�� hwnd r�wna NULL)
		return 0;

	MessageBox(hwnd, " 1 - rozsuwanie i zsuwanie sze�cian�w, 2 - obr�t sze�cian�w,  3 - obr�t  ka�dego sze�cianu, 4 - zmiana kolor�w trzech sze�cian�w \n (5 - przywr�cenie kolor�w sze�cian�w)", "Info sterowania sze�cianami", 0);

	ShowWindow(hwnd, SW_SHOW);			// wy�wietlenie okna
	UpdateWindow(hwnd);					// aktualizacja okna

	done = false;						// inicjacja zmiennej warunku p�tli przetwarzania komunikat�w
	Initialize();						// inicjacja OpenGLa
	lasttickCount = GetTickCount64();		// odczyt czasu

	while (!done)	// p�tla przetwarzania komunikat�w
	{
		PeekMessage(&msg, NULL, 0, 0, PM_REMOVE);
		if (msg.message == WM_QUIT)		// aplikacja otrzyma�a komunikat WM_QUIT?
			done = true;				// je�li tak, to ko�czy dzia�anie
		else
		{
			tickCount = GetTickCount64();		      // je�li nie to odczytuje czas
			if ((tickCount - lasttickCount) > 20)   // sprawda czy min�o 20 ms
			{
				Render();					// je�li nie to renderuje scen�,

				if (keys['1'])						// tryb 1
				{
					keys['1'] = false;
					mode = 1;
				}
				if (keys['2'])						// tryb 2
				{
					keys['2'] = false;
					mode = 2;
				}
				if (keys['3'])						// tryb 3
				{
					keys['3'] = false;
					mode = 3;
				}
				if (keys['4'])						// tryb 4
				{
					keys['4'] = false;
					mode = 4;
				}

				if (keys['5'])						// tryb 4
				{
					keys['5'] = false;
					mode = 5;
				}
				lasttickCount = tickCount;		 // oraz zapami�tuje poprzedni� chwil� czasu
			}
			
			TranslateMessage(&msg);		// t�umaczy komunikat i wysy�a do systemu
			DispatchMessage(&msg);
		}
	}


	if (fullScreen)						// je�eli by� tryb pe�noekranowy
	{
		ChangeDisplaySettings(NULL, 0);	// to przywr�cenie pulpitu
		ShowCursor(TRUE);				// i wska�nika myszy
	}


	return msg.wParam;
}
