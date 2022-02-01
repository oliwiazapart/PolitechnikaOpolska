#define WIN32_LEAN_AND_MEAN				// "odchudza" aplikacjê Windows

// Pliki nag³ówkowe
#include <windows.h>					// standardowy plik nag³ówkowy Windows
#include <gl/gl.h>						// standardowy plik nag³ówkowy OpenGL
#include <gl/glu.h>						// plik nag³ówkowy biblioteki GLU
#include <gl/glaux.h>					// funkcje pomocnicze OpenGL 

#pragma comment(lib, "legacy_stdio_definitions.lib")
#pragma warning(disable:4996)
#pragma comment(lib,"opengl32.lib") //informuje konsolidator, aby doda³ bibliotekê do listy zale¿noœci bibliotek
#pragma comment(lib,"glu32.lib")

// Zmienne globalne
HDC g_HDC;								// globalny kontekst urz¹dzenia
bool fullScreen = false;	// true = tryb pe³noekranowy; false = tryb okienkowy
bool keys[256];
DWORD tickCount, lasttickCount;

GLint numberCubesPerLine = 3;			// ilosc szescianów w linii
int mode = 3;							//tryb 1- size, 2- obrót ca³., 3-obrót poj., 4- kolory
bool extend = true;						//powiêksz/zmniejsz
GLfloat angleAll = 1.0f;				//kat obrotu szescianow
GLfloat angleSingle = 0.0f;			    //kat obrotu pojedynczego szescianu
GLfloat space = 1.8f;				    //odleg³oœæ miêdzy szeœæ
GLfloat spaceMin = 1.2f;			// minimalna odleg³oœæ miêdzy szeœæ
GLfloat spaceMax = 2.0f;			//maksymalna odleg³oœæ miêdzy szeœæ

//Kolory do zmiany
GLfloat orangeColor[3] = { 1.0f, 0.5f, 0.0f };
GLfloat pinkColor[3] = { 2.0f, 0.5f, 1.0f };
GLfloat greenColor[3] = { 0.0f, 1.0f, 0.0f };
GLfloat baseColor[3] = { 0.0f, 0.0f, 1.0f };
bool colorChanged = false;
// Parametry oœwietlenia
float ambientLight[] = { 0.2f, 0.2f, 0.2f, 1.0f };	    // œwiat³o otoczenia
float diffuseLight[] = { 1.0f, 1.0f, 1.0f, 1.0f };	    // œwiat³o rozproszone
float lightPosition[] = { 1.0f, 0.0f, 1.0f, 0.0f };	    // po³o¿enie Ÿród³a œwiat³a

// Parametry materia³u
float ambientMaterial[] = { 0.5f, 0.0f, 0.0f, 1.0f };
float diffuseMaterial[] = { 0.3f, 0.5f, 0.7f, 1.0f };


void Initialize()       // Inicjacja OpenGL
{
	glClearColor(0.0f, 0.0f, 0.0f, 0.0f);		// czarny kolor t³a

	glShadeModel(GL_SMOOTH);					// cieniowanie g³adkie
	glEnable(GL_DEPTH_TEST);					// w³¹czenie bufora g³êbi
	glEnable(GL_CULL_FACE);						// ukrywanie tylnych stron wielok¹tów
	glFrontFace(GL_CCW);						// porz¹dek wierzcho³ków przeciwny do kierunku ruchu wskazówek zegara
	glEnable(GL_LIGHTING);						// w³¹czenie oœwietlenia
	glEnable(GL_COLOR_MATERIAL);				// W£¥CZENIE uwzglêdniania kolorów wierzcho³ków przy oœwietlaniu
												// nieistotne s¹ wtedy poni¿sze instrukcje ustawiaj¹ce w³aœciwoœci materia³u i ¿ród³a œwiat³a
	glClearDepth(1.0f);
	glDepthFunc(GL_LEQUAL);
	glHint(GL_PERSPECTIVE_CORRECTION_HINT, GL_NICEST);


	// Ustawienie w³aœciwoœci materia³u dla pierwszego Ÿród³a œwiat³a LIGHT0
	glMaterialfv(GL_FRONT, GL_AMBIENT, ambientMaterial);
	glMaterialfv(GL_FRONT, GL_DIFFUSE, diffuseMaterial);

	// Ustawienie Ÿród³a œwiat³a GL_LIGHT0
	glLightfv(GL_LIGHT0, GL_AMBIENT, ambientLight);		// sk³adowa otoczenia
	glLightfv(GL_LIGHT0, GL_DIFFUSE, diffuseLight);		// sk³adowa rozproszona
	glLightfv(GL_LIGHT0, GL_POSITION, lightPosition);	// po³o¿enie Ÿród³a œwiat³a

	// W³¹czenie Ÿród³a œwiat³a
	glEnable(GL_LIGHT0);
}

void DrawCube(GLfloat rotation) //Narysowanie szeœcianu w xPos,yPos,zPos
{
	glPushMatrix();
	glRotatef(rotation, 0.0f, 1.0f, 0.0f);
	glBegin(GL_POLYGON);
	glNormal3f(0.0f, 1.0f, 0.0f);	// górna œciana (w p³aszczyŸnie XZ)
	glVertex3f(0.5f, 0.5f, 0.5f);
	glVertex3f(0.5f, 0.5f, -0.5f);
	glVertex3f(-0.5f, 0.5f, -0.5f);
	glVertex3f(-0.5f, 0.5f, 0.5f);
	glEnd();
	glBegin(GL_POLYGON);
	glNormal3f(0.0f, 0.0f, 1.0f);	// przednia œciana (w p³aszczyŸnie XY)
	glVertex3f(0.5f, 0.5f, 0.5f);
	glVertex3f(-0.5f, 0.5f, 0.5f);
	glVertex3f(-0.5f, -0.5f, 0.5f);
	glVertex3f(0.5f, -0.5f, 0.5f);
	glEnd();
	glBegin(GL_POLYGON);
	glNormal3f(1.0f, 0.0f, 0.0f);	// prawa œciana (w p³aszczyŸnie YZ)
	glVertex3f(0.5f, 0.5f, 0.5f);
	glVertex3f(0.5f, -0.5f, 0.5f);
	glVertex3f(0.5f, -0.5f, -0.5f);
	glVertex3f(0.5f, 0.5f, -0.5f);
	glEnd();
	glBegin(GL_POLYGON);
	glNormal3f(-1.0f, 0.0f, 0.0f);	// lewa œciana (w p³aszczyŸnie YZ)
	glVertex3f(-0.5f, 0.5f, 0.5f);
	glVertex3f(-0.5f, 0.5f, -0.5f);
	glVertex3f(-0.5f, -0.5f, -0.5f);
	glVertex3f(-0.5f, -0.5f, 0.5f);
	glEnd();
	glBegin(GL_POLYGON);
	glNormal3f(0.0f, -1.0f, 0.0f);	// dolna œciana (w p³aszczyŸnie XZ)
	glVertex3f(-0.5f, -0.5f, 0.5f);
	glVertex3f(-0.5f, -0.5f, -0.5f);
	glVertex3f(0.5f, -0.5f, -0.5f);
	glVertex3f(0.5f, -0.5f, 0.5f);
	glEnd();
	glBegin(GL_POLYGON);
	glNormal3f(0.0f, 0.0f, -1.0f);	// tylna œciana (w p³aszczyŸnie XY)
	glVertex3f(0.5f, -0.5f, -0.5f);
	glVertex3f(-0.5f, -0.5f, -0.5f);
	glVertex3f(-0.5f, 0.5f, -0.5f);
	glVertex3f(0.5f, 0.5f, -0.5f);
	glEnd();
	glPopMatrix();
}


void Render()   // Renderowanie sceny
{
	glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);		// Opró¿nienie bufora ekranu i bufora g³êbi
	glLoadIdentity();										// Zresetowanie macierzy modelowania


	glTranslatef(0.0f, 0.0f, -12);					//przeson w przód
	glRotatef(20, 1.0f, 0.0f, 0.0f);					//obróc o 20stopni w dó³


	glRotatef(angleAll, 0.0f, 1.0f, 0.0f);				//obróæ ca³y szyk o k¹t ca³oœci

	glTranslatef(-(numberCubesPerLine - 1) * space / 2,
		-(numberCubesPerLine - 1) * space / 2, -(numberCubesPerLine - 1) * space / 2);  //przesun calosc tak, zeby srodek szyku byl w srodku obrotu


	for (int i = 0; i < numberCubesPerLine; i++)
	{
		glPushMatrix();							//wrzucam akturalne po³o¿enie na stos
		glTranslatef(i * space, 0.0f, 0.0f);   // przesuwam w osi x
		for (int j = 0; j < numberCubesPerLine; j++)
		{
			glPushMatrix();						//wrzucam aktualne po³o¿enie na stos
			glTranslatef(0.0f, j * space, 0.0f); //przesuwam w osi y
			for (int k = 0; k < numberCubesPerLine; k++)
			{
				glPushMatrix();						//wrzucam aktualne po³o¿enie na stos
				glTranslatef(0.0f, 0.0f, k * space); //przesuwam w osi x
				if (i == 2 && j == 2 && k == 2)			//pocz¹tek robienia przek¹tnej kolorowej
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

	SwapBuffers(g_HDC);						// Prze³¹czenie buforów
}


void SetupPixelFormat(HDC hDC)  // Funkcja okreœlaj¹ca format pikseli
{
	int nPixelFormat;					// indeks formatu pikseli

	static PIXELFORMATDESCRIPTOR pfd = {
		sizeof(PIXELFORMATDESCRIPTOR),	// rozmiar struktury
		1,								// domyœlna wersja
		PFD_DRAW_TO_WINDOW |			// grafika w oknie
		PFD_SUPPORT_OPENGL |			// grafika OpenGL 
		PFD_DOUBLEBUFFER,				// podwójne buforowanie
		PFD_TYPE_RGBA,					// tryb kolorów RGBA 
		32,								// 32-bitowy opis kolorów
		0, 0, 0, 0, 0, 0,				// nie specyfikuje bitów kolorów
		0,								// bez bufora alfa
		0,								// nie specyfikuje bitu przesuniêcia
		0,								// bez bufora akumulacji
		0, 0, 0, 0,						// ignoruje bity akumulacji
		16,								// 16-bitowy bufor Z
		0,								// bez bufora powielania
		0,								// bez buforów pomocniczych
		PFD_MAIN_PLANE,					// g³ówna p³aszczyzna rysowania
		0,								// zarezerwowane
		0, 0, 0 };						// ignoruje maski warstw

	nPixelFormat = ChoosePixelFormat(hDC, &pfd);	// wybiera najbardziej zgodny format pikseli 
	SetPixelFormat(hDC, nPixelFormat, &pfd);		// okreœla format pikseli dla danego kontekstu urz¹dzenia
}


LRESULT CALLBACK WndProc(HWND hwnd, UINT message, WPARAM wParam, LPARAM lParam)  // Procedura okienkowa
{
	static HGLRC hRC;					// kontekst tworzenia grafiki
	static HDC hDC;						// kontekst urz¹dzenia
	int width, height;					// szerokoœæ i wysokoœæ okna

	switch (message)						// obs³uga komunikatów
	{
	case WM_CREATE:					// Utworzenie okna
		hDC = GetDC(hwnd);			// pobiera kontekst urz¹dzenia dla okna
		g_HDC = hDC;
		SetupPixelFormat(hDC);		// wywo³uje funkcjê okreœlaj¹c¹ format pikseli
		// tworzy kontekst grafiki i czyni go bie¿¹cym
		hRC = wglCreateContext(hDC);
		wglMakeCurrent(hDC, hRC);
		return 0;
		break;

	case WM_CLOSE:					// Zamkniêcie okna
		wglMakeCurrent(hDC, NULL);  // usuwa kontekst renderowania okna
		wglDeleteContext(hRC);
		PostQuitMessage(0);			// wysy³a WM_QUIT do kolejki komunikatów
		return 0;
		break;

	case WM_SIZE:					// Zmiana wymiarów okna
		height = HIWORD(lParam);
		width = LOWORD(lParam);
		if (height == 0)				// zabezpieczenie przed dzieleniem przez 0
			height = 1;
		glViewport(0, 0, width, height);		// nadanie nowych wymiarów okna OpenGL
		glMatrixMode(GL_PROJECTION);			// prze³¹czenie macierzy rzutowania
		glLoadIdentity();						// zresetowanie macierzy rzutowania
		gluPerspective(45.0f, (GLfloat)width / (GLfloat)height, 1.0f, 1000.0f);  // wyznaczenie proporcji obrazu i ustawienie rzutowania perspektywicznego
		glMatrixMode(GL_MODELVIEW);				// prze³¹czenie macierzy modelowania
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

// Funkcja g³ówna, od której rozpoczyna siê wykonywanie aplikacji
int WINAPI WinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance, LPSTR lpCmdLine, int nShowCmd)
{
	WNDCLASSEX windowClass;		// klasa okna
	HWND	   hwnd;			// uchwyt okna
	MSG		   msg;				// komunikat
	bool	   done;			// znacznik zakoñczenia aplikacji
	DWORD	   dwExStyle;		// rozszerzony styl okna
	DWORD	   dwStyle;			// styl okna
	RECT	   windowRect;		// rozmiar okna

	// parametry okna
	int width = 800;
	int height = 600;
	int bits = 32;

	// fullScreen = TRUE/FALSE;		// Prze³¹cznik aplikacja okienkowa/aplikacja pe³noekranowa

	windowRect.left = (long)0;						// struktura okreœlaj¹ca rozmiary okna
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
	windowClass.hIcon = LoadIcon(NULL, IDI_APPLICATION);	// domyœlna ikona
	windowClass.hCursor = LoadCursor(NULL, IDC_ARROW);		// domyœlny kursor
	windowClass.hbrBackground = NULL;								// bez t³a
	windowClass.lpszMenuName = NULL;								// bez menu
	windowClass.lpszClassName = "MojaKlasa";
	windowClass.hIconSm = LoadIcon(NULL, IDI_WINLOGO);		// logo Windows

	// zarejestrowanie klasy okna
	if (!RegisterClassEx(&windowClass))
		return 0;

	if (fullScreen)								// W³¹czenie trybu pe³noekranowego
	{
		DEVMODE dmScreenSettings;						// tryb urz¹dzenia
		memset(&dmScreenSettings, 0, sizeof(dmScreenSettings));
		dmScreenSettings.dmSize = sizeof(dmScreenSettings);
		dmScreenSettings.dmPelsWidth = width;			// szerokoœæ ekranu
		dmScreenSettings.dmPelsHeight = height;			// wysokoœæ ekranu
		dmScreenSettings.dmBitsPerPel = bits;			// iloœæ bitów na piksel
		dmScreenSettings.dmFields = DM_BITSPERPEL | DM_PELSWIDTH | DM_PELSHEIGHT;

		// je¿eli prze³¹czenie trybu na pe³noekranowy nie powiod³o siê, prze³¹czenie z powrotem na tryb okienkowy
		if (ChangeDisplaySettings(&dmScreenSettings, CDS_FULLSCREEN) != DISP_CHANGE_SUCCESSFUL)
		{
			MessageBox(NULL, "Prze³¹czenie trybu wyswietlania nie powiod³o siê", NULL, MB_OK);
			fullScreen = FALSE;
		}
	}

	if (fullScreen)								// Tryb pe³noekranowy?
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
		"Przyk³ad pierwszy: szeœcian",		// nazwa aplikacji
		dwStyle | WS_CLIPCHILDREN |
		WS_CLIPSIBLINGS,
		0, 0,								// wspó³rzêdne x,y
		windowRect.right - windowRect.left,
		windowRect.bottom - windowRect.top,	// szerokoœæ, wysokoœæ
		NULL,									// uchwyt okna nadrzêdnego
		NULL,									// uchwyt menu
		hInstance,							// instancja aplikacji
		NULL);

	if (!hwnd)	// sprawdzenie, czy utworzenie okna nie powiod³o siê (wtedy wartoœæ hwnd równa NULL)
		return 0;

	MessageBox(hwnd, " 1 - rozsuwanie i zsuwanie szeœcianów, 2 - obrót szeœcianów,  3 - obrót  ka¿dego szeœcianu, 4 - zmiana kolorów trzech szeœcianów \n (5 - przywrócenie kolorów szeœcianów)", "Info sterowania szeœcianami", 0);

	ShowWindow(hwnd, SW_SHOW);			// wyœwietlenie okna
	UpdateWindow(hwnd);					// aktualizacja okna

	done = false;						// inicjacja zmiennej warunku pêtli przetwarzania komunikatów
	Initialize();						// inicjacja OpenGLa
	lasttickCount = GetTickCount64();		// odczyt czasu

	while (!done)	// pêtla przetwarzania komunikatów
	{
		PeekMessage(&msg, NULL, 0, 0, PM_REMOVE);
		if (msg.message == WM_QUIT)		// aplikacja otrzyma³a komunikat WM_QUIT?
			done = true;				// jeœli tak, to koñczy dzia³anie
		else
		{
			tickCount = GetTickCount64();		      // jeœli nie to odczytuje czas
			if ((tickCount - lasttickCount) > 20)   // sprawda czy minê³o 20 ms
			{
				Render();					// jeœli nie to renderuje scenê,

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
				lasttickCount = tickCount;		 // oraz zapamiêtuje poprzedni¹ chwilê czasu
			}
			
			TranslateMessage(&msg);		// t³umaczy komunikat i wysy³a do systemu
			DispatchMessage(&msg);
		}
	}


	if (fullScreen)						// je¿eli by³ tryb pe³noekranowy
	{
		ChangeDisplaySettings(NULL, 0);	// to przywrócenie pulpitu
		ShowCursor(TRUE);				// i wskaŸnika myszy
	}


	return msg.wParam;
}
